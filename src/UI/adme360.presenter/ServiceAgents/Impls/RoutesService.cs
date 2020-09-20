using dl.wm.models.DTOs.Dashboards;
using dl.wm.presenter.ServiceAgents.Contracts;
using dl.wm.presenter.ServiceAgents.Impls.Base;

namespace dl.wm.presenter.ServiceAgents.Impls
{
    public class RoutesService : BaseService<RouteUiModel>, IRoutesService
    {
        private static readonly string _serviceName = "RoutesService";

        public RoutesService() : base(_serviceName)
        {

        }
    }
}
