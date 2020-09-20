using System;
using adme360.presenter.Base;
using adme360.models.DTOs.Employees.EmployeeRoles;
using adme360.presenter.Exceptions;
using adme360.presenter.Helpers;
using adme360.presenter.ServiceAgents.Contracts;
using adme360.presenter.ServiceAgents.Impls;
using adme360.presenter.Utilities;
using adme360.view.Controls.Employees.EmployeeRoles;

namespace adme360.presenter.ViewModel.Employees.EmployeeRoles
{
    public class EmployeeRoleManagementPresenter : BasePresenter<IEmployeeRoleManagementView, IEmployeeRolesService>
    {
        private bool _bEmployeeRoleNameValidated;
        private bool _bEmployeeRoleNotesValidated;

        public EmployeeRoleManagementPresenter(IEmployeeRoleManagementView view)
            : this(view, new EmployeeRolesService())
        {
        }

        public EmployeeRoleManagementPresenter(IEmployeeRoleManagementView view, IEmployeeRolesService service)
            : base(view, service)
        {
        }

        public void UcWasLoaded()
        {
            View.UcWasLoadedOnDemand = true;
            PopulateCtrlsOnLoadingWithRole();
        }

        private void PopulateCtrlsOnLoadingWithRole()
        {
            var role = JwtHelper.ExtractRoleFromToken(ClientSettingsSingleton.InstanceSettings().TokenConfigValue);

            if (role != "SU" || role != "ADMIN")
            {
                View.BtnEmployeeRoleAddEnabled = false;
                View.BtnEmployeeRoleCancelEnabled = false;
                View.BtnEmployeeRoleDeleteEnabled = false;
                View.BtnEmployeeRoleSaveEnabled = false;
            }
        }

        #region Grid-Selection

        public void EmployeeRoleFromGridWasSelected()
        {
            if ((int) View.SelectedEmployeeRoleType < 4)
            {
                PrepareUiAfterEmployeeRoleSelectionWithNoDeletableRole();
            }
            else
            {
                PrepareUiAfterEmployeeRoleSelection();
            }

            PopulateEmployeeRoleDataAfterEmployeeRoleSelection();
        }

        private void PrepareUiAfterEmployeeRoleSelectionWithNoDeletableRole()
        {
            View.BtnEmployeeRoleAddEnabled = true;
            View.BtnEmployeeRoleDeleteEnabled = false;
            View.BtnEmployeeRoleCancelEnabled = false;
            View.BtnEmployeeRoleSaveEnabled = false;

            View.TxtEmployeeRoleNameEnabled = false;
            View.TxtEmployeeRoleNotesEnabled = false;
        }

        private async void PopulateEmployeeRoleDataAfterEmployeeRoleSelection()
        {
            if(View.SelectedEmployeeRoleId == Guid.Empty)
                return;

            View.SelectedEmployeeRole = await Service.GetEntityByIdAsync(View.SelectedEmployeeRoleId, ClientSettingsSingleton.InstanceSettings().TokenConfigValue);
            PrepareUiCtrlsAfterEmployeeRoleSelection();
        }

        private void PrepareUiCtrlsAfterEmployeeRoleSelection()
        {
            View.TxtEmployeeRoleNameValue = View.SelectedEmployeeRole?.Name;
            View.TxtEmployeeRoleNotesValue = View.SelectedEmployeeRole?.Notes;
        }

        private void PrepareUiAfterEmployeeRoleSelection()
        {
            View.BtnEmployeeRoleAddEnabled = true;
            View.BtnEmployeeRoleDeleteEnabled = true;
            View.BtnEmployeeRoleCancelEnabled = false;
            View.BtnEmployeeRoleSaveEnabled = false;

            View.TxtEmployeeRoleNameEnabled = true;
            View.TxtEmployeeRoleNotesEnabled = true;
        }

        #endregion

        #region Add

        public void NewEmployeeRoleBtnWasClicked()
        {
            PrepareUiAfterNewEmployeeRoleSelection();
            PrepareUiCtrlsAfterNewEmployeeRoleSelection();
        }

