using System.Windows.Forms;
using adme360.presenter.ViewModel.Containers;
using adme360.suite.ui.Controls;
using adme360.suite.ui.Views.Repositories;
using adme360.view.Controls.Containers;
using DevExpress.Utils.Menu;

namespace adme360.suite.ui.Views.Modules
{
    public partial class UcContainers : BaseModule, IContainerManagementView
    {
        public override string ModuleCaption => "Containers";
        public override bool AllowWaitDialog => true;

        #region Presenters

        private ContainerManagementPresenter _containerManagementPresenter;

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

        public UcContainers()
        {
            InitializeComponent();
            InitializePresenter();
            InitializeLoad();
        }

        private void InitializePresenter()
        {
            _containerManagementPresenter = new ContainerManagementPresenter(this);
        }

        public string SelectedModuleItem { get; set; }


        private void InitializeLoad()
        {
            SelectedModuleItem = "ContainerMonitoring";
            _containerManagementPresenter.NavBarModuleLinkClicked();
        }

        public bool PopulateUcCtrl
        {
            set
            {
                if (value)
                {
                    pnlCntrlContainerSelectionProjection.Controls.Clear();
                    
                    BaseModule ucModuleItem = ModuleContainerViewRepository.ViewRepository[SelectedModuleItem];
                    ucModuleItem.Dock = DockStyle.Fill;
                    pnlCntrlContainerSelectionProjection.Controls.Add(ucModuleItem);
                }
            }
        }

        private void NvBrCntrlContainerSelectionsLinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            SelectedModuleItem = (string)e.Link.Item.Tag;
            _containerManagementPresenter.NavBarModuleLinkClicked();
        }
    }
}