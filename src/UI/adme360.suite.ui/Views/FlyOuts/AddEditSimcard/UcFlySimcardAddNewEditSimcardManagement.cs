using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using adme360.models.DTOs.Devices;
using adme360.models.DTOs.Simcards;
using adme360.presenter.ViewModel.Sensors;
using adme360.presenter.ViewModel.Simcards;
using adme360.suite.ui.Controls;
using adme360.view.Controls.Simcards.AddEditFlyoutSimcard;
using adme360.view.Controls.Sensors;

namespace adme360.suite.ui.Views.FlyOuts.AddEditSimcard
{
    public partial class UcFlySimcardAddNewEditSimcardManagement : BaseModule, IUcFlySimcardManagementView, IDevicesView
    {
        public FlyoutAddEditSimcardEventArgs EventArgs { get; }

        private UcFlySimcardManagementPresenter _ucFlySimcardManagementPresenter;
        private DevicesPresenter _devicesPresenter;

        public UcFlySimcardAddNewEditSimcardManagement(FlyoutAddEditSimcardEventArgs flyoutAddEditEditSimcardEventArgs)
        {
            EventArgs = flyoutAddEditEditSimcardEventArgs;
            if (EventArgs.SelectedSimcardId != Guid.Empty)
            {
                IsAddMode = false;
                SelectedSimcardId = EventArgs.SelectedSimcardId;
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
            _ucFlySimcardManagementPresenter = new UcFlySimcardManagementPresenter(this);
            _devicesPresenter = new DevicesPresenter(this);
        }

        #region IUcFlySimcardManagementView

        public bool IsAddMode { get; set; }

        public bool TxtSimcardIccidEnabled
        {
            get => txtAddEditSimcardIccid.Enabled;
            set => txtAddEditSimcardIccid.Enabled = value;
        }

        public string TxtSimcardIccidValue
        {
            get => txtAddEditSimcardIccid.Text;
            set => txtAddEditSimcardIccid.Text = value;
        }
        public string SelectedSimcardIccid { get; set; }
        public string ChangedSimcardIccid { get; set; }

        public bool TxtSimcardImsiEnabled
        {
            get => txtAddEditSimcardImsi.Enabled;
            set => txtAddEditSimcardImsi.Enabled = value;
        }

        public string TxtSimcardImsiValue
        {
            get => txtAddEditSimcardImsi.Text;
            set => txtAddEditSimcardImsi.Text = value;
        }
        public string SelectedSimcardImsi { get; set; }
        public string ChangedSimcardImsi { get; set; }

        public bool TxtSimcardNumberEnabled
        {
            get => txtAddEditSimcardNumber.Enabled;
            set => txtAddEditSimcardNumber.Enabled = value;
        }

        public string TxtSimcardNumberValue
        {
            get => txtAddEditSimcardNumber.Text;
            set => txtAddEditSimcardNumber.Text = value;
        }
        public string SelectedSimcardNumber { get; set; }
        public string ChangedSimcardNumber { get; set; }

        public bool LueSimcardDeviceEnabled
        {
            get => lueAddEditSimcardDevice.Enabled;
            set => lueAddEditSimcardDevice.Enabled = value;
        }

        #region LueDevice

        public Guid LueSimcardDeviceValue { get; set; }
        public Guid SelectedSimcardDeviceId { get; set; }
        public Guid PreviousSelectedSimcardDeviceId { get; set; }

        public DeviceUiModel SimcardDevice
        {
            get => (DeviceUiModel)lueAddEditSimcardDevice.EditValue;
            set
            {
                lueAddEditSimcardDevice.EditValue = value;
                lueAddEditSimcardDevice.ItemIndex = PopulateLueDevicesWithSelectedDevice(value);
            }
        }

        private int PopulateLueDevicesWithSelectedDevice(DeviceUiModel focusedDevice)
        {
            if (lueAddEditSimcardDevice.Properties.DataSource == null)
            {
                return -1;
            }
            var deviceUiModels = (List<DeviceUiModel>)lueAddEditSimcardDevice.Properties.DataSource;
            for (var i = 0; i < deviceUiModels.Count; i++)
            {
                if (deviceUiModels[i].Id == focusedDevice.Id)
                {
                    return i;
                }
            }
            return -1;
        }


        public bool SelectedIndexDeviceOfSimcardIsDefault
        {
            set
            {
                if (value)
                    lueAddEditSimcardDevice.EditValue = null;
            }
        }

        public bool SelectedIndexDeviceOfSimcardIsFirstIndex
        {
            set
            {
                if (value)
                    lueAddEditSimcardDevice.ItemIndex = 0;
            }
        }

        public bool SelectedIndexDeviceOfSimcardIsCustom
        {
            set
            {
                if (value)
                    lueAddEditSimcardDevice.ItemIndex =
                        PopulateLueDeviceWithSelectedDevice(SelectedSimcardDeviceId);
            }
        }

        private int PopulateLueDeviceWithSelectedDevice(Guid focusedDeviceId)
        {
            if (lueAddEditSimcardDevice.Properties.DataSource == null)
            {
                return -1;
            }
            var deviceUiModels = (List<DeviceUiModel>)lueAddEditSimcardDevice.Properties.DataSource;
            for (var i = 0; i < deviceUiModels.Count; i++)
            {
                if (deviceUiModels[i].Id == focusedDeviceId)
                {
                    return i;
                }
            }
            return -1;
        }

        public Guid ChangedSimcardDeviceId { get; set; }

        #endregion

        public bool CmbSimcardCountryIsoEnabled
        {
            get => imgCmbBxEdtSimcardCountryIso.Enabled;
            set => imgCmbBxEdtSimcardCountryIso.Enabled = value;
        }
        public int SimcardCountryIso { get; set; }

        public bool SelectedIndexCountryIsoOfSimcardIsDefault
        {
            set
            {
                if (value)
                    imgCmbBxEdtSimcardCountryIso.SelectedIndex = 0;
            }
        }
        public bool SelectedIndexCountryIsoOfSimcardIsFirstIndex { get; set; }
        public bool SelectedIndexCountryIsoOfSimcardIsCustom { get; set; }

        public string CmbSimcardCountryIsoValue
        {
            get => (string)((ImageComboBoxItem)imgCmbBxEdtSimcardCountryIso.SelectedItem).Value;
            set
            {
                if (value != string.Empty)
                    imgCmbBxEdtSimcardCountryIso.SelectedIndex =
                        PopulateCmbSimcardCountryIsoWithSelectedSimcardCountryIso(value);
            }
        }

        private int PopulateCmbSimcardCountryIsoWithSelectedSimcardCountryIso(string selectedSimcardCountryIso)
        {
            if (imgCmbBxEdtSimcardCountryIso.Properties.Items == null)
            {
                return -1;
            }
            var simcardCountryIsos= imgCmbBxEdtSimcardCountryIso.Properties.Items;
            for (var i = 0; i < simcardCountryIsos.Count; i++)
            {
                if ((string)simcardCountryIsos[i].Value == selectedSimcardCountryIso)
                {
                    return i;
                }
            }
            return -1; 
        }

        public string SelectedSimcardCountryIsoValue { get; set; }
        public string ChangedSimcardCountryIsoValue { get; set; }

        public bool CmbSimcardCardTypeEnabled
        {
            get => imgCmbBxEdtSimcardCartType.Enabled;
            set => imgCmbBxEdtSimcardCartType.Enabled = value;
        }
        public int SimcardCardType { get; set; }

        public bool SelectedIndexCardTypeOfSimcardIsDefault
        {
            set
            {
                if (value)
                    imgCmbBxEdtSimcardCartType.SelectedIndex = 0;
            }
        }
        public bool SelectedIndexCardTypeOfSimcardIsFirstIndex { get; set; }
        public bool SelectedIndexCardTypeOfSimcardIsCustom { get; set; }

        public int CmbSimcardCardTypeValue
        {
            get => (int)((ImageComboBoxItem)imgCmbBxEdtSimcardCartType.SelectedItem).Value;
            set
            {
                if (value != 0)
                    imgCmbBxEdtSimcardCartType.SelectedIndex =
                        PopulateCmbSimcardCardTypeWithSelectedSimcardCardType(value);
            }
        }

        private int PopulateCmbSimcardCardTypeWithSelectedSimcardCardType(int selectedSimcardCardType)
        {
            if (imgCmbBxEdtSimcardCartType.Properties.Items == null)
            {
                return -1;
            }
            var simcardCardTypes= imgCmbBxEdtSimcardCartType.Properties.Items;
            for (var i = 0; i < simcardCardTypes.Count; i++)
            {
                if ((int)simcardCardTypes[i].Value == selectedSimcardCardType)
                {
                    return i;
                }
            }
            return -1; 
        }

        public int SelectedSimcardCardTypeValue { get; set; }
        public int ChangedSimcardCardTypeValue { get; set; }

        public bool CmbSimcardNetworkTypeEnabled
        {
            get => imgCmbBxEdtSimcardNetworkType.Enabled;
            set => imgCmbBxEdtSimcardNetworkType.Enabled = value;
        }
        public int SimcardNetworkType { get; set; }

        public bool SelectedIndexNetworkTypeOfSimcardIsDefault
        {
            set
            {
                if (value)
                    imgCmbBxEdtSimcardNetworkType.SelectedIndex = 0;
            }
        }
        public bool SelectedIndexNetworkTypeOfSimcardIsFirstIndex { get; set; }
        public bool SelectedIndexNetworkTypeOfSimcardIsCustom { get; set; }

        public int CmbSimcardNetworkTypeValue
        {
            get => (int)((ImageComboBoxItem)imgCmbBxEdtSimcardNetworkType.SelectedItem).Value;
            set
            {
                if (value != 0)
                    imgCmbBxEdtSimcardNetworkType.SelectedIndex =
                        PopulateCmbSimcardNetworkTypeWithSelectedSimcardNetworkType(value);
            }
        }

        private int PopulateCmbSimcardNetworkTypeWithSelectedSimcardNetworkType(int selectedSimcardNetworkType)
        {
            if (imgCmbBxEdtSimcardNetworkType.Properties.Items == null)
            {
                return -1;
            }
            var simcardNetworkTypes= imgCmbBxEdtSimcardNetworkType.Properties.Items;
            for (var i = 0; i < simcardNetworkTypes.Count; i++)
            {
                if ((int)simcardNetworkTypes[i].Value == selectedSimcardNetworkType)
                {
                    return i;
                }
            }
            return -1; 
        }

        public int SelectedSimcardNetworkTypeValue { get; set; }
        public int ChangedSimcardNetworkTypeValue { get; set; }

        public bool ChckSimcardEnabledStatusEnabled
        {
            get => chckEdtSimcardIsEnabled.Enabled;
            set => chckEdtSimcardIsEnabled.Enabled = value;
        }

        public bool ChckSimcardEnabledStatusValue
        {
            get => (bool)chckEdtSimcardIsEnabled.EditValue;
            set => chckEdtSimcardIsEnabled.EditValue = value;
        }
        public bool SelectedSimcardEnabledStatus { get; set; }
        public bool ChangedSimcardEnabledStatus { get; set; }

        public bool DtSimcardPurchaseDateTimeEnabled
        {
            get => dtEdtSimcardPurchaseDate.Enabled;
            set => dtEdtSimcardPurchaseDate.Enabled = value;
        }

        public DateTime DtSimcardPurchaseDateTimeValue
        {
            get => (DateTime)dtEdtSimcardPurchaseDate.EditValue;
            set => dtEdtSimcardPurchaseDate.EditValue = value;
        }
        public DateTime SelectedSimcardPurchaseDateTime { get; set; }
        public DateTime ChangedSimcardPurchaseDateTime { get; set; }

        public SimcardUiModel ChangedSimcard { get; set; }
        public Guid SelectedSimcardId { get; set; }

        public bool OnSuccessSimcardCreation
        {
            set
            {
                if (value)
                {
                    Thread.Sleep(200);
                    var iResult = XtraMessageBox.Show("Η δημιουργία μιας νέας SIM Card ολοκληρώθηκε με επιτυχία",
                        "Δημιουργία SIM Card",
                        MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                    ActionAfterVerifyForTheSimcardCreation = iResult == DialogResult.OK;
                    _ucFlySimcardManagementPresenter.ActionAfterVerifyForTheSimcardCreation();
                }
            }
        }
        public bool ActionAfterVerifyForTheSimcardCreation { get; set; }
        public bool VerifyForTheSimcardModification { get; set; }
        public bool ActionAfterVerifyForTheSimcardModification { get; set; }

        public string OnSimcardSaveMsgError
        {
            set =>
                XtraMessageBox.Show(value,
                    "Λάθος εκτέλεση",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public bool OnSuccessSimcardModification { get; set; }

        public bool BtnSimcardSaveEnabled
        {
            get => btnAddEditSimcardSave.Enabled;
            set => btnAddEditSimcardSave.Enabled = value;
        }

        public bool BtnSimcardCancelEnabled
        {
            get => btnAddEditSimcardCancel.Enabled;
            set => btnAddEditSimcardCancel.Enabled = value;
        }

        public bool OnDemandLoadDevicesWithoutSimLue
        {
            set
            {
                if (value)
                {
                    _devicesPresenter.LoadAllDevicesWithoutSimcard();
                }
            }
        }

        public bool OnDemandLoadFlyoutSimcardManagement
        {
            set
            {
                if (value)
                {
                    if(!IsAddMode)
                        _ucFlySimcardManagementPresenter.PopulateSimcardDataForModification();
                }
            }
        }

        public SimcardUiModel SelectedSimcard { get; set; }
        public SimcardUiModel ModifiedSimcard { get; set; }
        public SimcardUiModel CreatedSimcard { get; set; }

        #endregion

        #region Locals
        private void UcFlySimcardAddNewEditSimcardManagementLoad(object sender, EventArgs e)
        {
            _ucFlySimcardManagementPresenter.FlyoutSimcardManagementWasLoaded();
        }

        private void BtnAddEditSimcardSaveClick(object sender, EventArgs e)
        {
            _ucFlySimcardManagementPresenter.SaveSimcardBtnWasClicked();
        }

        private void BtnAddEditSimcardCancelClick(object sender, EventArgs e)
        {
            (this.Parent as CustomFlyoutDialog).Close();
        }
        private void ImgCmbBxEdtSimcardNetworkTypeEditValueChanged(object sender, EventArgs e)
        {
            _ucFlySimcardManagementPresenter.NetworkTypeValueChanged();
        }

        private void ImgCmbBxEdtSimcardCartTypeEditValueChanged(object sender, EventArgs e)
        {
            _ucFlySimcardManagementPresenter.CardTypeValueChanged();
        }

        private void DtEdtSimcardPurchaseDateEditValueChanged(object sender, EventArgs e)
        {
            _ucFlySimcardManagementPresenter.PurchaseDateTimeWasChanged();
        }

        private void LueAddEditSimcardDeviceEditValueChanged(object sender, EventArgs e)
        {
            _ucFlySimcardManagementPresenter.DeviceWasChanged();
        }

        private void TxtAddEditSimcardNumberEditValueChanged(object sender, EventArgs e)
        {
            _ucFlySimcardManagementPresenter.NumberWasChanged();
        }

        private void ImgCmbBxEdtSimcardCountryIsoEditValueChanged(object sender, EventArgs e)
        {
            _ucFlySimcardManagementPresenter.CountryIsoValueChanged();
        }

        private void TxtAddEditSimcardImsiEditValueChanged(object sender, EventArgs e)
        {
            _ucFlySimcardManagementPresenter.ImsiWasChanged();
        }

        private void TxtAddEditSimcardIccidEditValueChanged(object sender, EventArgs e)
        {
            _ucFlySimcardManagementPresenter.IccidWasChanged();
        }
        #endregion


        #region IDevicesView

        public string OnGeneralMsg { get; set; }

        public List<DeviceUiModel> Devices
        {
            get => (List<DeviceUiModel>) lueAddEditSimcardDevice.Properties.DataSource;
            set => lueAddEditSimcardDevice.Properties.DataSource = value;
        }
        public bool NoneDeviceWasRetrieved { get; set; }

        #endregion


    }
}
