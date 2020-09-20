using adme360.presenter.UriBuilders.ApiFactories;

namespace adme360.presenter.UriBuilders.Factories
{
    public class ClientRoutesUriFactory : IClientUriFactory
    {
        public string ServerIp { get; }

        public ClientRoutesUriFactory(string serverIp)
        {
            ServerIp = serverIp;
        }

        public string CreateClientUri()
        {
            return new RoutesUriAddr(ServerIp).BuildUri();
        }
    }
}