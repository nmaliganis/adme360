using System;
using dl.wm.models.DTOs.Trackables;
using dl.wm.presenter.ServiceAgents.Contracts;
using dl.wm.presenter.ServiceAgents.Impls;
using dl.wm.presenter.Utilities;
using dl.wm.view.Controls.Trackables;
using dl.wm.presenter.Base;
using dl.wm.presenter.Exceptions;
using dl.wm.presenter.Helpers;

namespace dl.wm.presenter.ViewModel.Trackables
{
    public class TrackableManagementPresenter : BasePresenter<ITrackableManagementView, ITrackablesService>
    {
        private bool _bTrackableNameValidated;
        private bool _bTrackableModelValidated;
        private bool _bTrackableVendorIdValidated;
        private bool _bTrackableOsValidated;
        private bool _bTrackablePhoneValidated;
        private bool _bTrackableVersionValidated;
        private bool _bTrackableNotesValidated;

        private readonly string _role = string.Empty;

        public TrackableManagementPresenter(ITrackableManagementView view)
            : this(view, new TrackablesService())
        {
        }

        public TrackableManagementPresenter(ITrackableManagementView view, ITrackablesService service)
            : base(view, service)
        {
            _role = JwtHelper.ExtractRoleFromToken(ClientSettingsSingleton.InstanceSettings().TokenConfigValue);
        }

        public void UcLoadedOnDemand()
        {
            View.UcWasLoadedOnDemand = true;
            PopulateCtrlsOnLoadingWithRole();
        }

        private void PopulateCtrlsOnLoadingWithRole()
        {
            if (_role == "SU" || _role == "ADMIN")
            {
                PrepareUiAfterTrackableSelection();
            }
            else
            {
                View.BtnTrackableAddEnabled = false;
                View.BtnTrackableCancelEnabled = false;
                View.BtnTrackableDeleteEnabled = false;
                View.BtnTrackableSaveEnabled = false;                
            }
        }

        private void PrepareUiAfterTrackableSelection()
        {
            View.BtnTrackableAddEnabled = true;
            View.BtnTrackableDeleteEnabled = true;
            View.BtnTrackableCancelEnabled = false;
            View.BtnTrackableSaveEnabled = false;

            View.TxtTrackableNameEnabled = true;
            View.TxtTrackableVendorIdEnabled = true;
            View.TxtTrackableModelEnabled = true;
            View.TxtTrackablePhoneEnabled = true;
            View.TxtTrackableVersionEnabled = true;
            View.TxtTrackableOsEnabled = true;
            View.TxtTrackableNotesEnabled = true;
        }

        public void TrackableFromGridWasSelected()
        {
            PopulateTrackableDataAfterTrackableSelection();

            if (_role == "SU" || _role == "ADMIN")
            {
                PrepareUiAfterTrackableSelection();
            }
            else
            {
                View.BtnTrackableAddEnabled = false;
                View.BtnTrackableDeleteEnabled = false;
                View.BtnTrackableCancelEnabled = false;
                View.BtnTrackableSaveEnabled = false;         
            }
        }

        private async  void PopulateTrackableDataAfterTrackableSelection()
        {
            if(View.SelectedTrackableId == Guid.Empty)
                return;

            View.SelectedTrackable = await Service.GetEntityByIdAsync(View.SelectedTrackableId, ClientSettingsSingleton.InstanceSettings().TokenConfigValue);
            PrepareUiCtrlsAfterTrackableSelection();
        }

        private void PrepareUiCtrlsAfterTrackableSelection()
        {
            View.TxtTrackableNameValue = View.SelectedTrackable?.TrackableName;
            View.TxtTrackableModelValue = View.SelectedTrackable?.TrackableModel;
            View.TxtTrackableVendorIdValue = View.SelectedTrackable?.TrackableVendorId;
            View.TxtTrackableVersionValue = View.SelectedTrackable?.TrackableVersion;
            View.TxtTrackableOsValue = View.SelectedTrackable?.TrackableOs;
            View.TxtTrackablePhoneValue = View.SelectedTrackable?.TrackablePhone;
            View.TxtTrackableNotesValue = View.SelectedTrackable?.TrackableNotes;
        }

