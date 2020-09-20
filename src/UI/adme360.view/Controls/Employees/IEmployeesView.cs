using System.Collections.Generic;
using adme360.models.DTOs.Employees;

namespace adme360.view.Controls.Employees
{
    public interface IEmployeesView : IMsgView
    {
        List<EmployeeUiModel> Employees { get; set; }
        bool NoneEmployeeWasRetrieved { set; }
        string OnEmployeesMsgError { set; }
    }
}