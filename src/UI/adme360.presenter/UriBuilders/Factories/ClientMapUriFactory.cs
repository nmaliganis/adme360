using adme360.presenter.UriBuilders.ApiFactories;

namespace adme360.presenter.UriBuilders.Factories
{
    public class ClientMapUriFactory : IClientUriFactory
    {
        public string ServerIp { get; }

        public ClientMapUriFactory(string serverIp)
        {
            ServerIp = serverIp;
        }

        public string CreateClientUri()
        {
            return new MapUriAddr(ServerIp).BuildUri();
        }
    }
}