using System.Windows.Forms;
using adme360.presenter.ViewModel.Users;
using adme360.view.Controls.Users;
using DevExpress.Utils.Menu;
using adme360.suite.ui.Controls;
using adme360.suite.ui.Views.Repositories;

namespace adme360.suite.ui.Views.Modules
{
    public partial class UcUsers : BaseModule, IUcUserManagementView
    {
        public override string ModuleCaption => "Users";
        public override bool AllowWaitDialog => true;

        #region Presenters

        private UcUserManagementPresenter _userManagementPresenter;

        #endregion

        internal override void InitModule(IDXMenuManager manager, object data)
        {
            IsInitialized = true;
            base.InitModule(manager, data);
        }

        internal override void ShowModule(object item)
        {
            if (!IsInitialized)
                return;
            IsShown = true;
            base.ShowModule(item);

            OnShowModuleLocal();
        }

        private void OnShowModuleLocal()
        {
        }

        internal override void HideModule()
        {
            IsShown = false;
            base.HideModule();
        }

        public UcUsers()
        {
            InitializeComponent();
            InitializePresenter();
            InitializeLoad();
        }

        private void InitializePresenter()
        {
            _userManagementPresenter = new UcUserManagementPresenter(this);
        }

        private void InitializeLoad()
        {
            SelectedModuleItem = "UserManagement";
            _userManagementPresenter.NavBarModuleLinkClicked();
        }

        public string SelectedModuleItem { get; set; }

        public bool OpenFlyoutForAddEditUserRole { get; set; }

        public bool PopulateUcCtrl
        {
            set
            {
                if (value)
                {
                    pnlCntrlUsersSelectionProjection.Controls.Clear();

                    BaseModule ucModuleItem = ModuleUserRoleViewRepository.ViewRepository[SelectedModuleItem];
                    ucModuleItem.Dock = DockStyle.Fill;
                    pnlCntrlUsersSelectionProjection.Controls.Add(ucModuleItem);
                }
            }
        }


        private void NvBrCntrlUsersSelectionsLinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            SelectedModuleItem = (string)e.Link.Item.Tag;
            _userManagementPresenter.NavBarModuleLinkClicked();
        }
    }
}
