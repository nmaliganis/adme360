using System;
using adme360.presenter.ViewModel.Containers;
using adme360.suite.ui.Controls;
using adme360.view.Controls.Containers;
using DevExpress.XtraMap;
using adme360.view.Controls.Sensors;

namespace adme360.suite.ui.Views.Components.Sensors
{
    public partial class UcClientsSettingsFirmwareSensors : BaseModule, IUcManagementSensorSettingsFirmwareView
    {
        public UcClientsSettingsFirmwareSensors()
        {
            InitializeComponent();
            InitializePresenter();
        }

        private void InitializePresenter()
        {
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
