using System;
using adme360.view;
using adme360.models.DTOs.Employees.Departments;

namespace adme360.view.Controls.Employees.Departments
{
    public interface IEmployeeDepartmentManagementView : IView
    {
        bool TxtEmployeeDepartmentNameEnabled { get; set; }
        string TxtEmployeeDepartmentNameValue { get; set; }

        bool BtnEmployeeDepartmentAddEnabled { get; set; }
        bool BtnEmployeeDepartmentDeleteEnabled { get; set; }
        bool BtnEmployeeDepartmentCancelEnabled { get; set; }
        bool BtnEmployeeDepartmentSaveEnabled { get; set; }

        DepartmentUiModel CreatedEmployeeDepartment { get; set; }
        Guid SelectedEmployeeDepartmentId { get; set; }
        string SelectedEmployeeDepartmentName { get; set; }
        DepartmentUiModel SelectedEmployeeDepartment { get; set; }
        Guid PreviousSelectedEmployeeDepartmentId { get; set; }


        bool EmployeeDepartmentWasChanged { get; set; }
        Guid ChangedEmployeeDepartmentId { get; set; }
        string ChangedEmployeeDepartmentName { get; set; }
        DepartmentUiModel ChangedEmployeeDepartment { get; set; }
        bool NewEmployeeDepartmentWasAdded { get; set; }
        DepartmentUiModel FocusedSelectedEmployeeDepartment { get; set; }


        DepartmentUiModel ModifiedEmployeeDepartment { get; set; }
        DepartmentUiModel DeletedEmployeeDepartment { get; set; }


        string OnEmployeeDepartmentSaveMsgError { set; }
        string OnEmployeeDepartmentDeleteMsgError { set; }
        bool OnSuccessEmployeeDepartmentCreation { set; }
        bool OnSuccessEmployeeDepartmentModification { set; }
        bool OnSuccessEmployeeDepartmentDeletion { set; }
        string OnEmployeeDepartmentGeneralMsg { set; }
        bool VerifyForTheEmployeeDepartmentModification { set; }
        bool ActionAfterVerifyForTheEmployeeDepartmentModification { get; set; }
        bool ActionAfterSuccessEmployeeDepartmentModification { get; set; }
        bool VerifyForTheEmployeeDepartmentDeletion { set; }
        bool ActionAfterVerifyForTheEmployeeDepartmentDeletion { get; set; }
        bool UcWasLoadedOnDemand { set; }
    }
}
