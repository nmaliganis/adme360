using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using adme360.view;
using adme360.models.DTOs.Users;
using adme360.models.DTOs.Users.Roles;
using adme360.models.DTOs.Employees.Departments;
using adme360.models.DTOs.Employees.EmployeeRoles;

namespace adme360.view.Controls.Users
{
    public interface IUcFlyUserManagementView : IView    
    {
        bool TxtUserFirstNameEnabled { get; set; }
        string TxtUserFirstNameValue { get; set; }
        string SelectedUserEmployeeFirstname { get; set; }
        string ChangedUserEmployeeFirstname { get; set; }


        bool TxtUserLastNameEnabled { get; set; }
        string TxtUserLastNameValue { get; set; }
        string SelectedUserEmployeeLastname { get; set; }
        string ChangedUserEmployeeLastname { get; set; }

        bool TxtUserEmailEnabled { get; set; }
        string TxtUserEmailValue { get; set; }
        string SelectedUserEmployeeEmail { get; set; }
        string ChangedUserEmployeeEmail { get; set; }

        bool TxtUserPasswordEnabled { get; set; }
        string TxtUserPasswordValue { get; set; }
        string SelectedUserPassword { get; set; }
        string ChangedUserPassword { get; set; }

        bool TxtUserAddressStreetOneEnabled { get; set; }
        string TxtAddressStreetOneValue { get; set; }
        string SelectedUserEmployeeAddressStreetOne { get; set; }
        string ChangedUserEmployeeAddressStreetOne { get; set; }

        bool TxtUserAddressStreetTwoEnabled { get; set; }
        string TxtAddressStreetTwoValue { get; set; }
        string SelectedUserEmployeeAddressStreetTwo { get; set; }
        string ChangedUserEmployeeAddressStreetTwo { get; set; }
        
        bool TxtUserAddressPostcodeEnabled { get; set; }
        string TxtAddressPostcodeValue { get; set; }
        string SelectedUserEmployeeAddressPostcode { get; set; }
        string ChangedUserEmployeeAddressPostcode { get; set; }
        
        bool TxtUserAddressCityEnabled { get; set; }
        string TxtAddressCityValue { get; set; }
        string SelectedUserEmployeeAddressCity { get; set; }
        string ChangedUserEmployeeAddressCity { get; set; }
        
        bool TxtUserAddressRegionEnabled { get; set; }
        string TxtAddressRegionValue { get; set; }
        string SelectedUserEmployeeAddressRegion { get; set; }
        string ChangedUserEmployeeAddressRegion { get; set; }
        
        bool TxtUserMobileEnabled { get; set; }
        string TxtMobileValue { get; set; }
        string SelectedUserEmployeeMobile { get; set; }
        string ChangedUserEmployeeMobile { get; set; }
        
        bool TxtUserPhoneEnabled { get; set; }
        string TxtPhoneValue { get; set; }
        string SelectedUserEmployeePhone { get; set; }
        string ChangedUserEmployeePhone { get; set; }
        
        bool MmUserNotesEnabled { get; set; }
        string MmUserNotesValue { get; set; }
        string SelectedUserEmployeeNotes { get; set; }
        string ChangedUserEmployeeNotes { get; set; }

        bool BtnUserSaveEnabled { get; set; }
        bool BtnUserCancelEnabled { get; set; }

        bool CmbUserMobileExtEnabled { get; set; }
        int UserMobileExt { get; set; }
        bool SelectedIndexMobileExtOfUserIsDefault { set; }
        string CmbUserMobileExtValue { get; set; }
        string SelectedUserMobileExtValue { get; set; }
        string ChangedUserMobileExtValue { get; set; }

        bool CmbUserPhoneExtEnabled { get; set; }
        int UserPhoneExt { get; set; }
        bool SelectedIndexPhoneExtOfUserIsDefault { set; }
        string CmbUserPhoneExtValue { get; set; }
        string SelectedUserPhoneExtValue { get; set; }
        string ChangedUserPhoneExtValue { get; set; }

        bool CmbUserGenderEnabled { get; set; }
        int UserGender { get; set; }
        bool SelectedIndexGenderOfUserIsDefault { set; }
        string CmbUserGenderValue { get; set; }
        string SelectedUserGenderValue { get; set; }
        string ChangedUserGenderValue { get; set; }

        bool LueUserRoleUserManagementEnabled { get; set; }
        UserRoleUiModel UserRoleUserManagement { get; set; }
        bool SelectedIndexUserRoleOfUserManagementIsDefault { set; }
        bool SelectedIndexUserRoleOfUserManagementIsFirstIndex { set; }
        bool SelectedIndexUserRoleOfUserManagementIsCustom { set; }
        Guid SelectedUserRoleUserManagementId { get; set; }
        Guid PreviousSelectedUserRoleUserManagementId { get; set; }
        Guid ChangedUserRoleUserManagementId { get; set; }

        bool LueDepartmentUserManagementEnabled { get; set; }
        DepartmentUiModel DepartmentUserManagement { get; set; }
        bool SelectedIndexDepartmentOfUserManagementIsDefault { set; }
        bool SelectedIndexDepartmentOfUserManagementIsFirstIndex { set; }
        bool SelectedIndexDepartmentOfUserManagementIsCustom { set; }
        Guid SelectedDepartmentUserManagementId { get; set; }
        Guid PreviousSelectedDepartmentUserManagementId { get; set; }
        Guid ChangedDepartmentUserManagementId { get; set; }

        bool LueEmployeeRoleUserManagementEnabled { get; set; }
        EmployeeRoleUiModel EmployeeRoleUserManagement { get; set; }
        bool SelectedIndexEmployeeRoleOfUserManagementIsDefault { set; }
        bool SelectedIndexEmployeeRoleOfUserManagementIsFirstIndex { set; }
        bool SelectedIndexEmployeeRoleOfUserManagementIsCustom { set; }
        Guid SelectedEmployeeRoleUserManagementId { get; set; }
        Guid PreviousSelectedEmployeeRoleUserManagementId { get; set; }
        Guid ChangedEmployeeRoleUserManagementId { get; set; }

        UserUiModel ModifiedUser { get; set; }
        AccountUiModel ChangedUser { get; set; }
        Guid SelectedUserId { get; set; }
        UserUiModel CreatedUser { get; set; }
        bool OnSuccessUserCreation { set; }
        bool ActionAfterVerifyForTheUserCreation { get; set; }
        bool VerifyForTheUserModification { get; set; }
        bool ActionAfterVerifyForTheUserModification { get; set; }

        bool OnDemandLoadFlyoutUserManagement { set; }
        string OnUserSaveMsgError { set; }
        string SelectedUserRoleValue { get; set; }
        string SelectedUserEmployeeDepartmentValue { get; set; }
        string SelectedUserEmployeeRoleValue { get; set; }
        string SelectedUserEmployeeGenderValue { get; set; }
        string SelectedUserEmployeeStatusValue { get; set; }
        bool OnSuccessUserModification { get; set; }
    }
}
