using dl.wm.presenter.UriBuilders.ApiFactories;

namespace dl.wm.presenter.UriBuilders.Factories
{
    public class ClientUserJwtUriFactory : IClientUriFactory
    {
        public string ServerIp { get; }

        public ClientUserJwtUriFactory(string serverIp)
        {
            ServerIp = serverIp;
        }

        public string CreateClientUri()
        {
            return new UserJwtUriAddr(ServerIp).BuildUri();
        }
    }
}