        public void NewTrackableBtnWasClicked()
        {
            PrepareUiAfterNewTrackableSelection();
            PrepareUiCtrlsAfterNewTrackableSelection();
        }

        private void PrepareUiCtrlsAfterNewTrackableSelection()
        {
            View.PreviousSelectedTrackableId = View.SelectedTrackableId;
            View.SelectedTrackableId = Guid.Empty;
            View.SelectedTrackableName = string.Empty;
            View.SelectedTrackableModel = string.Empty;
            View.SelectedTrackableVendorId = string.Empty;
            View.SelectedTrackableVersion = string.Empty;
            View.SelectedTrackableOs = string.Empty;
            View.SelectedTrackablePhone = string.Empty;
            View.SelectedTrackableNotes = string.Empty;

            View.TxtTrackableNameValue = string.Empty;
            View.TxtTrackableModelValue = string.Empty;
            View.TxtTrackableVendorIdValue = string.Empty;
            View.TxtTrackableVersionValue = string.Empty;
            View.TxtTrackableOsValue = string.Empty;
            View.TxtTrackablePhoneValue = string.Empty;
            View.TxtTrackableNotesValue = string.Empty;
        }

        private void PrepareUiAfterNewTrackableSelection()
        {
            View.BtnTrackableAddEnabled = false;
            View.BtnTrackableDeleteEnabled = false;
            View.BtnTrackableCancelEnabled = true;
            View.BtnTrackableSaveEnabled = false;

            View.TxtTrackableNameEnabled = true;
            View.TxtTrackableModelEnabled = true;
            View.TxtTrackableVendorIdEnabled = true;
            View.TxtTrackableVersionEnabled = true;
            View.TxtTrackablePhoneEnabled = true;
            View.TxtTrackableOsEnabled = true;
            View.TxtTrackableNotesEnabled = true;
        }

        #region Cancel

        public void CancelTrackableBtnWasClicked()
        {
            PrepareUiAfterCancelTrackableSelection();
            PrepareUiCtrlsAfterCancelTrackableSelection();
        }

        private void PrepareUiCtrlsAfterCancelTrackableSelection()
        {
            View.SelectedTrackableId = View.PreviousSelectedTrackableId;
            PopulateTrackableDataAfterTrackableSelection();
        }

        private void PrepareUiAfterCancelTrackableSelection()
        {
            View.BtnTrackableAddEnabled = true;
            View.BtnTrackableDeleteEnabled = false;
            View.BtnTrackableCancelEnabled = false;
            View.BtnTrackableSaveEnabled = false;

            View.TxtTrackableNameEnabled = true;
            View.TxtTrackableModelEnabled = true;
            View.TxtTrackableVendorIdEnabled = true;
            View.TxtTrackableVersionEnabled = true;
            View.TxtTrackablePhoneEnabled = true;
            View.TxtTrackableOsEnabled = true;
            View.TxtTrackableNotesEnabled = true;
        }

        #endregion

        #region Delete

        public void RemoveTrackableBtnWasClicked()
        {
            
        }

        #endregion



        #region For Create - Edit (POST - PUT) Trackable Was Clicked - Cmd

        public async void SaveTrackableBtnWasClicked()
        {
            View.ChangedTrackable = new TrackableUiModel();
            PrepareChangedTrackableForSaving();

            if (!CheckIfTrackableCanBeSaved())
            {
                View.OnTrackableSaveMsgError = "Διόρθωση. Συμπληρώστε τα απαραίτητα πεδία.";
                return;
            }

            try
            {
                //Create
                if (View.SelectedTrackableId == Guid.Empty)
                {
                    View.CreatedTrackable = await Service.CreateTrackableAsync(View.ChangedTrackable, ClientSettingsSingleton.InstanceSettings().TokenConfigValue);

                    if (View.CreatedTrackable != null)
                        View.OnSuccessTrackableCreation = true;
                    else
                        View.OnTrackableSaveMsgError = "Σφάλμα κατά την αποθήκευση του Συσκευής Απαρριμματοφόρου.";
                }
                //Modify
                else
                {
                    if (!CheckTrackableForValidation())
                        return;
                    View.VerifyForTheTrackableModification = true;
                    if (View.ActionAfterVerifyForTheTrackableModification)
                    {
                        View.ChangedTrackable.Id = View.SelectedTrackableId;
                        View.ModifiedTrackable = await Service.UpdateTrackableAsync(View.ChangedTrackable, ClientSettingsSingleton.InstanceSettings().TokenConfigValue);
                        View.OnSuccessTrackableModification = View.ModifiedTrackable != null;
                    }
                }
            }
            catch (Exception e)
            {
                HandleServiceException(e);
            }
        }

