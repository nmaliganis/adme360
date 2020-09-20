using System.Collections.Generic;
using adme360.models.DTOs.Employees.EmployeeRoles;

namespace adme360.view.Controls.Employees.EmployeeRoles
{
    public interface IEmployeeRolesView : IMsgView
    {
        List<EmployeeRoleUiModel> EmployeeRoles { get; set; }
        bool NoneEmployeeRoleWasRetrieved { set; }
    }
}