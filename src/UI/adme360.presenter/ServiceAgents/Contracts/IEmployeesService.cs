using System.Collections.Generic;
using System.Threading.Tasks;
using dl.wm.models.DTOs.Employees;
using dl.wm.presenter.ServiceAgents.Contracts.Base;

namespace dl.wm.presenter.ServiceAgents.Contracts
{
    public interface IEmployeesService : IEntityService<EmployeeUiModel>
    {
        Task<List<EmployeeUiModel>> GetAllActiveEmployeesAsync(string authorizationToken = null);

        Task<IList<EmployeeUiModel>> GetAllActiveEmployeesAsync(bool active);
    }
}