        private bool CheckTrackableForValidation()
        {
            return true;
        }

        private bool CheckIfTrackableCanBeSaved()
        {
            return (!String.IsNullOrEmpty(View.ChangedTrackable.TrackableName) 
                    && (!String.IsNullOrEmpty(View.ChangedTrackable.TrackableVendorId)) 
                    && (!String.IsNullOrEmpty(View.ChangedTrackable.TrackablePhone)) 
                    && (!String.IsNullOrEmpty(View.ChangedTrackable.TrackableModel)) 
                    && (!String.IsNullOrEmpty(View.ChangedTrackable.TrackableOs)) 
                    && (!String.IsNullOrEmpty(View.ChangedTrackable.TrackableVersion)) 
                );
        }

        private void PrepareChangedTrackableForSaving()
        {
            View.ChangedTrackable.TrackableName = _bTrackableNameValidated
                ? View.ChangedTrackableName
                : View.SelectedTrackableName;
            View.ChangedTrackable.TrackableModel = _bTrackableModelValidated
                ? View.ChangedTrackableModel
                : View.SelectedTrackableModel;
            View.ChangedTrackable.TrackableVendorId = _bTrackableVendorIdValidated
                ? View.ChangedTrackableVendorId
                : View.SelectedTrackableVendorId;
            View.ChangedTrackable.TrackableVersion = _bTrackableVersionValidated
                ? View.ChangedTrackableVersion
                : View.SelectedTrackableVersion;
            View.ChangedTrackable.TrackableOs = _bTrackableOsValidated
                ? View.ChangedTrackableOs
                : View.SelectedTrackableOs;
            View.ChangedTrackable.TrackablePhone = _bTrackablePhoneValidated
                ? View.ChangedTrackablePhone
                : View.SelectedTrackablePhone;
            View.ChangedTrackable.TrackableVersion = _bTrackableVersionValidated
                ? View.ChangedTrackableVersion
                : View.SelectedTrackableVersion;
        }

        private void HandleServiceException(Exception e)
        {
            if (e is ServiceHttpRequestException<string>)
            {
                ServiceHttpRequestException<string> ex = (ServiceHttpRequestException<string>) e;

                switch (ex.Content)
                {
                    case "NAME_ALREADY_EXISTS":
                        View.OnTrackableSaveMsgError = "Το όνομα Συσκευής Απαρριμματοφόρου υπάρχει ήδη.\nΠαρακαλώ ελέγξτε τα πεδία εισαγωγής σας.";
                        break;
                    case "VENDOR_ID_ALREADY_EXISTS":
                        View.OnTrackableSaveMsgError = "Ο κωδικός Συσκευής Απαρριμματοφόρου υπάρχει ήδη.\nΠαρακαλώ ελέγξτε τα πεδία εισαγωγής σας.";
                        break;
                    case "PHONE_ALREADY_EXISTS":
                        View.OnTrackableSaveMsgError = "Ο αριθμός τηλ. Συσκευής Απαρριμματοφόρου υπάρχει ήδη.\nΠαρακαλώ ελέγξτε τα πεδία εισαγωγής σας.";
                        break;
                    case "ERROR_TRACKABLE_ALREADY_EXISTS":
                        View.OnTrackableSaveMsgError = "Η Συσκευή Απαρριμματοφόρου  πάρχει ήδη.";
                        break;
                    case "ERROR_TRACKABLE_NOT_MADE_PERSISTENT":
                        View.OnTrackableSaveMsgError = "Σφάλμα κατά την αποθήκευση του Συσκευής Απαρριμματοφόρου.";
                        break;
                    case "ERROR_TRACKABLE_INVALID_MODEL":
                        View.OnTrackableSaveMsgError = "Μη έγκειρα στοιχεία εισαγωγής Συσκευής Απαρριμματοφόρου.\nΠαρακαλώ ελέγξτε τα πεδία εισαγωγής σας.";
                        break;
                    case "UNKNOWN_ERROR":
                        View.OnTrackableSaveMsgError = "Σφάλμα απροσδιόριστο.";
                        break;
                    default:
                        View.OnTrackableSaveMsgError =
                            $"Σφάλμα διακομιστή: {ex.HttpStatusCode}\n, Επιπλέον στοιχεία: {ex.Content}";
                        break;
                }
            }
            else
            {
                View.OnTrackableSaveMsgError = "΄Αγνωστο Σφάλμα: " + e.Message;
            }
        }

