using System;
using dl.wm.models.DTOs.Users;
using dl.wm.presenter.Exceptions;
using dl.wm.presenter.ServiceAgents.Contracts;
using dl.wm.presenter.ServiceAgents.Impls;
using dl.wm.presenter.Utilities;
using dl.wm.view.Controls.Users;
using dl.wm.presenter.Base;

namespace dl.wm.presenter.ViewModel.Users
{
    public class UcFlyUserManagementPresenter : BasePresenter<IUcFlyUserManagementView, IAccountsService>
    {
        private bool _bUserEmployeeFirstnameValidated = false;
        private bool _bUserEmployeePasswordValidated = false;
        private bool _bUserEmployeeLastnameValidated = false;
        private bool _bUserEmployeeEmailValidated = false;
        private bool _bUserEmployeeAddressStreetOneValidated = false;
        private bool _bUserEmployeeAddressStreetTwoValidated = false;
        private bool _bUserEmployeeAddressCityValidated = false;
        private bool _bUserEmployeeAddressPostcodeValidated = false;
        private bool _bUserEmployeeAddressRegionValidated = false;
        private bool _bUserEmployeePhoneValidated = false;
        private bool _bUserEmployeeMobileValidated = false;
        private bool _bUserEmployeeGenderValidated = false;
        private bool _bUserUserRoleValidated = false;
        private bool _bUserEmployeeEmployeeRoleValidated = false;
        private bool _bUserEmployeeDepartmentValidated = false;
        private bool _bUserEmployeeStatusValidated = false;
        private bool _bUserEmployeeNotesValidated = false;
        private bool _bUserEmployeeExtMobileValidated = false;
        private bool _bUserEmployeeExtPhoneValidated = false;


        public UcFlyUserManagementPresenter(IUcFlyUserManagementView view)
            : this(view, new AccountsService())
        {
        }

        public UcFlyUserManagementPresenter(IUcFlyUserManagementView view, IAccountsService service) 
            : base(view, service)
        {
        }

        public void FlyoutUserManagementWasLoaded()
        {
            View.OnDemandLoadFlyoutUserManagement = true;
            PrepareUiCtrlsAfterLoadFlyoutUserManagement();
            if (View.SelectedUserId == Guid.Empty)
            {
                PrepareUiCtrlsValuesAfterAddUserWasSelected();
            }
            else
            {
                PopulateUiCtrlsValuesAfterEditUserWasSelected();
            }
        }

        private void PopulateUiCtrlsValuesAfterEditUserWasSelected()
        {
            
        }

        public void ActionAfterVerifyForTheUserCreation()
        {
            if (View.ActionAfterVerifyForTheUserCreation)
            {
                PrepareUiCtrlsValuesAfterAddUserWasSelected();
                PrepareUiCtrlsAfterLoadFlyoutUserManagement();
            }
        }

        private void PrepareUiCtrlsValuesAfterAddUserWasSelected()
        {
            View.SelectedUserId = Guid.Empty;
            View.SelectedUserEmployeeFirstname = string.Empty;
            View.SelectedUserEmployeeLastname = string.Empty;
            View.SelectedUserEmployeeEmail = string.Empty;
            View.SelectedUserEmployeeNotes = string.Empty;
            View.SelectedUserEmployeeAddressStreetOne = string.Empty;
            View.SelectedUserEmployeeAddressStreetTwo = string.Empty;
            View.SelectedUserEmployeeAddressCity = string.Empty;
            View.SelectedUserEmployeeAddressPostcode = string.Empty;
            View.SelectedUserEmployeeAddressRegion = string.Empty;
            View.SelectedUserEmployeePhone = string.Empty;
            View.SelectedUserEmployeeMobile = string.Empty;
            View.SelectedUserRoleValue = string.Empty;
            View.SelectedUserEmployeeDepartmentValue = string.Empty;
            View.SelectedUserEmployeeRoleValue = string.Empty;
            View.SelectedUserEmployeeGenderValue = string.Empty;
            View.SelectedUserEmployeeStatusValue = string.Empty;

            //Todo: Should all the controls initiated HERE!
        }

