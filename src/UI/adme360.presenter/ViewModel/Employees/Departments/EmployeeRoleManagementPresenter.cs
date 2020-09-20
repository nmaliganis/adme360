using System;
using adme360.presenter.Base;
using adme360.models.DTOs.Employees.Departments;
using adme360.presenter.Exceptions;
using adme360.presenter.ServiceAgents.Contracts;
using adme360.presenter.ServiceAgents.Impls;
using adme360.presenter.Utilities;
using adme360.view.Controls.Employees.Departments;

namespace adme360.presenter.ViewModel.Employees.Departments
{
    public class EmployeeDepartmentManagementPresenter : BasePresenter<IEmployeeDepartmentManagementView, IDepartmentsService>
    {
        private bool _bEmployeeDepartmentNameValidated;

        public EmployeeDepartmentManagementPresenter(IEmployeeDepartmentManagementView view)
            : this(view, new DepartmentsService())
        {
        }

        public EmployeeDepartmentManagementPresenter(IEmployeeDepartmentManagementView view, IDepartmentsService service)
            : base(view, service)
        {
        }

        public void UcWasLoaded()
        {
            View.UcWasLoadedOnDemand = true;
        }

        #region Grid-Selection

        public void EmployeeDepartmentFromGridWasSelected()
        {
            PrepareUiAfterEmployeeDepartmentSelection();
            PopulateEmployeeDepartmentDataAfterEmployeeDepartmentSelection();
        }

        private void PrepareUiAfterEmployeeDepartmentSelectionWithNoDeletableDepartment()
        {
            View.BtnEmployeeDepartmentAddEnabled = true;
            View.BtnEmployeeDepartmentDeleteEnabled = false;
            View.BtnEmployeeDepartmentCancelEnabled = false;
            View.BtnEmployeeDepartmentSaveEnabled = false;

            View.TxtEmployeeDepartmentNameEnabled = false;
        }

        private async void PopulateEmployeeDepartmentDataAfterEmployeeDepartmentSelection()
        {
            if(View.SelectedEmployeeDepartmentId == Guid.Empty)
                return;

            View.SelectedEmployeeDepartment = await Service.GetEntityByIdAsync(View.SelectedEmployeeDepartmentId, ClientSettingsSingleton.InstanceSettings().TokenConfigValue);
            PrepareUiCtrlsAfterEmployeeDepartmentSelection();
        }

        private void PrepareUiCtrlsAfterEmployeeDepartmentSelection()
        {
            View.TxtEmployeeDepartmentNameValue = View.SelectedEmployeeDepartment?.Name;
        }

        private void PrepareUiAfterEmployeeDepartmentSelection()
        {
            View.BtnEmployeeDepartmentAddEnabled = true;
            View.BtnEmployeeDepartmentDeleteEnabled = true;
            View.BtnEmployeeDepartmentCancelEnabled = false;
            View.BtnEmployeeDepartmentSaveEnabled = false;

            View.TxtEmployeeDepartmentNameEnabled = true;
        }

        #endregion

        #region Add

        public void NewEmployeeDepartmentBtnWasClicked()
        {
            PrepareUiAfterNewEmployeeDepartmentSelection();
            PrepareUiCtrlsAfterNewEmployeeDepartmentSelection();
        }

        private void PrepareUiAfterNewEmployeeDepartmentSelection()
        {
            View.BtnEmployeeDepartmentAddEnabled = false;
            View.BtnEmployeeDepartmentDeleteEnabled = false;
            View.BtnEmployeeDepartmentCancelEnabled = true;
            View.BtnEmployeeDepartmentSaveEnabled = false;

            View.TxtEmployeeDepartmentNameEnabled = true;
        }

        private void PrepareUiCtrlsAfterNewEmployeeDepartmentSelection()
        {
            View.PreviousSelectedEmployeeDepartmentId = View.SelectedEmployeeDepartmentId;
            View.SelectedEmployeeDepartmentId = Guid.Empty;

            View.TxtEmployeeDepartmentNameValue = string.Empty;
        }

        #endregion
        
        #region Cancel

        public void CancelEmployeeDepartmentBtnWasClicked()
        {
            PrepareUiAfterCancelEmployeeDepartmentSelection();
            PrepareUiCtrlsAfterCancelEmployeeDepartmentSelection();
        }

        private void PrepareUiAfterCancelEmployeeDepartmentSelection()
        {
            View.BtnEmployeeDepartmentAddEnabled = true;
            View.BtnEmployeeDepartmentDeleteEnabled = false;
            View.BtnEmployeeDepartmentCancelEnabled = false;
            View.BtnEmployeeDepartmentSaveEnabled = false;

            View.TxtEmployeeDepartmentNameEnabled = true;
        }
        private void PrepareUiCtrlsAfterCancelEmployeeDepartmentSelection()
        {
            View.SelectedEmployeeDepartmentId = View.PreviousSelectedEmployeeDepartmentId;
            PopulateEmployeeDepartmentDataAfterEmployeeDepartmentSelection();
        }

        #endregion

        #region For Create - Edit (POST - PUT) EmployeeDepartment Was Clicked - Cmd

