using dl.wm.presenter.UriBuilders.ApiFactories;

namespace dl.wm.presenter.UriBuilders.Factories
{
    public class ClientAccountUriFactory : IClientUriFactory
    {
        public string ServerIp { get; }

        public ClientAccountUriFactory(string serverIp)
        {
            ServerIp = serverIp;
        }

        public string CreateClientUri()
        {
            return new AccountUriAddr(ServerIp).BuildUri();
        }
    }
}