        private void PrepareUiCtrlsAfterLoadFlyoutUserManagement()
        {
            View.BtnUserSaveEnabled = true; //Todo changed to false
            View.BtnUserCancelEnabled = true;

            View.TxtUserFirstNameEnabled = true;
            View.TxtUserLastNameEnabled = true;
            View.TxtUserEmailEnabled = true;
            View.TxtUserPasswordEnabled = true;
            View.TxtUserAddressStreetOneEnabled = true;
            View.TxtUserAddressStreetTwoEnabled = true;
            View.TxtUserAddressRegionEnabled = true;
            View.TxtUserAddressPostcodeEnabled = true;
            View.TxtUserAddressCityEnabled = true;
            View.TxtUserMobileEnabled = true;
            View.TxtUserPhoneEnabled = true;
            View.CmbUserMobileExtEnabled = true;
            View.CmbUserPhoneExtEnabled = true;
            View.CmbUserGenderEnabled = true;
            View.LueUserRoleUserManagementEnabled = true;
            View.LueEmployeeRoleUserManagementEnabled = true;
            View.LueDepartmentUserManagementEnabled = true;
            View.MmUserNotesEnabled = true;
        }

        public async void SaveUserBtnWasClicked()
        {
            View.ChangedUser = new AccountUiModel();
            PrepareChangedUserForSaving();

            if (!CheckIfUserCanBeSaved())
            {
                View.OnUserSaveMsgError = "Διόρθωση. " +
                                             "Συμπληρώστε όλα τα απαραίτητα πεδία";
                return;
            }

            try
            {
                //Create
                if (View.SelectedUserId == Guid.Empty)
                {
                    View.CreatedUser = await Service
                        .CreateRegisterNewUserAccountAsync(View.ChangedUser, ClientSettingsSingleton.InstanceSettings().TokenConfigValue);

                    if (View.CreatedUser != null)
                        View.OnSuccessUserCreation = true;
                }
                //Modify
                else
                {
                    if (!CheckUserForValidation())
                        return;
                    View.VerifyForTheUserModification = true;
                    if (View.ActionAfterVerifyForTheUserModification)
                    {
                        View.ChangedUser.Id = View.SelectedUserId;
                        View.ModifiedUser = await Service.UpdateRegisterExistingUserAccountAsync(View.ChangedUser, ClientSettingsSingleton.InstanceSettings().TokenConfigValue);
                        View.OnSuccessUserModification = View.ModifiedUser != null;
                    }
                }
            }
            catch (Exception e)
            {
                HandleServiceException(e);
            }
        }

        #region Others

        private void HandleServiceException(Exception e)
        {
            if (e is ServiceHttpRequestException<string>)
            {
                ServiceHttpRequestException<string> ex = (ServiceHttpRequestException<string>) e;

                switch (ex.Content)
                {
                    case "USERNAME_OR_EMAIL_ALREADY_EXISTS":
                        View.OnUserSaveMsgError = "Το όνομα Χρήστη ή/και το email υπάρχει(ουν) ήδη.\nΠαρακαλώ ελέγξτε τα πεδία εισαγωγής σας.";
                        break;
                    case "ERROR_USER_ALREADY_EXISTS":
                        View.OnUserSaveMsgError = "Ο Χρήστης υπάρχει ήδη.";
                        break;
                    case "ERROR_USER_NOT_MADE_PERSISTENT":
                        View.OnUserSaveMsgError = "Σφάλμα κατά την αποθήκευση του Χρήστη.";
                        break;
                    case "ERROR_USER_INVALID_MODEL":
                        View.OnUserSaveMsgError= "Μη έγκειρα στοιχεία εισαγωγής Χρήστη.\nΠαρακαλώ ελέγξτε τα πεδία εισαγωγής σας.";
                        break;
                    case "UNKNOWN_ERROR":
                        View.OnUserSaveMsgError = "Σφάλμα απροσδιόριστο.";
                        break;
                    default:
                        View.OnUserSaveMsgError =
                            $"Σφάλμα διακομιστή: {ex.HttpStatusCode}\n, Επιπλέον στοιχεία: {ex.Content}";
                        break;
                }
            }
            else
            {
                View.OnUserSaveMsgError = "΄Αγνωστο Σφάλμα: " + e.Message;
            }
        }

        private bool CheckUserForValidation()
        {
            return true;
        }

        private bool CheckIfUserCanBeSaved()
        {
            return (
                !String.IsNullOrEmpty(View.ChangedUser.Employee.Firstname) &&
                !String.IsNullOrEmpty(View.ChangedUser.Employee.Lastname) &&
                !String.IsNullOrEmpty(View.ChangedUser.Employee.Phone) &&
                !String.IsNullOrEmpty(View.ChangedUser.Employee.Mobile) &&
                !String.IsNullOrEmpty(View.ChangedUser.Employee.Email)
            );
        }

