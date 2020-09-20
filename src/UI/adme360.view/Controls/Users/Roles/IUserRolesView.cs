using System.Collections.Generic;
using adme360.models.DTOs.Users.Roles;
using adme360.models.DTOs.Vehicles;

namespace adme360.view.Controls.Users.Roles
{
    public interface IUserRolesView : IMsgView
    {
        List<UserRoleUiModel> UserRoles { get; set; }
        bool NoneUserRoleWasRetrieved { set; }
    }
}