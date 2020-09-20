using System;
using System.Windows.Forms;
using adme360.models.DTOs.Users;
using adme360.presenter.Mqtt;
using adme360.presenter.ServiceAgents.Impls;
using adme360.view.Controls.Dashboards;
using DevExpress.XtraBars.Docking2010.Views;
using DevExpress.XtraBars.Docking2010.Views.WindowsUI;
using DevExpress.XtraEditors;
using adme360.suite.ui.Controls;
using adme360.suite.ui.Views.FlyOuts.AddEditContainer;
using adme360.suite.ui.Views.FlyOuts.AddEditEmployee;
using adme360.suite.ui.Views.FlyOuts.AddEditRole;
using adme360.suite.ui.Views.FlyOuts.AddEditSensor;
using adme360.suite.ui.Views.FlyOuts.AddEditSimcard;
using adme360.suite.ui.Views.FlyOuts.AddEditUser;
using adme360.suite.ui.Views.FlyOuts.LoginRegister;

namespace adme360.suite.ui
{
    public partial class Main : XtraForm, IMainView
    {
        private object _current;
        readonly UserUiModel _userToBeLoginIn = new UserUiModel();

        private MainPresenter _mainPresenter;

        public Main()
        {
            StartPosition = FormStartPosition.Manual;
            Location = Screen.GetBounds(MousePosition).Location;
            InitializeComponent();

            HideShowSuTilesAndComponents(true);

            InitializePresenters();

            mainWindowsUiView.ContentContainerActions.Add(new SetSkinAction("Metropolis", "Αλλάξτε Θέμα"));
            closeFlyout.Action = CreateCloseAction();

            this.OnLoginEventRequested += ModuleOnLoginEventRequested;

            IRabbitMqttConfiguration rabbitMqttConfiguration = new RabbitMqttConfiguration();
            rabbitMqttConfiguration.EstablishConnection();
        }

        private void HideShowSuTilesAndComponents(bool hide)
        {
            if (hide)
            {
                CorePg.Items.Remove(ucUsersDocument);
                CorePg.Items.Remove(ucSettingsDocument);

                MainGrp.Items.Remove(ucUsers);
                MainGrp.Items.Remove(ucSettings);
            }
            else
            {
                CorePg.Items.Add(ucUsersDocument);
                CorePg.Items.Add(ucSettingsDocument);

                MainGrp.Items.Add(ucUsers);
                MainGrp.Items.Add(ucSettings);
            }
        }

        private void InitializePresenters()
        {
            _mainPresenter = new MainPresenter(this);
        }

        private FlyoutAction CreateCloseAction()
        {
            var closeAction = new FlyoutAction
            {
                Description = "Θέλετε να τερματίστε την εφαρμογή;"
            };

            closeAction.Commands.Add(FlyoutCommand.Yes);
            closeAction.Commands.Add(FlyoutCommand.No);
            return closeAction;
        }

        private void MainWindowsUiViewQueryStartupContentContainer(object sender, QueryContentContainerEventArgs e)
        {
            MainGrp.Caption = "dl-wm suite";
            e.ContentContainer = MainGrp;
        }

        private void MainLoad(object sender, EventArgs e)
        {
            LoginEventArgs args =
                new LoginEventArgs("OnStartupLogin");
            this.OnLoginRequested(args);

            if (_userToBeLoginIn.Message == "cancel")
            {
                this.Close();
            }

            if (_userToBeLoginIn.Token == null)
            {
                this.Close();
            }

            
            Token = _userToBeLoginIn.Token;
            _mainPresenter.ExtractRoleFromTokens();

            if (ClaimRole == "SU")
            {
                HideShowSuTilesAndComponents(false);
            }

            CorePg.Caption = _userToBeLoginIn.Login;
        }

        private void MainWindowsUiViewNavigatedTo(object sender, NavigationEventArgs e)
        {
        }
        private void MainWindowsUiViewNavigatedFrom(object sender, NavigationEventArgs e)
        {
        }