        public async void SaveEmployeeDepartmentBtnWasClicked()
        {
            View.ChangedEmployeeDepartment = new DepartmentUiModel();
            PrepareChangedEmployeeDepartmentForSaving();

            if (!CheckIfEmployeeDepartmentCanBeSaved())
            {
                View.OnEmployeeDepartmentSaveMsgError = "Διόρθωση. Συμπληρώστε τα απαραίτητα πεδία.";
                return;
            }

            try
            {
                //Create
                if (View.SelectedEmployeeDepartmentId == Guid.Empty)
                {
                    View.CreatedEmployeeDepartment = await Service.CreateEmployeeDepartmentAsync(View.ChangedEmployeeDepartment, ClientSettingsSingleton.InstanceSettings().TokenConfigValue);

                    if (View.CreatedEmployeeDepartment != null)
                        View.OnSuccessEmployeeDepartmentCreation = true;
                    else
                        View.OnEmployeeDepartmentSaveMsgError = "Σφάλμα κατά την αποθήκευση του Τμήματος Εργαζομένου.";
                }
                //Modify
                else
                {
                    if (!CheckEmployeeDepartmentForValidation())
                        return;
                    View.VerifyForTheEmployeeDepartmentModification = true;
                    if (View.ActionAfterVerifyForTheEmployeeDepartmentModification)
                    {
                        View.ChangedEmployeeDepartment.Id = View.SelectedEmployeeDepartmentId;
                        View.ModifiedEmployeeDepartment = await Service.UpdateEmployeeDepartmentAsync(View.ChangedEmployeeDepartment, ClientSettingsSingleton.InstanceSettings().TokenConfigValue);
                        View.OnSuccessEmployeeDepartmentModification = View.ModifiedEmployeeDepartment != null;
                    }
                }
            }
            catch (Exception e)
            {
                HandleServiceException(e);
            }
        }

        #endregion


        #region For Remove (DELETE) EmployeeDepartment Was Clicked - Cmd

        public async void RemoveEmployeeDepartmentBtnWasClicked()
        {
            if (!CheckIfEmployeeDepartmentCanBeRemoved())
            {
                View.OnEmployeeDepartmentDeleteMsgError = "Διόρθωση. " +
                                                "Συμπληρώστε όλα τα απαραίτητα πεδία!";
            }
            else
            {
                View.VerifyForTheEmployeeDepartmentDeletion = true;
                if (View.ActionAfterVerifyForTheEmployeeDepartmentDeletion)
                {
                    try
                    {
                        View.DeletedEmployeeDepartment = await Service.RemoveEntityAsync(View.SelectedEmployeeDepartmentId);
                        if (View.DeletedEmployeeDepartment.Message == "Success")
                            View.OnSuccessEmployeeDepartmentDeletion = View.DeletedEmployeeDepartment != null;
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

        private bool CheckIfEmployeeDepartmentCanBeRemoved()
        {
            return true;
        }

        private bool CheckIfEmployeeDepartmentCanBeSaved()
        {
            return (!String.IsNullOrEmpty(View.ChangedEmployeeDepartment.Name));
        }

        private void PrepareChangedEmployeeDepartmentForSaving()
        {
            View.ChangedEmployeeDepartment.Name = _bEmployeeDepartmentNameValidated
                ? View.ChangedEmployeeDepartmentName
                : View.SelectedEmployeeDepartmentName;
        }

        private void HandleServiceException(Exception e)
        {
            if (e is ServiceHttpRequestException<string>)
            {
                ServiceHttpRequestException<string> ex = (ServiceHttpRequestException<string>) e;

                switch (ex.Content)
                {
                    case "NAME_ALREADY_EXISTS":
                        View.OnEmployeeDepartmentSaveMsgError = "Το όνομα Τμήματος Εργαζομένου υπάρχει ήδη.\nΠαρακαλώ ελέγξτε τα πεδία εισαγωγής σας.";
                        break;
                    case "ERROR_EMPLOYEE_DEPARTMENT_ALREADY_EXISTS":
                        View.OnEmployeeDepartmentSaveMsgError = "Το Τμήμα Εργαζομένου υπάρχει ήδη.";
                        break;
                    case "ERROR_EMPLOYEE_DEPARTMENT_NOT_MADE_PERSISTENT":
                        View.OnEmployeeDepartmentSaveMsgError = "Σφάλμα κατά την αποθήκευση του Τμήματος Εργαζομένου.";
                        break;
                    case "ERROR_EMPLOYEE_DEPARTMENT_INVALID_MODEL":
                        View.OnEmployeeDepartmentSaveMsgError = "Μη έγκειρα στοιχεία εισαγωγής Τμήματος Εργαζομένου.\nΠαρακαλώ ελέγξτε τα πεδία εισαγωγής σας.";
                        break;
                    case "UNKNOWN_ERROR":
                        View.OnEmployeeDepartmentSaveMsgError = "Σφάλμα απροσδιόριστο.";
                        break;
                    default:
                        View.OnEmployeeDepartmentSaveMsgError =
                            $"Σφάλμα διακομιστή: {ex.HttpStatusCode}\n, Επιπλέον στοιχεία: {ex.Content}";
                        break;
                }
            }
            else
            {
                View.OnEmployeeDepartmentSaveMsgError = "΄Αγνωστο Σφάλμα: " + e.Message;
            }
        }

        private bool CheckEmployeeDepartmentForValidation()
        {
            return true;
        }

        #endregion
        
        #region Validation --->

        public void EmployeeDepartmentNameValueWasChanged()
        {
            if (View.SelectedEmployeeDepartmentName != View.TxtEmployeeDepartmentNameValue)
            {
                View.ChangedEmployeeDepartmentName = View.TxtEmployeeDepartmentNameValue;
                View.BtnEmployeeDepartmentSaveEnabled = true;
                _bEmployeeDepartmentNameValidated = true;
            }
            else
            {
                View.BtnEmployeeDepartmentSaveEnabled = false;
                _bEmployeeDepartmentNameValidated = false;
            }
        }

        #endregion

        public void UcLoadedOnDemand()
        {
            View.UcWasLoadedOnDemand = true;
        }
    }
}
