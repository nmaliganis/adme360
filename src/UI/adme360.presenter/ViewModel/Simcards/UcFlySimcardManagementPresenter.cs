using System;
using System.Threading.Tasks;
using adme360.presenter.Base;
using adme360.models.DTOs.Devices;
using adme360.models.DTOs.Simcards;
using adme360.presenter.Exceptions;
using adme360.presenter.ServiceAgents.Contracts;
using adme360.presenter.ServiceAgents.Impls;
using adme360.presenter.Utilities;
using adme360.view.Controls.Simcards.AddEditFlyoutSimcard;

namespace adme360.presenter.ViewModel.Simcards
{
    public class UcFlySimcardManagementPresenter : BasePresenter<IUcFlySimcardManagementView, ISimcardsService>
    {
        private bool _bSimcardIccidValidated = false;
        private bool _bSimcardImsiValidated = false;
        private bool _bSimcardNumberValidated = false;
        private bool _bSimcardPurchaseDateValidated = false;
        private bool _bSimcardEnableStatusValidated = false;
        private bool _bSimcardCountryIsoValidated = false;
        private bool _bSimcardCardTypeValidated = false;
        private bool _bSimcardNetworkTypeValidated = false;
        private bool _bSimcardDeviceValidated = false;

        public UcFlySimcardManagementPresenter(IUcFlySimcardManagementView view)
            : this(view, new SimcardsService())
        {
        }

        public UcFlySimcardManagementPresenter(IUcFlySimcardManagementView view, ISimcardsService service)
            : base(view, service)
        {
        }

        public void FlyoutSimcardManagementWasLoaded()
        {
            View.OnDemandLoadFlyoutSimcardManagement = true;
            PrepareUiCtrlsAfterLoadFlyoutSimcardManagement();
            if (View.SelectedSimcardId == Guid.Empty)
            {
                PrepareUiCtrlsValuesAfterAddSimcardWasSelected();
            }
            else
            {
                PopulateUiCtrlsValuesAfterEditSimcardWasSelected();
            }
        }

        private void PopulateUiCtrlsValuesAfterEditSimcardWasSelected()
        {
            View.BtnSimcardSaveEnabled = false;
            View.BtnSimcardCancelEnabled = true;
        }

        private void PrepareUiCtrlsValuesAfterAddSimcardWasSelected()
        {
            View.SelectedSimcardId = Guid.Empty;

            View.SelectedSimcardIccid = string.Empty;
            View.SelectedSimcardImsi = string.Empty;
            View.SelectedSimcardNumber = string.Empty;

            View.SelectedSimcardPurchaseDateTime = DateTime.Now;
            View.SelectedSimcardEnabledStatus = true;
            View.SelectedSimcardDeviceId = Guid.Empty;

            View.SelectedIndexCountryIsoOfSimcardIsDefault = true;
            View.SelectedIndexCardTypeOfSimcardIsDefault = true;
            View.SelectedIndexNetworkTypeOfSimcardIsDefault = true;
            View.SelectedIndexDeviceOfSimcardIsDefault = true;

            View.TxtSimcardIccidValue = string.Empty;
            View.TxtSimcardImsiValue = string.Empty;
            View.TxtSimcardNumberValue = string.Empty;
            View.DtSimcardPurchaseDateTimeValue = DateTime.Now;
            View.ChckSimcardEnabledStatusValue = true;

            View.OnDemandLoadDevicesWithoutSimLue = true;
        }

        private void PrepareUiCtrlsAfterLoadFlyoutSimcardManagement()
        {
            View.BtnSimcardSaveEnabled = false;
            View.BtnSimcardCancelEnabled = true;

            View.TxtSimcardIccidEnabled  = true;
            View.TxtSimcardImsiEnabled = true;
            View.TxtSimcardNumberEnabled = true;
            
            View.CmbSimcardCountryIsoEnabled = true;
            View.CmbSimcardCardTypeEnabled = true;
            View.CmbSimcardNetworkTypeEnabled = true;
            View.DtSimcardPurchaseDateTimeEnabled = true;
            View.ChckSimcardEnabledStatusEnabled = false;

            View.LueSimcardDeviceEnabled = true;
        }

