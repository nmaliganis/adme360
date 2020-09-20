using System;
using adme360.presenter.ViewModel.Containers;
using adme360.suite.ui.Controls;
using adme360.view.Controls.Containers;
using DevExpress.XtraMap;

namespace adme360.suite.ui.Views.Components.Containers
{
    public partial class UcClientsMonitoringContainers : BaseModule, IUcMonitoringContainerManagementView
    {

        private UcMonitoringContainerManagementPresenter _ucMonitoringContainerManagementPresenter;
        public UcClientsMonitoringContainers()
        {
            InitializeComponent();
            InitializePresenter();
        }

        private void InitializePresenter()
        {
            _ucMonitoringContainerManagementPresenter = new UcMonitoringContainerManagementPresenter(this);
        }

        private void UcClientsUcContainersLoad(object sender, EventArgs e)
        {
            OnLoaded();
        }

        private void OnLoaded()
        {
        }
    }
}