        private void PrepareChangedUserForSaving()
        {
            View.ChangedUser.Login = _bUserEmployeeEmailValidated
                ? View.ChangedUserEmployeeEmail
                : View.TxtUserEmailValue;
            View.ChangedUser.Employee.Firstname = _bUserEmployeeFirstnameValidated
                ? View.ChangedUserEmployeeFirstname
                : View.TxtUserFirstNameValue;
            View.ChangedUser.UserPassword = _bUserEmployeePasswordValidated
                ? View.ChangedUserPassword
                : View.TxtUserPasswordValue;
            View.ChangedUser.Employee.Lastname = _bUserEmployeeLastnameValidated
                ? View.ChangedUserEmployeeLastname
                : View.TxtUserLastNameValue;
            View.ChangedUser.Employee.Email = _bUserEmployeeEmailValidated
                ? View.ChangedUserEmployeeEmail
                : View.TxtUserEmailValue;
            View.ChangedUser.Employee.AddressStreetOne = _bUserEmployeeAddressStreetOneValidated
                ? View.ChangedUserEmployeeAddressStreetOne
                : View.TxtAddressStreetOneValue;
            View.ChangedUser.Employee.AddressStreetTwo = _bUserEmployeeAddressStreetTwoValidated
                ? View.ChangedUserEmployeeAddressStreetTwo
                : View.TxtAddressStreetTwoValue;
            View.ChangedUser.Employee.AddressCity = _bUserEmployeeAddressCityValidated
                ? View.ChangedUserEmployeeAddressCity
                : View.TxtAddressCityValue;
            View.ChangedUser.Employee.AddressRegion = _bUserEmployeeAddressRegionValidated
                ? View.ChangedUserEmployeeAddressRegion
                : View.TxtAddressRegionValue;
            View.ChangedUser.Employee.AddressPostCode = _bUserEmployeeAddressPostcodeValidated
                ? View.ChangedUserEmployeeAddressPostcode
                : View.TxtAddressPostcodeValue;
            View.ChangedUser.Employee.GenderValue = _bUserEmployeeGenderValidated
                ? View.ChangedUserGenderValue
                : View.SelectedUserGenderValue;
            View.ChangedUser.Employee.ExtMobile = _bUserEmployeeExtMobileValidated
                ? View.ChangedUserMobileExtValue
                : View.SelectedUserMobileExtValue;
            View.ChangedUser.Employee.ExtPhone = _bUserEmployeeExtPhoneValidated
                ? View.ChangedUserPhoneExtValue
                : View.SelectedUserPhoneExtValue;
            View.ChangedUser.Employee.Mobile = _bUserEmployeeMobileValidated
                ? View.ChangedUserEmployeeMobile
                : View.TxtMobileValue;
            View.ChangedUser.Employee.Phone = _bUserEmployeePhoneValidated
                ? View.ChangedUserEmployeePhone
                : View.TxtPhoneValue;
            View.ChangedUser.Employee.Notes = _bUserEmployeeNotesValidated
                ? View.ChangedUserEmployeeNotes
                : View.MmUserNotesValue;


            View.ChangedUser.UserRoleId = _bUserUserRoleValidated
                ? View.ChangedUserRoleUserManagementId
                : View.SelectedUserRoleUserManagementId;
            View.ChangedUser.Employee.EmployeeRoleId = _bUserEmployeeEmployeeRoleValidated
                ? View.ChangedEmployeeRoleUserManagementId
                : View.SelectedEmployeeRoleUserManagementId;
            View.ChangedUser.Employee.DepartmentId = _bUserEmployeeDepartmentValidated
                ? View.ChangedDepartmentUserManagementId
                : View.SelectedDepartmentUserManagementId;
        }

        #endregion

        #region UI Changes

        public void UserRoleWasChanged()
        {
            if (View.UserRoleUserManagement  == null)
            {
                if (View.SelectedUserRoleUserManagementId == Guid.Empty)
                    return;
                View.BtnUserSaveEnabled = true;
                _bUserUserRoleValidated = true;
                return;
            }

            if (View.UserRoleUserManagement != null && View.SelectedUserRoleUserManagementId != View.UserRoleUserManagement.Id)
            {
                View.ChangedUserRoleUserManagementId = View.UserRoleUserManagement.Id;
                View.BtnUserSaveEnabled = true;
                _bUserUserRoleValidated = true;
            }
            else
            {
                View.BtnUserSaveEnabled = false;
                _bUserUserRoleValidated = false;
            }
        }

