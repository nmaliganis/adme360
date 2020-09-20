using System.Collections.Generic;
using System.Threading.Tasks;
using dl.wm.models.DTOs.Employees.Departments;
using dl.wm.presenter.ServiceAgents.Contracts.Base;

namespace dl.wm.presenter.ServiceAgents.Contracts
{
    public interface IDepartmentsService : IEntityService<DepartmentUiModel>
    {
        Task<IList<DepartmentUiModel>> GetAllActiveDepartmentsAsync(bool active);
        Task<DepartmentUiModel> CreateEmployeeDepartmentAsync(DepartmentUiModel viewChangedEmployeeDepartment, string tokenConfigValue);
        Task<DepartmentUiModel> UpdateEmployeeDepartmentAsync(DepartmentUiModel viewChangedEmployeeDepartment, string tokenConfigValue);
    }
}