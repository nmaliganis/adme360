using dl.wm.presenter.UriBuilders.ApiFactories;

namespace dl.wm.presenter.UriBuilders.Factories
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