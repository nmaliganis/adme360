using System;
using System.Collections.Generic;
using adme360.models.DTOs.Devices;
using adme360.presenter.ViewModel.Sensors;
using adme360.suite.ui.Controls;
using adme360.view.Controls.Sensors;

namespace adme360.suite.ui.Views.Components.Sensors
{
    public partial class UcClientsMonitoringSensors : BaseModule, IUcManagementSensorMonitoringView, IDevicesView
    {
        private DevicesPresenter _devicesPresenter;
        private UcSensorMonitoringManagementPresenter _ucSensorMonitoringManagementPresenter;

        public UcClientsMonitoringSensors()
        {
            InitializeComponent();
            InitializePresenter();
        }

        private void InitializePresenter()
        {
            _ucSensorMonitoringManagementPresenter = new UcSensorMonitoringManagementPresenter(this);
            _devicesPresenter = new DevicesPresenter(this);
        }

        private void UcClientsUcContainersLoad(object sender, EventArgs e)
        {
            OnLoaded();
        }

        private void OnLoaded()
        {
            _ucSensorMonitoringManagementPresenter.UcWasLoaded();
        }

        #region IUcManagementSensorMonitoringView

        public Guid SelectedSensorId { get; set; }

        public bool InitialLoadingWasCaught
        {
            set
            {
                if (value)
                {
                    _devicesPresenter.LoadAllDevices();
                }
            }
        }

        #endregion

        #region IDevicesView

        public string OnGeneralMsg { get; set; }

        public List<DeviceUiModel> Devices
        {
            get => (List<DeviceUiModel>) gvSensors.DataSource;
            set => gcSensors.DataSource = value;
        }
        public bool NoneDeviceWasRetrieved { get; set; }

        #endregion
    }
}
