using System.Collections.Generic;
using System.Threading.Tasks;
using adme360.models.DTOs.Employees.Departments;
using adme360.presenter.ServiceAgents.Contracts.Base;

namespace adme360.presenter.ServiceAgents.Contracts
{
    public interface IDepartmentsService : IEntityService<DepartmentUiModel>
    {
        Task<IList<DepartmentUiModel>> GetAllActiveDepartmentsAsync(bool active);
        Task<DepartmentUiModel> CreateEmployeeDepartmentAsync(DepartmentUiModel viewChangedEmployeeDepartment, string tokenConfigValue);
        Task<DepartmentUiModel> UpdateEmployeeDepartmentAsync(DepartmentUiModel viewChangedEmployeeDepartment, string tokenConfigValue);
    }
}