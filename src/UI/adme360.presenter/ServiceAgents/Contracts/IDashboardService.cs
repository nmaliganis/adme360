using System.Collections.Generic;
using System.Threading.Tasks;
using dl.wm.models.DTOs.Dashboards;
using dl.wm.models.DTOs.Employees;
using dl.wm.models.DTOs.Users;
using dl.wm.models.DTOs.Vehicles;
using dl.wm.presenter.ServiceAgents.Contracts.Base;

namespace dl.wm.presenter.ServiceAgents.Contracts
{
    public interface IDashboardService : IEntityService<DashboardUiModel>
    {
    }
}