        private void MainWindowsUiViewFlyoutHidden(object sender, FlyoutResultEventArgs e)
        {
            if (mainWindowsUiView.ActiveFlyoutContainer == loginFlyout)
                mainWindowsUiView.ActivateContainer(MainGrp);
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            base.OnClosing(e);
                if (mainWindowsUiView.ShowFlyoutDialog(closeFlyout) != DialogResult.Yes)
                    e.Cancel = true;

            Environment.Exit(0);
        }

        private void WindowsUiViewQueryControl(object sender, QueryControlEventArgs e)
        {
            BaseModule module = e.Document.Tag is BaseModule ? (BaseModule)e.Document.Tag :
                    Activator.CreateInstance(typeof(Main).Assembly.GetType(e.Document.ControlTypeName)) as BaseModule;
            module.InitModule(mainBarManager, mainWindowsUiView);

            ShowModuleAfterActivation(e.Document, module);
            module.OnSigninEventRequested += ModuleOnSigninEventRequested;
            module.OnAddEditUserRoleRequested += new EventHandler<BaseModule.FlyoutAddEditRoleEventArgs>(ModuleUserRoleManagementAddEditRoleRequested);
            module.OnAddEditUserRequested += new EventHandler<BaseModule.FlyoutAddEditUserEventArgs>(ModuleUserManagementAddEditUserRequested);
            module.OnEvtAddEditEmployeeRequested += new EventHandler<BaseModule.FlyoutAddEmployeeEventArgs>(ModuleEvtAddNewEditEmployeeManagementRequested);
            module.OnAddEditContainerRequested += new EventHandler<BaseModule.FlyoutAddEditContainerEventArgs>(ModuleAddNewEditContainerManagementRequested);
            module.OnAddEditSimcardRequested += new EventHandler<BaseModule.FlyoutAddEditSimcardEventArgs>(ModuleAddNewEditSimcardManagementRequested);
            module.OnAddEditSensorRequested += new EventHandler<BaseModule.FlyoutAddEditSensorEventArgs>(ModuleAddNewEditSensorManagementRequested);

            e.Document.Tag = module;
            e.Control = module;
        }

        #region flyouts

        private void ModuleUserManagementAddEditUserRequested(object sender, BaseModule.FlyoutAddEditUserEventArgs e)
        {
            FlyoutAction onDemandAddEditUserManagementFlyoutAction = new FlyoutAction {Description = $"{e.Text}"};
            CustomFlyoutDialog onDemandAddEEditUserManagementFlyoutDialog = new CustomFlyoutDialog(this, onDemandAddEditUserManagementFlyoutAction,
                control: new UcFlyUserAddNewEditUserManagement(e));
            onDemandAddEEditUserManagementFlyoutDialog.ShowDialog();
        }

        private void ModuleOnLoginEventRequested(object sender, LoginEventArgs e)
        {
            FlyoutAction onDemandSiginFlyoutAction = new FlyoutAction { Description = $"{e.Text}" };
            CustomFlyoutDialog onDemandSigninFlyoutDialog = new CustomFlyoutDialog(this, onDemandSiginFlyoutAction,
                new UcFlyLoginForget(e.Text, _userToBeLoginIn));
            onDemandSigninFlyoutDialog.ShowDialog();
        }

        private void ModuleOnSigninEventRequested(object sender, BaseModule.SiginEventArgs e)
        {
        }

        private void ModuleUserRoleManagementAddEditRoleRequested(object sender, BaseModule.FlyoutAddEditRoleEventArgs e)
        {
            FlyoutAction onDemandMessageManagementFlyoutAction = new FlyoutAction {Description = $"{e.Text}"};
            CustomFlyoutDialog onDemandMessageManagementFlyoutDialog = new CustomFlyoutDialog(this, onDemandMessageManagementFlyoutAction,
                new UcFlyRoleManagement(e));
            onDemandMessageManagementFlyoutDialog.ShowDialog();
        }

