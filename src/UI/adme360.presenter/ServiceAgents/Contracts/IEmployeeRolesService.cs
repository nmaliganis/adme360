using System.Collections.Generic;
using System.Threading.Tasks;
using adme360.models.DTOs.Employees.EmployeeRoles;
using adme360.presenter.ServiceAgents.Contracts.Base;

namespace adme360.presenter.ServiceAgents.Contracts
{
    public interface IEmployeeRolesService : IEntityService<EmployeeRoleUiModel>
    {
        Task<IList<EmployeeRoleUiModel>> GetAllActiveEmployeeRolesAsync(bool active);

        Task<EmployeeRoleUiModel> CreateEmployeeRoleAsync(EmployeeRoleUiModel newEmployeeRole,
            string authorizationToken = null);
        Task<EmployeeRoleUiModel> UpdateEmployeeRoleAsync(EmployeeRoleUiModel changedEmployeeRole,
            string authorizationToken = null);
    }
}