        public async Task SaveSimcardBtnWasClicked()
        {
            View.ChangedSimcard = new SimcardUiModel();
            PrepareChangedSimcardForSaving();
            if (!CheckIfSimcardCanBeSaved())
            {
                View.OnSimcardSaveMsgError = "Διόρθωση. " + "Συμπληρώστε όλα τα απαραίτητα πεδία";
                return;
            }

            try
            {
                //Create
                if (View.SelectedSimcardId == Guid.Empty)
                {
                    View.CreatedSimcard = await Service.CreateSimcardAsync(View.ChangedSimcard, ClientSettingsSingleton.InstanceSettings().TokenConfigValue);

                    if (View.CreatedSimcard != null)
                        View.OnSuccessSimcardCreation = true;
                }
                //Modify
                else
                {
                    if (!CheckSimcardForValidation())
                        return;
                    View.VerifyForTheSimcardModification = true;
                    if (View.ActionAfterVerifyForTheSimcardModification)
                    {
                        View.ChangedSimcard.Id = View.SelectedSimcardId;
                        View.ModifiedSimcard = await Service.UpdateEntityAsync(View.ChangedSimcard,
                            ClientSettingsSingleton.InstanceSettings().TokenConfigValue);
                        View.OnSuccessSimcardModification = View.ModifiedSimcard != null;
                    }
                }
            }
            catch (Exception e)
            {
                HandleServiceException(e);
            }
        }

        private bool CheckSimcardForValidation()
        {
            return true;
        }

        private void HandleServiceException(Exception e)
        {
            if (e is ServiceHttpRequestException<string>)
            {
                ServiceHttpRequestException<string> ex = (ServiceHttpRequestException<string>) e;

                switch (ex.Content)
                {
                    case "ERROR_SIM_ALREADY_EXISTS":
                        View.OnSimcardSaveMsgError = "H SIM Card υπάρχει ήδη.";
                        break;
                    case "ERROR_SIM_NOT_MADE_PERSISTENT":
                        View.OnSimcardSaveMsgError = "Σφάλμα κατά την αποθήκευση της SIM Card.";
                        break;
                    case "ERROR_SIM_INVALID_MODEL":
                        View.OnSimcardSaveMsgError =
                            "Μη έγκειρα στοιχεία εισαγωγής SIM Card.\nΠαρακαλώ ελέγξτε τα πεδία εισαγωγής σας.";
                        break;
                    case "UNKNOWN_ERROR":
                        View.OnSimcardSaveMsgError = "Σφάλμα απροσδιόριστο.";
                        break;
                    default:
                        View.OnSimcardSaveMsgError =
                            $"Σφάλμα διακομιστή: {ex.HttpStatusCode}\n, Επιπλέον στοιχεία: {ex.Content}";
                        break;
                }
            }
            else
            {
                View.OnSimcardSaveMsgError = "΄Αγνωστο Σφάλμα: " + e.Message;
            }
        }

        private bool CheckIfSimcardCanBeSaved()
        {
            return (
                       !String.IsNullOrEmpty(View.ChangedSimcard.SimcardIccid) &&
                       !String.IsNullOrEmpty(View.ChangedSimcard.SimcardImsi) &&
                       !String.IsNullOrEmpty(View.ChangedSimcard.SimcardNumber))
                ;
        }

        private void PrepareChangedSimcardForSaving()
        {
            View.ChangedSimcard.SimcardIccid = _bSimcardIccidValidated
                ? View.ChangedSimcardIccid
                : View.TxtSimcardIccidValue;

            View.ChangedSimcard.SimcardImsi = _bSimcardIccidValidated
                ? View.ChangedSimcardImsi
                : View.TxtSimcardImsiValue;

            View.ChangedSimcard.SimcardNumber = _bSimcardNumberValidated
                ? View.ChangedSimcardNumber
                : View.TxtSimcardNumberValue;

            View.ChangedSimcard.SimcardPurchaseDate = _bSimcardPurchaseDateValidated
                ? View.ChangedSimcardPurchaseDateTime
                : View.DtSimcardPurchaseDateTimeValue;

            View.ChangedSimcard.SimcardIsEnabled = _bSimcardEnableStatusValidated
                ? View.ChangedSimcardEnabledStatus
                : View.ChckSimcardEnabledStatusValue;

            View.ChangedSimcard.SimcardCountryIso = _bSimcardCountryIsoValidated
                ? View.ChangedSimcardCountryIsoValue
                : View.CmbSimcardCountryIsoValue;

            View.ChangedSimcard.SimcardCardType = _bSimcardCardTypeValidated
                ? View.ChangedSimcardCardTypeValue
                : View.CmbSimcardCardTypeValue;

            View.ChangedSimcard.SimcardNetworkType = _bSimcardNetworkTypeValidated
                ? View.ChangedSimcardNetworkTypeValue
                : View.CmbSimcardNetworkTypeValue;

            if (View.ChangedSimcard.SimcardDevice == null)
            {
                View.ChangedSimcard.SimcardDevice = new DeviceUiModel()
                {
                    Id = _bSimcardDeviceValidated
                        ? View.ChangedSimcardDeviceId
                        : View.SelectedSimcardDeviceId
                };
            }
            else
            {
                View.ChangedSimcard.SimcardDevice.Id = _bSimcardDeviceValidated
                    ? View.ChangedSimcardDeviceId
                    : View.SelectedSimcardDeviceId;
            }
        }

