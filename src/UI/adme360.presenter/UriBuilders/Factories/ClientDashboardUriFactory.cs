using adme360.presenter.UriBuilders.ApiFactories;

namespace adme360.presenter.UriBuilders.Factories
{
    public class ClientDashboardUriFactory : IClientUriFactory
    {
        public string ServerIp { get; }

        public ClientDashboardUriFactory(string serverIp)
        {
            ServerIp = serverIp;
        }

        public string CreateClientUri()
        {
            return new DashboardUriAddr(ServerIp).BuildUri();
        }
    }
}