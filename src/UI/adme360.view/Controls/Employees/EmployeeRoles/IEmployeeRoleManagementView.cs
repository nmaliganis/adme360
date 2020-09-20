using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using adme360.view;
using adme360.models.DTOs.Employees.EmployeeRoles;

namespace adme360.view.Controls.Employees.EmployeeRoles
{
    public interface IEmployeeRoleManagementView : IView
    {
        bool TxtEmployeeRoleNameEnabled { get; set; }
        string TxtEmployeeRoleNameValue { get; set; }
        bool TxtEmployeeRoleNotesEnabled { get; set; }
        string TxtEmployeeRoleNotesValue { get; set; }

        bool BtnEmployeeRoleAddEnabled { get; set; }
        bool BtnEmployeeRoleDeleteEnabled { get; set; }
        bool BtnEmployeeRoleCancelEnabled { get; set; }
        bool BtnEmployeeRoleSaveEnabled { get; set; }

        EmployeeRoleUiModel CreatedEmployeeRole { get; set; }
        Guid SelectedEmployeeRoleId { get; set; }
        string SelectedEmployeeRoleName { get; set; }
        string SelectedEmployeeRoleNotes { get; set; }
        EmployeeRoleType SelectedEmployeeRoleType { get; set; }
        EmployeeRoleUiModel SelectedEmployeeRole { get; set; }
        Guid PreviousSelectedEmployeeRoleId { get; set; }


        bool EmployeeRoleWasChanged { get; set; }
        Guid ChangedEmployeeRoleId { get; set; }
        string ChangedEmployeeRoleName { get; set; }
        string ChangedEmployeeRoleNotes { get; set; }
        EmployeeRoleUiModel ChangedEmployeeRole { get; set; }
        bool NewEmployeeRoleWasAdded { get; set; }
        EmployeeRoleUiModel FocusedSelectedEmployeeRole { get; set; }


        EmployeeRoleUiModel ModifiedEmployeeRole { get; set; }
        EmployeeRoleUiModel DeletedEmployeeRole { get; set; }


        string OnEmployeeRoleSaveMsgError { set; }
        string OnEmployeeRoleDeleteMsgError { set; }
        bool OnSuccessEmployeeRoleCreation { set; }
        bool OnSuccessEmployeeRoleModification { set; }
        bool OnSuccessEmployeeRoleDeletion { set; }
        string OnEmployeeRoleGeneralMsg { set; }
        bool VerifyForTheEmployeeRoleModification { set; }
        bool ActionAfterVerifyForTheEmployeeRoleModification { get; set; }
        bool ActionAfterSuccessEmployeeRoleModification { get; set; }
        bool VerifyForTheEmployeeRoleDeletion { set; }
        bool ActionAfterVerifyForTheEmployeeRoleDeletion { get; set; }
        bool UcWasLoadedOnDemand { set; }
    }
}