        public void PurchaseDateTimeWasChanged()
        {
            if (View.SelectedSimcardPurchaseDateTime != View.DtSimcardPurchaseDateTimeValue)
            {
                View.ChangedSimcardPurchaseDateTime = View.DtSimcardPurchaseDateTimeValue;
                View.BtnSimcardSaveEnabled = true;
                _bSimcardPurchaseDateValidated = true;
            }
            else
            {
                View.BtnSimcardSaveEnabled = false;
                _bSimcardPurchaseDateValidated = false;
            }
        }

        public void IccidWasChanged()
        {
            if (View.SelectedSimcardIccid != View.TxtSimcardIccidValue)
            {
                View.ChangedSimcardIccid = View.TxtSimcardIccidValue;
                View.BtnSimcardSaveEnabled = true;
                _bSimcardIccidValidated = true;
            }
            else
            {
                View.BtnSimcardSaveEnabled = false;
                _bSimcardIccidValidated = false;
            }
        }

        public void ImsiWasChanged()
        {
            if (View.SelectedSimcardImsi != View.TxtSimcardImsiValue)
            {
                View.ChangedSimcardImsi = View.TxtSimcardImsiValue;
                View.BtnSimcardSaveEnabled = true;
                _bSimcardImsiValidated = true;
            }
            else
            {
                View.BtnSimcardSaveEnabled = false;
                _bSimcardImsiValidated = false;
            }
        }

        public void CountryIsoValueChanged()
        {
            if (View.SelectedSimcardCountryIsoValue != View.CmbSimcardCountryIsoValue)
            {
                View.ChangedSimcardCountryIsoValue = View.CmbSimcardCountryIsoValue;
                View.BtnSimcardSaveEnabled = true;
                _bSimcardCountryIsoValidated = true;
            }
            else
            {
                View.BtnSimcardSaveEnabled = false;
                _bSimcardCountryIsoValidated = false;
            }
        }

        public void NumberWasChanged()
        {
            if (View.SelectedSimcardNumber != View.TxtSimcardNumberValue)
            {
                View.ChangedSimcardNumber = View.TxtSimcardNumberValue;
                View.BtnSimcardSaveEnabled = true;
                _bSimcardNumberValidated = true;
            }
            else
            {
                View.BtnSimcardSaveEnabled = false;
                _bSimcardNumberValidated = false;
            }
        }

        public void DeviceWasChanged()
        {
            if (View.SimcardDevice == null)
            {
                if (View.SelectedSimcardDeviceId == Guid.Empty)
                    return;
                
                View.BtnSimcardSaveEnabled = true;
                _bSimcardDeviceValidated = true;
                return;
            }

            if (View.SimcardDevice != null && View.SelectedSimcardDeviceId != View.SimcardDevice.Id)
            {
                View.ChangedSimcardDeviceId = View.SimcardDevice.Id;
                View.BtnSimcardSaveEnabled = true;
                _bSimcardDeviceValidated = true;
            }
            else
            {
                View.BtnSimcardSaveEnabled = false;
                _bSimcardDeviceValidated = false;
            }
        }

        public void CardTypeValueChanged()
        {
            if (View.SelectedSimcardCardTypeValue != View.CmbSimcardCardTypeValue)
            {
                View.ChangedSimcardCardTypeValue = View.CmbSimcardCardTypeValue;
                View.BtnSimcardSaveEnabled = true;
                _bSimcardCardTypeValidated = true;
            }
            else
            {
                View.BtnSimcardSaveEnabled = false;
                _bSimcardCountryIsoValidated = false;
            }

        }

        public void NetworkTypeValueChanged()
        {
            if (View.SelectedSimcardNetworkTypeValue != View.CmbSimcardNetworkTypeValue)
            {
                View.ChangedSimcardNetworkTypeValue = View.CmbSimcardNetworkTypeValue;
                View.BtnSimcardSaveEnabled = true;
                _bSimcardNetworkTypeValidated = true;
            }
            else
            {
                View.BtnSimcardSaveEnabled = false;
                _bSimcardNetworkTypeValidated = false;
            }
        }

        public async void PopulateSimcardDataForModification()
        {
            View.SelectedSimcard = await Service.GetEntityByIdAsync(View.SelectedSimcardId, ClientSettingsSingleton.InstanceSettings().TokenConfigValue);
            PrepareUiCtrlsAfterSimcardSelection();
        }

        private void PrepareUiCtrlsAfterSimcardSelection()
        {
            
        }

        public void ActionAfterVerifyForTheSimcardCreation()
        {
            if (View.ActionAfterVerifyForTheSimcardCreation)
            {
                PrepareUiCtrlsValuesAfterAddSimcardWasSelected();
                PrepareUiCtrlsAfterLoadFlyoutSimcardManagement();
            }
        }
    }
}