        #endregion

        public void TrackableNameValueWasChanged()
        {
            if (View.SelectedTrackableName != View.TxtTrackableNameValue)
            {
                View.ChangedTrackableName = View.TxtTrackableNameValue;
                View.BtnTrackableSaveEnabled = true;
                _bTrackableNameValidated = true;
            }
            else
            {
                View.BtnTrackableSaveEnabled = false;
                _bTrackableNameValidated = false;
            }
        }

        public void TrackableModelValueWasChanged()
        {
            if (View.SelectedTrackableModel != View.TxtTrackableModelValue)
            {
                View.ChangedTrackableModel = View.TxtTrackableModelValue;
                View.BtnTrackableSaveEnabled = true;
                _bTrackableModelValidated = true;
            }
            else
            {
                View.BtnTrackableSaveEnabled = false;
                _bTrackableModelValidated = false;
            }
        }


        public void TrackableVendorIdValueWasChanged()
        {
            if (View.SelectedTrackableVendorId != View.TxtTrackableVendorIdValue)
            {
                View.ChangedTrackableVendorId = View.TxtTrackableVendorIdValue;
                View.BtnTrackableSaveEnabled = true;
                _bTrackableVendorIdValidated = true;
            }
            else
            {
                View.BtnTrackableSaveEnabled = false;
                _bTrackableVendorIdValidated = false;
            }
        }

        public void TrackablePhoneValueWasChanged()
        {
            if (View.SelectedTrackablePhone != View.TxtTrackablePhoneValue)
            {
                View.ChangedTrackablePhone = View.TxtTrackablePhoneValue;
                View.BtnTrackableSaveEnabled = true;
                _bTrackablePhoneValidated = true;
            }
            else
            {
                View.BtnTrackableSaveEnabled = false;
                _bTrackablePhoneValidated = false;
            }
        }

        public void TrackableOsValueWasChanged()
        {
            if (View.SelectedTrackableOs != View.TxtTrackableOsValue)
            {
                View.ChangedTrackableOs = View.TxtTrackableOsValue;
                View.BtnTrackableSaveEnabled = true;
                _bTrackableOsValidated = true;
            }
            else
            {
                View.BtnTrackableSaveEnabled = false;
                _bTrackableOsValidated = false;
            }
        }

        public void TrackableVersionValueWasChanged()
        {
            if (View.SelectedTrackableVersion != View.TxtTrackableVersionValue)
            {
                View.ChangedTrackableVersion = View.TxtTrackableVersionValue;
                View.BtnTrackableSaveEnabled = true;
                _bTrackableVersionValidated = true;
            }
            else
            {
                View.BtnTrackableSaveEnabled = false;
                _bTrackableVersionValidated = false;
            }
        }

        public void TrackableNotesValueWasChanged()
        {
            if (View.SelectedTrackableNotes != View.TxtTrackableNotesValue)
            {
                View.ChangedTrackableNotes = View.TxtTrackableNotesValue;
                View.BtnTrackableSaveEnabled = true;
                _bTrackableNotesValidated = true;
            }
            else
            {
                View.BtnTrackableSaveEnabled = false;
                _bTrackableNotesValidated = false;
            }
        }
    }
}
