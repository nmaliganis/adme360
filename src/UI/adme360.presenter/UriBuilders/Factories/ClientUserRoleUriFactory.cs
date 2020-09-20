using dl.wm.presenter.UriBuilders.ApiFactories;

namespace dl.wm.presenter.UriBuilders.Factories
{
    public class ClientUserRoleUriFactory : IClientUriFactory
    {
        public string ServerIp { get; }

        public ClientUserRoleUriFactory(string serverIp)
        {
            ServerIp = serverIp;
        }

        public string CreateClientUri()
        {
            return new UserRoleUriAddr(ServerIp).BuildUri();
        }
    }
}