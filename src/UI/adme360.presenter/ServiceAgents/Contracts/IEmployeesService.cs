using System.Collections.Generic;
using System.Threading.Tasks;
using adme360.models.DTOs.Employees;
using adme360.presenter.ServiceAgents.Contracts.Base;

namespace adme360.presenter.ServiceAgents.Contracts
{
    public interface IEmployeesService : IEntityService<EmployeeUiModel>
    {
        Task<List<EmployeeUiModel>> GetAllActiveEmployeesAsync(string authorizationToken = null);

        Task<IList<EmployeeUiModel>> GetAllActiveEmployeesAsync(bool active);
    }
}