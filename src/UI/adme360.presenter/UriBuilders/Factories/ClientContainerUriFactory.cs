using dl.wm.presenter.UriBuilders.ApiFactories;

namespace dl.wm.presenter.UriBuilders.Factories
{
    public class ClientContainerUriFactory : IClientUriFactory
    {
        public string ServerIp { get; }

        public ClientContainerUriFactory(string serverIp)
        {
            ServerIp = serverIp;
        }

        public string CreateClientUri()
        {
            return new ContainerUriAddr(ServerIp).BuildUri();
        }
    }
}