        public void DepartmentWasChanged()
        {
            if (View.DepartmentUserManagement  == null)
            {
                if (View.SelectedDepartmentUserManagementId == Guid.Empty)
                    return;
                View.BtnUserSaveEnabled = true;
                _bUserEmployeeDepartmentValidated = true;
                return;
            }

            if (View.DepartmentUserManagement != null && View.SelectedDepartmentUserManagementId != View.DepartmentUserManagement.Id)
            {
                View.ChangedDepartmentUserManagementId = View.DepartmentUserManagement.Id;
                View.BtnUserSaveEnabled = true;
                _bUserEmployeeDepartmentValidated = true;
            }
            else
            {
                View.BtnUserSaveEnabled = false;
                _bUserEmployeeDepartmentValidated = false;
            }
        }

        public void EmployeeRoleWasChanged()
        {
            if (View.EmployeeRoleUserManagement == null)
            {
                if (View.SelectedEmployeeRoleUserManagementId == Guid.Empty)
                    return;
                View.BtnUserSaveEnabled = true;
                _bUserEmployeeEmployeeRoleValidated = true;
                return;
            }

            if (View.EmployeeRoleUserManagement != null && View.SelectedEmployeeRoleUserManagementId != View.EmployeeRoleUserManagement.Id)
            {
                View.ChangedEmployeeRoleUserManagementId = View.EmployeeRoleUserManagement.Id;
                View.BtnUserSaveEnabled = true;
                _bUserEmployeeEmployeeRoleValidated = true;
            }
            else
            {
                View.BtnUserSaveEnabled = false;
                _bUserEmployeeEmployeeRoleValidated = false;
            }
        }

        public void FirstnameWasChanged()
        {
            if (View.SelectedUserEmployeeFirstname != View.TxtUserFirstNameValue)
            {
                View.ChangedUserEmployeeFirstname = View.TxtUserFirstNameValue;
                View.BtnUserSaveEnabled = true;
                _bUserEmployeeFirstnameValidated = true;
            }
            else
            {
                View.BtnUserSaveEnabled = false;
                _bUserEmployeeFirstnameValidated = false;
            }
        }

        public void LastnameWasChanged()
        {
            if (View.SelectedUserEmployeeLastname != View.TxtUserLastNameValue)
            {
                View.ChangedUserEmployeeLastname = View.TxtUserLastNameValue;
                View.BtnUserSaveEnabled = true;
                _bUserEmployeeLastnameValidated = true;
            }
            else
            {
                View.BtnUserSaveEnabled = false;
                _bUserEmployeeLastnameValidated = false;
            }
        }

        public void EmailWasChanged()
        {
            if (View.SelectedUserEmployeeEmail != View.TxtUserEmailValue)
            {
                View.ChangedUserEmployeeEmail = View.TxtUserEmailValue;
                View.BtnUserSaveEnabled = true;
                _bUserEmployeeEmailValidated = true;
            }
            else
            {
                View.BtnUserSaveEnabled = false;
                _bUserEmployeeEmailValidated = false;
            }
        }

        public void PasswordWasChanged()
        {
            if (View.SelectedUserPassword != View.TxtUserPasswordValue)
            {
                View.ChangedUserPassword = View.TxtUserPasswordValue;
                View.BtnUserSaveEnabled = true;
                _bUserEmployeePasswordValidated = true;
            }
            else
            {
                View.BtnUserSaveEnabled = false;
                _bUserEmployeePasswordValidated = false;
            }
        }

        public void GenderWasChanged()
        {
            if (View.SelectedUserEmployeeGenderValue != View.CmbUserGenderValue)
            {
                View.ChangedUserGenderValue = View.CmbUserGenderValue;
                View.BtnUserSaveEnabled = true;
                _bUserEmployeeGenderValidated = true;
            }
            else
            {
                View.BtnUserSaveEnabled = false;
                _bUserEmployeeGenderValidated = false;
            }
        }

        public void AddressStreetOneWasChanged()
        {
            if (View.SelectedUserEmployeeAddressStreetOne != View.TxtAddressStreetOneValue)
            {
                View.ChangedUserEmployeeAddressStreetOne = View.TxtAddressStreetOneValue;
                View.BtnUserSaveEnabled = true;
                _bUserEmployeeAddressStreetOneValidated = true;
            }
            else
            {
                View.BtnUserSaveEnabled = false;
                _bUserEmployeeAddressStreetOneValidated = false;
            }
        }
        