        private void ModuleEvtAddNewEditEmployeeManagementRequested(object sender, BaseModule.FlyoutAddEmployeeEventArgs e)
        {
            FlyoutAction evtAddNewEmployeeManagementFlyoutAction = new FlyoutAction {Description = $"{e.Text}"};
            CustomFlyoutDialog timeTableManagementFlyoutDialog = new CustomFlyoutDialog(this, evtAddNewEmployeeManagementFlyoutAction,
                new UcFlyEvtAddNewEditEmployeeManagement());
            timeTableManagementFlyoutDialog.ShowDialog();
        }

        private void ModuleAddNewEditContainerManagementRequested(object sender, BaseModule.FlyoutAddEditContainerEventArgs e)
        {
            FlyoutAction onAddNewContainerManagementFlyoutAction = new FlyoutAction {Description = $"{e.Text}"};
            CustomFlyoutDialog addEditContainerManagementFlyoutDialog = new CustomFlyoutDialog(this, onAddNewContainerManagementFlyoutAction,
                new UcFlyContainerAddNewEditContainerManagement(e));
            addEditContainerManagementFlyoutDialog.ShowDialog();
        }

        private void ModuleAddNewEditSimcardManagementRequested(object sender, BaseModule.FlyoutAddEditSimcardEventArgs e)
        {
            FlyoutAction onAddNewSimcardManagementFlyoutAction = new FlyoutAction {Description = $"{e.Text}"};
            CustomFlyoutDialog addEditSimcardManagementFlyoutDialog = new CustomFlyoutDialog(this, onAddNewSimcardManagementFlyoutAction,
                new UcFlySimcardAddNewEditSimcardManagement(e));
            addEditSimcardManagementFlyoutDialog.ShowDialog();
        }

        private void ModuleAddNewEditSensorManagementRequested(object sender, BaseModule.FlyoutAddEditSensorEventArgs e)
        {
            FlyoutAction onAddNewSensorManagementFlyoutAction = new FlyoutAction {Description = $"{e.Text}"};
            CustomFlyoutDialog addEditSensorManagementFlyoutDialog = new CustomFlyoutDialog(this, onAddNewSensorManagementFlyoutAction,
                new UcFlySensorAddNewEditSensorManagement(e));
            addEditSensorManagementFlyoutDialog.ShowDialog();
        }

        #endregion

        private void WindowsUiViewTileClick(object sender, TileClickEventArgs e)
        {
            var tile = e.Tile as Tile;
            var module = tile?.Document?.Control as BaseModule;
            if (module != null)
            {
                TileItemFrame frame = tile.CurrentFrame;
                object data = frame?.Tag;
                module.ShowModule(data);
            }
        }

        public delegate void NavRequestEventHandler(object sender, NavRequestEventArgs e);

        public class NavRequestEventArgs : EventArgs
        {
        }

        private void ShowModuleAfterActivation(BaseDocument baseDocument, BaseModule module)
        {
            BaseTile tile = null;

            if (mainWindowsUiView.Tiles.TryGetValue(baseDocument, out tile))
            {
                TileItemFrame frame = tile.CurrentFrame;
                object data = _current ?? frame?.Tag;
                module.ShowModule(data);
            }
        }

        #region LogIn

        protected virtual void OnLoginRequested(LoginEventArgs args)
        {
            this.RaiseLogin(args);
        }

        private void RaiseLogin(LoginEventArgs args)
        {
            EventHandler<LoginEventArgs> handler = OnLoginEventRequested;
            handler?.Invoke(this, args);
        }

        public event EventHandler<LoginEventArgs> OnLoginEventRequested;

        public class LoginEventArgs : EventArgs
        {
            public LoginEventArgs(string text)
            {
                Text = text;
            }

            public bool IsAccepted { get; set; }

            public string Text { get; }
        }

        #endregion

        #region IMainView

        public string Token { get; set; }
        public string ClaimRole { get; set; }

        public bool NoneClaimRoleFromToken
        {
            set
            {
                if (value)
                {
                    Application.Exit();
                }
            }
        }

        #endregion
    }
}