        private void PrepareUiAfterNewEmployeeRoleSelection()
        {
            View.BtnEmployeeRoleAddEnabled = false;
            View.BtnEmployeeRoleDeleteEnabled = false;
            View.BtnEmployeeRoleCancelEnabled = true;
            View.BtnEmployeeRoleSaveEnabled = false;

            View.TxtEmployeeRoleNameEnabled = true;
            View.TxtEmployeeRoleNotesEnabled = true;
        }

        private void PrepareUiCtrlsAfterNewEmployeeRoleSelection()
        {
            View.PreviousSelectedEmployeeRoleId = View.SelectedEmployeeRoleId;
            View.SelectedEmployeeRoleId = Guid.Empty;

            View.TxtEmployeeRoleNameValue = string.Empty;
            View.TxtEmployeeRoleNotesValue = string.Empty;
        }

        #endregion
        
        #region Cancel

        public void CancelEmployeeRoleBtnWasClicked()
        {
            PrepareUiAfterCancelEmployeeRoleSelection();
            PrepareUiCtrlsAfterCancelEmployeeRoleSelection();
        }

        private void PrepareUiAfterCancelEmployeeRoleSelection()
        {
            View.BtnEmployeeRoleAddEnabled = true;
            View.BtnEmployeeRoleDeleteEnabled = false;
            View.BtnEmployeeRoleCancelEnabled = false;
            View.BtnEmployeeRoleSaveEnabled = false;

            View.TxtEmployeeRoleNameEnabled = true;
        }
        private void PrepareUiCtrlsAfterCancelEmployeeRoleSelection()
        {
            View.SelectedEmployeeRoleId = View.PreviousSelectedEmployeeRoleId;
            PopulateEmployeeRoleDataAfterEmployeeRoleSelection();
        }

        #endregion

        #region For Create - Edit (POST - PUT) EmployeeRole Was Clicked - Cmd

        public async void SaveEmployeeRoleBtnWasClicked()
        {
            View.ChangedEmployeeRole = new EmployeeRoleUiModel();
            PrepareChangedEmployeeRoleForSaving();

            if (!CheckIfEmployeeRoleCanBeSaved())
            {
                View.OnEmployeeRoleSaveMsgError = "Διόρθωση. Συμπληρώστε τα απαραίτητα πεδία.";
                return;
            }

            try
            {
                //Create
                if (View.SelectedEmployeeRoleId == Guid.Empty)
                {
                    View.CreatedEmployeeRole = await Service.CreateEmployeeRoleAsync(View.ChangedEmployeeRole, ClientSettingsSingleton.InstanceSettings().TokenConfigValue);

                    if (View.CreatedEmployeeRole != null)
                        View.OnSuccessEmployeeRoleCreation = true;
                    else
                        View.OnEmployeeRoleSaveMsgError = "Σφάλμα κατά την αποθήκευση του Ρόλου Εργαζομένου.";
                }
                //Modify
                else
                {
                    if (!CheckEmployeeRoleForValidation())
                        return;
                    View.VerifyForTheEmployeeRoleModification = true;
                    if (View.ActionAfterVerifyForTheEmployeeRoleModification)
                    {
                        View.ChangedEmployeeRole.Id = View.SelectedEmployeeRoleId;
                        View.ModifiedEmployeeRole = await Service.UpdateEmployeeRoleAsync(View.ChangedEmployeeRole, ClientSettingsSingleton.InstanceSettings().TokenConfigValue);
                        View.OnSuccessEmployeeRoleModification = View.ModifiedEmployeeRole != null;
                    }
                }
            }
            catch (Exception e)
            {
                HandleServiceException(e);
            }
        }

        #endregion


        #region For Remove (DELETE) EmployeeRole Was Clicked - Cmd

        public async void RemoveEmployeeRoleBtnWasClicked()
        {
            if (!CheckIfEmployeeRoleCanBeRemoved())
            {
                View.OnEmployeeRoleDeleteMsgError = "Correction. " +
                                                "Fill in all required fields!";
            }
            else
            {
                View.VerifyForTheEmployeeRoleDeletion = true;
                if (View.ActionAfterVerifyForTheEmployeeRoleDeletion)
                {
                    try
                    {
                        View.DeletedEmployeeRole = await Service.RemoveEntityAsync(View.SelectedEmployeeRoleId);
                        if (View.DeletedEmployeeRole.Message == "Success")
                            View.OnSuccessEmployeeRoleDeletion = View.DeletedEmployeeRole != null;
                    }
                    catch (Exception e)
                    {
                        HandleServiceException(e);
                    }
                }
            }
        }

