using adme360.models.DTOs.Dashboards;
using adme360.presenter.ServiceAgents.Contracts;
using adme360.presenter.ServiceAgents.Impls.Base;

namespace adme360.presenter.ServiceAgents.Impls
{
    public class MainService : BaseService<MainUiModel>, IMainService
    {
        private static readonly string _serviceName = "MainService";

        public MainService() : base(_serviceName)
        {

        }
    }
}
