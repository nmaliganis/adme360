using System.Windows.Forms;
using adme360.suite.ui.Controls;
using DevExpress.Utils.Menu;
using DevExpress.XtraNavBar;
using adme360.presenter.ViewModel.Sensors;
using adme360.suite.ui.Views.Repositories;
using adme360.view.Controls.Sensors;

namespace adme360.suite.ui.Views.Modules
{
    public partial class UcSensors : BaseModule, ISensorManagementView
    {
        public override string ModuleCaption => "Sersors";
        public override bool AllowWaitDialog => true;

        #region Presenters

        private SensorManagementPresenter _sensorManagementPresenter;

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

        public UcSensors()
        {
            InitializeComponent();
            InitializePresenter();
            InitializeLoad();
        }

        public string SelectedModuleItem { get; set; }


        private void InitializeLoad()
        {
            SelectedModuleItem = "SensorMonitoring";
            _sensorManagementPresenter.NavBarModuleLinkClicked();
        }

        private void InitializePresenter()
        {
            _sensorManagementPresenter = new SensorManagementPresenter(this);
        }

        #region ISensorManagementView

        public bool PopulateUcCtrl
        {
            set
            {
                if (value)
                {
                    pnlCntrlSensorSelectionProjection.Controls.Clear();
                    
                    BaseModule ucModuleItem = ModuleSensorViewRepository.ViewRepository[SelectedModuleItem];
                    ucModuleItem.Dock = DockStyle.Fill;
                    pnlCntrlSensorSelectionProjection.Controls.Add(ucModuleItem);
                }
            }
        }

        #endregion

        #region Locals

        private void NvBrCntrlSensorSelectionsLinkClicked(object sender, NavBarLinkEventArgs e)
        {
            SelectedModuleItem = (string)e.Link.Item.Tag;
            _sensorManagementPresenter.NavBarModuleLinkClicked();
        }

        #endregion
    }
}
