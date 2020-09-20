using System;
using adme360.view;
using adme360.models.DTOs.Users.Roles;

namespace adme360.view.Controls.Users.Roles
{
    public interface IUcUserRoleManagementView : IView
    {
        bool OpenFlyoutForAddEditUserRole { set; }

        bool BtnUserRoleAddEnabled { get; set; }
        bool BtnUserRoleDeleteEnabled { get; set; }
        bool BtnUserRoleEditCancelEnabled { get; set; }

        Guid SelectedUserRoleId { get; set; }

        UserRoleUiModel SelectedUserRole { get; set; }
    }
}