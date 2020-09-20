using System.Collections.Generic;
using System.Threading.Tasks;
using adme360.models.DTOs.Dashboards;
using adme360.models.DTOs.Employees;
using adme360.models.DTOs.Users;
using adme360.models.DTOs.Vehicles;
using adme360.presenter.ServiceAgents.Contracts.Base;

namespace adme360.presenter.ServiceAgents.Contracts
{
    public interface IDashboardService : IEntityService<DashboardUiModel>
    {
    }
}