using System;
using System.Collections.Generic;
using adme360.models.DTOs.Containers;
using adme360.models.DTOs.Devices;
using adme360.models.DTOs.Firmwares;
using adme360.models.DTOs.Simcards;
using adme360.presenter.ViewModel.Containers;
using adme360.presenter.ViewModel.Sensors;
using adme360.presenter.ViewModel.Simcards;
using adme360.suite.ui.Controls;
using adme360.view.Controls.Containers;
using adme360.view.Controls.Firmwares;
using adme360.view.Controls.Sensors.AddEditFlyoutSensor;
using adme360.view.Controls.Simcards;

namespace adme360.suite.ui.Views.FlyOuts.AddEditSensor
{
    public partial class UcFlySensorAddNewEditSensorManagement : BaseModule, 
        IUcFlySensorManagementView, ISimcardsView, IContainersView, IFirmwaresView
    {
        public FlyoutAddEditSensorEventArgs EventArgs { get; }

        private UcFlySensorManagementPresenter _ucFlySensorManagementPresenter;
        private SimcardsPresenter _simcardsPresenter;
        private ContainersPresenter _containersPresenter;


        public UcFlySensorAddNewEditSensorManagement(FlyoutAddEditSensorEventArgs flyoutAddEditEditSensorEventArgs)
        {
            EventArgs = flyoutAddEditEditSensorEventArgs;
            if (EventArgs.SelectedSensorId  != Guid.Empty)
            {
                IsAddMode = false;
                SelectedSensorId = EventArgs.SelectedSensorId;
            }
            else
            {
                IsAddMode = true;
            }

            InitializeComponent();
            InitializePresenters();
        }

        private void InitializePresenters()
        {
            _ucFlySensorManagementPresenter = new UcFlySensorManagementPresenter(this);
            _simcardsPresenter = new SimcardsPresenter(this);
            _containersPresenter = new ContainersPresenter(this);
        }

        #region IUcFlySensorManagementView

        public bool IsAddMode { get; set; }

        public bool GridContainerEnabled
        {
            get => gcContainers.Enabled;
            set => gcContainers.Enabled = value;
        }

        public bool GridFirmwareEnabled
        {
            get => gcFirmwares.Enabled;
            set => gcFirmwares.Enabled = value;
        }

        public bool GridSimcardEnabled
        {
            get => gcSimcards.Enabled;
            set => gcSimcards.Enabled = value;
        }
        public Guid SelectedSensorId { get; set; }

        public bool OnDemandLoadFlyoutSensorManagement
        {
            set
            {
                if (value)
                {
                    _containersPresenter.LoadAllContainersWithoutDevice();
                    if(!IsAddMode)
                        _ucFlySensorManagementPresenter.PopulateSensorDataForModification();
                }
            }
        }
        public bool BtnSensorSaveEnabled { get; set; }
        public bool BtnSensorCancelEnabled { get; set; }
        public DeviceUiModel SelectedSensor { get; set; }

        public bool ChckSensorEnabledEnabled
        {
            get => chckEdtEditSensorEnabled.Enabled;
            set => chckEdtEditSensorEnabled.Enabled = value;
        }

        public bool ChckSensorEnabledValue
        {
            get => (bool)chckEdtEditSensorEnabled.EditValue;
            set => chckEdtEditSensorEnabled.EditValue = value;
        }
        public bool SelectedSensorEnabled { get; set; }
        public bool ChangedSensorEnabled { get; set; }

        public bool ChckSensorContainerEnabled
        {
            get => chckEdtEditSensorWithContainer.Enabled;
            set => chckEdtEditSensorWithContainer.Enabled = value;
        }

        public bool ChckSensorContainerValue
        {
            get => (bool)chckEdtEditSensorWithContainer.EditValue;
            set => chckEdtEditSensorWithContainer.EditValue = value;
        }
        public bool SelectedContainerEnabled { get; set; }
        public bool ChangedContainerEnabled { get; set; }

        public bool ChckSensorSimcardEnabled
        {
            get => chckEdtEditSensorWithSimcard.Enabled;
            set => chckEdtEditSensorWithSimcard.Enabled = value;
        }

        public bool ChckSensorSimcardValue
        {
            get => (bool)chckEdtEditSensorWithSimcard.EditValue;
            set => chckEdtEditSensorWithSimcard.EditValue = value;
        }
        public bool SelectedSimcardEnabled { get; set; }
        public bool ChangedSimcardEnabled { get; set; }

        public bool ChckSensorFirmwareEnabled
        {
            get => chckEdtEditSensorWithFirmware.Enabled;
            set => chckEdtEditSensorWithFirmware.Enabled = value;
        }

        public bool ChckSensorFirmwareValue
        {
            get => (bool)chckEdtEditSensorWithFirmware.EditValue;
            set => chckEdtEditSensorWithFirmware.EditValue = value;
        }
        public bool SelectedFirmwareEnabled { get; set; }
        public bool ChangedFirmwareEnabled { get; set; }

        #endregion

        #region ISimcardsView

        public bool NoneSimcardWasRetrieved { get; set; }
        public List<SimcardUiModel> Simcards { get; set; }

        #endregion

        #region IContainersView

        public bool NoneContainerWasRetrieved { get; set; }

        public List<ContainerUiModel> Containers
        {
            get => (List<ContainerUiModel>) gvContainers.DataSource;
            set => gcContainers.DataSource = value;
        }

        #endregion

        #region IFirmwaresView

        public bool NoneFirmwareWasRetrieved { get; set; }
        public List<FirmwareUiModel> Firmwares { get; set; }

        #endregion

        #region Locals

        private void UcFlySensorAddNewEditSensorManagementLoad(object sender, EventArgs e)
        {
            OnLoaded();
        }

        private void OnLoaded()
        {
            _ucFlySensorManagementPresenter.FlyoutSensorManagementWasLoaded();
        }   
        
        private void ΒtnAddEditSensorSaveClick(object sender, EventArgs e)
        {

        }

        private void ΒtnAddEditSensorCancelClick(object sender, EventArgs e)
        {
            (this.Parent as CustomFlyoutDialog).Close();
        }

        private void TxtAddEditSensorImeiEditValueChanged(object sender, EventArgs e)
        {

        }

        private void TxtAddEditSensorSerialNumberEditValueChanged(object sender, EventArgs e)
        {

        }

        private void BtnAddEditProvisioningCodeClick(object sender, EventArgs e)
        {

        }

        private void ChckEdtEditSensorActivatedEditValueChanged(object sender, EventArgs e)
        {

        }

        private void TxtAddEditSensorActivationCodeEditValueChanged(object sender, EventArgs e)
        {

        }

        private void ChckEdtEditSensorEnabledEditValueChanged(object sender, EventArgs e)
        {

        }

        private void ChckEdtEditSensorWithContainerEditValueChanged(object sender, EventArgs e)
        {

        }

        private void ChckEdtEditSensorWithFirmwareEditValueChanged(object sender, EventArgs e)
        {

        }

        private void ChckEdtEditSensorWithSimcardEditValueChanged(object sender, EventArgs e)
        {

        }

        private void GvContainersFocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {

        }

        private void GvFirmwareFocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {

        }

        private void GvSimcardsFocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {

        }

        private void ChckEdtEditSensorWithContainerCheckedChanged(object sender, EventArgs e)
        {
            _ucFlySensorManagementPresenter.WithContainerWasChecked();
        }

        private void ChckEdtEditSensorWithFirmwareCheckedChanged(object sender, EventArgs e)
        {
            _ucFlySensorManagementPresenter.WithFirmwareWasChecked();
        }

        private void ChckEdtEditSensorWithSimcardCheckedChanged(object sender, EventArgs e)
        {
            _ucFlySensorManagementPresenter.WithSimcardWasChecked();
        }

        private void ChckEdtEditSensorEnabledCheckedChanged(object sender, EventArgs e)
        {
            _ucFlySensorManagementPresenter.EnabledWasChecked();
        }

        private void ChckEdtEditSensorActivatedCheckedChanged(object sender, EventArgs e)
        {
            _ucFlySensorManagementPresenter.ActivatedWasChecked();
        }
        #endregion


    }
}
