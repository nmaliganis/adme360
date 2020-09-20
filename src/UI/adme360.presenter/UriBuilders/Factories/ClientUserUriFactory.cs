using dl.wm.presenter.UriBuilders.ApiFactories;

namespace dl.wm.presenter.UriBuilders.Factories
{
    public class ClientUserUriFactory : IClientUriFactory
    {
        public string ServerIp { get; }

        public ClientUserUriFactory(string serverIp)
        {
            ServerIp = serverIp;
        }

        public string CreateClientUri()
        {
            return new UserUriAddr(ServerIp).BuildUri();
        }
    }
}