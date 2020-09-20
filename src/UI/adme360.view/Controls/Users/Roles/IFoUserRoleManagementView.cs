using System;
using System.Net.Http;
using adme360.view;
using adme360.models.DTOs.Users.Roles;

namespace adme360.view.Controls.Users.Roles
{
    public interface IFoUserRoleManagementView : IView
    {
        bool TxtUserRoleNameEnabled { get; set; }
        string TxtUserRoleNameValue { get; set; }
        Guid UserRoleIdToBeRetrieved { get; set; }
        UserRoleUiModel SelectedUserRole { get; set; }
        UserRoleUiModel ChangedUserRole { get; set; }
        string OnSaveUserRoleMsgError { set; }
        Guid SelectedUserRoleId { get; set; }
        UserRoleUiModel CreatedUserRole { get; set; }
        bool OnSuccessUserRoleCreation { get; set; }
        bool VerifyForTheUserRoleModification { get; set; }
        bool ActionAfterVerifyForTheUserRoleModification { get; set; }
        UserRoleUiModel ModifiedUserRole { get; set; }
        string ChangedUserRoleName { get; set; }
        string SelectedUserRoleName { get; set; }
    }
}