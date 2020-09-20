using System.Collections.Generic;
using adme360.models.DTOs.Employees.Departments;

namespace adme360.view.Controls.Employees.Departments
{
    public interface IDepartmentsView : IMsgView
    {
        List<DepartmentUiModel> Departments { get; set; }
        bool NoneDepartmentWasRetrieved { set; }
    }
}