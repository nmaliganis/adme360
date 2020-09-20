using adme360.presenter.UriBuilders.ApiFactories;

namespace adme360.presenter.UriBuilders.Factories
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