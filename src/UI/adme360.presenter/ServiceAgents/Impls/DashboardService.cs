using adme360.models.DTOs.Dashboards;
using adme360.presenter.ServiceAgents.Contracts;
using adme360.presenter.ServiceAgents.Impls.Base;

namespace adme360.presenter.ServiceAgents.Impls
{
    public class DashboardService : BaseService<DashboardUiModel>, IDashboardService
    {
        private static readonly string _serviceName = "DashboardService";

        public DashboardService() : base(_serviceName)
        {

        }
    }
}
