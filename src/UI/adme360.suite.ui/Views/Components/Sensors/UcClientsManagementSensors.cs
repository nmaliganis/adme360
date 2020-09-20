using System;
using System.Collections.Generic;
using adme360.suite.ui.Controls;
using adme360.models.DTOs.Devices;
using adme360.presenter.ViewModel.Sensors;
using adme360.view.Controls.Sensors;

namespace adme360.suite.ui.Views.Components.Sensors
{
    public partial class UcClientsManagementSensors : BaseModule, IUcManagementSensorManagementView, IDevicesView
    {
        private DevicesPresenter _devicesPresenter;
        private UcSensorManagementPresenter _ucSensorManagementPresenter;

        public UcClientsManagementSensors()
        {
            InitializeComponent();
            InitializePresenter();
        }

        private void InitializePresenter()
        {
            _ucSensorManagementPresenter = new UcSensorManagementPresenter(this);
            _devicesPresenter = new DevicesPresenter(this);
        }

        private void UcClientsUcContainersLoad(object sender, EventArgs e)
        {
            OnLoaded();
        }

        private void OnLoaded()
        {
            _ucSensorManagementPresenter.UcWasLoaded();
        }

        #region Locals

        private void BtnAddSensorClick(object sender, EventArgs e)
        {
            _ucSensorManagementPresenter.OpenFlyoutForAddSensorWasClicked();
        }

        #endregion

        #region IUcManagementSensorManagementView

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

        public bool OpenFlyoutForAddSensor
        {
            set
            {
                if (value)
                {
                    FlyoutAddEditSensorEventArgs args =
                        new FlyoutAddEditSensorEventArgs("OnAddNewSensor", Guid.Empty);
                    this.OnAddNewEditSensorRequested(args);
                    if (args.IsAccepted)
                    {
                        OnSaveFlyoutSensor();
                    }
                    _devicesPresenter.LoadAllDevices();
                }
            }
        }

        private void OnSaveFlyoutSensor()
        {
            
        }

        public bool OpenFlyoutForEditSensor
        {
            set
            {
                if (value)
                {
                    FlyoutAddEditSensorEventArgs args =
                        new FlyoutAddEditSensorEventArgs("OnEditExistingSensor", SelectedSensorId);
                    this.OnAddNewEditSensorRequested(args);
                    if (args.IsAccepted)
                    {
                        OnSaveFlyoutSensor();
                    }
                    _devicesPresenter.LoadAllDevices();
                }
            }
        }
        public bool RemoveSensorWasCaught { get; set; }

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