        #endregion

        #region Others

        private bool CheckIfEmployeeRoleCanBeRemoved()
        {
            return true;
        }

        private bool CheckIfEmployeeRoleCanBeSaved()
        {
            return (!String.IsNullOrEmpty(View.ChangedEmployeeRole.Name));
        }

        private void PrepareChangedEmployeeRoleForSaving()
        {
            View.ChangedEmployeeRole.Name = _bEmployeeRoleNameValidated
                ? View.ChangedEmployeeRoleName
                : View.SelectedEmployeeRoleName;
            View.ChangedEmployeeRole.Notes = _bEmployeeRoleNotesValidated
                ? View.ChangedEmployeeRoleNotes
                : View.SelectedEmployeeRoleNotes;
        }

        private void HandleServiceException(Exception e)
        {
            if (e is ServiceHttpRequestException<string>)
            {
                ServiceHttpRequestException<string> ex = (ServiceHttpRequestException<string>) e;

                switch (ex.Content)
                {
                    case "NAME_ALREADY_EXISTS":
                        View.OnEmployeeRoleSaveMsgError = "Το όνομα Ρόλου Εργαζομένου υπάρχει ήδη.\nΠαρακαλώ ελέγξτε τα πεδία εισαγωγής σας.";
                        break;
                    case "ERROR_EMPLOYEE_ROLE_ALREADY_EXISTS":
                        View.OnEmployeeRoleSaveMsgError = "Ο Ρόλος Εργαζομένου υπάρχει ήδη.";
                        break;
                    case "ERROR_EMPLOYEE_ROLE_NOT_MADE_PERSISTENT":
                        View.OnEmployeeRoleSaveMsgError = "Σφάλμα κατά την αποθήκευση του Ρόλου Εργαζομένου.";
                        break;
                    case "ERROR_EMPLOYEE_ROLE_INVALID_MODEL":
                        View.OnEmployeeRoleSaveMsgError = "Μη έγκειρα στοιχεία εισαγωγής Ρόλου Εργαζομένου.\nΠαρακαλώ ελέγξτε τα πεδία εισαγωγής σας.";
                        break;
                    case "UNKNOWN_ERROR":
                        View.OnEmployeeRoleSaveMsgError = "Σφάλμα απροσδιόριστο.";
                        break;
                    default:
                        View.OnEmployeeRoleSaveMsgError =
                            $"Σφάλμα διακομιστή: {ex.HttpStatusCode}\n, Επιπλέον στοιχεία: {ex.Content}";
                        break;
                }
            }
            else
            {
                View.OnEmployeeRoleSaveMsgError = "΄Αγνωστο Σφάλμα: " + e.Message;
            }
        }

        private bool CheckEmployeeRoleForValidation()
        {
            return true;
        }

        #endregion
        
        #region Validation --->

        public void EmployeeRoleNameValueWasChanged()
        {
            if (View.SelectedEmployeeRoleName != View.TxtEmployeeRoleNameValue)
            {
                View.ChangedEmployeeRoleName = View.TxtEmployeeRoleNameValue;
                View.BtnEmployeeRoleSaveEnabled = true;
                _bEmployeeRoleNameValidated = true;
            }
            else
            {
                View.BtnEmployeeRoleSaveEnabled = false;
                _bEmployeeRoleNameValidated = false;
            }
        }

        public void EmployeeRoleNotesValueWasChanged()
        {
            if (View.SelectedEmployeeRoleNotes != View.TxtEmployeeRoleNotesValue)
            {
                View.ChangedEmployeeRoleNotes = View.TxtEmployeeRoleNotesValue;
                View.BtnEmployeeRoleSaveEnabled = true;
                _bEmployeeRoleNotesValidated = true;
            }
            else
            {
                View.BtnEmployeeRoleSaveEnabled = false;
                _bEmployeeRoleNotesValidated = false;
            }
        }

        #endregion

        public void UcLoadedOnDemand()
        {
            View.UcWasLoadedOnDemand = true;
        }
    }
}
