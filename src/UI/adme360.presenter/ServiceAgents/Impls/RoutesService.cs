using adme360.models.DTOs.Dashboards;
using adme360.presenter.ServiceAgents.Contracts;
using adme360.presenter.ServiceAgents.Impls.Base;

namespace adme360.presenter.ServiceAgents.Impls
{
    public class RoutesService : BaseService<RouteUiModel>, IRoutesService
    {
        private static readonly string _serviceName = "RoutesService";

        public RoutesService() : base(_serviceName)
        {

        }
    }
}