        public void AddressStreetTwoWasChanged()
        {
            if (View.SelectedUserEmployeeAddressStreetTwo != View.TxtAddressStreetTwoValue)
            {
                View.ChangedUserEmployeeAddressStreetTwo = View.TxtAddressStreetTwoValue;
                View.BtnUserSaveEnabled = true;
                _bUserEmployeeAddressStreetTwoValidated = true;
            }
            else
            {
                View.BtnUserSaveEnabled = false;
                _bUserEmployeeAddressStreetTwoValidated = false;
            }
        }

        public void AddressCityWasChanged()
        {
            if (View.SelectedUserEmployeeAddressCity != View.TxtAddressCityValue)
            {
                View.ChangedUserEmployeeAddressCity = View.TxtAddressCityValue;
                View.BtnUserSaveEnabled = true;
                _bUserEmployeeAddressCityValidated = true;
            }
            else
            {
                View.BtnUserSaveEnabled = false;
                _bUserEmployeeAddressCityValidated = false;
            }
        }

        public void AddressPostcodeWasChanged()
        {
            if (View.SelectedUserEmployeeAddressPostcode != View.TxtAddressPostcodeValue)
            {
                View.ChangedUserEmployeeAddressPostcode = View.TxtAddressPostcodeValue;
                View.BtnUserSaveEnabled = true;
                _bUserEmployeeAddressPostcodeValidated = true;
            }
            else
            {
                View.BtnUserSaveEnabled = false;
                _bUserEmployeeAddressPostcodeValidated = false;
            }
        }

        public void AddressRegionWasChanged()
        {
            if (View.SelectedUserEmployeeAddressRegion != View.TxtAddressRegionValue)
            {
                View.ChangedUserEmployeeAddressRegion = View.TxtAddressRegionValue;
                View.BtnUserSaveEnabled = true;
                _bUserEmployeeAddressRegionValidated = true;
            }
            else
            {
                View.BtnUserSaveEnabled = false;
                _bUserEmployeeAddressRegionValidated = false;
            }
        }

        public void ExtMobileWasChanged()
        {
            if (View.SelectedUserMobileExtValue != View.CmbUserMobileExtValue)
            {
                View.ChangedUserMobileExtValue = View.CmbUserMobileExtValue;
                View.BtnUserSaveEnabled = true;
                _bUserEmployeeExtMobileValidated = true;
            }
            else
            {
                View.BtnUserSaveEnabled = false;
                _bUserEmployeeExtMobileValidated= false;
            }
        }

        public void MobileWasChanged()
        {
            if (View.SelectedUserEmployeeMobile != View.TxtMobileValue)
            {
                View.ChangedUserEmployeeMobile = View.TxtMobileValue;
                View.BtnUserSaveEnabled = true;
                _bUserEmployeeMobileValidated = true;
            }
            else
            {
                View.BtnUserSaveEnabled = false;
                _bUserEmployeeMobileValidated = false;
            }
        }

        public void PhoneWasChanged()
        {
            if (View.SelectedUserEmployeePhone != View.TxtPhoneValue)
            {
                View.ChangedUserEmployeePhone = View.TxtPhoneValue;
                View.BtnUserSaveEnabled = true;
                _bUserEmployeePhoneValidated = true;
            }
            else
            {
                View.BtnUserSaveEnabled = false;
                _bUserEmployeePhoneValidated = false;
            }
        }

        public void ExtPhoneWasChanged()
        {
            if (View.SelectedUserPhoneExtValue != View.CmbUserPhoneExtValue)
            {
                View.ChangedUserPhoneExtValue = View.CmbUserPhoneExtValue;
                View.BtnUserSaveEnabled = true;
                _bUserEmployeeExtPhoneValidated = true;
            }
            else
            {
                View.BtnUserSaveEnabled = false;
                _bUserEmployeeExtPhoneValidated= false;
            }
        }

        public void NotesWasChanged()
        {
            if (View.SelectedUserEmployeeNotes != View.MmUserNotesValue)
            {
                View.ChangedUserEmployeeNotes = View.MmUserNotesValue;
                View.BtnUserSaveEnabled = true;
                _bUserEmployeeNotesValidated = true;
            }
            else
            {
                View.BtnUserSaveEnabled = false;
                _bUserEmployeeNotesValidated = false;
            }
        }

        #endregion

    }
}
