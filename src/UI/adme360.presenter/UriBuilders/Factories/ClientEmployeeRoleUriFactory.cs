using dl.wm.presenter.UriBuilders.ApiFactories;

namespace dl.wm.presenter.UriBuilders.Factories
{
    public class ClientEmployeeRoleUriFactory : IClientUriFactory
    {
        public string ServerIp { get; }

        public ClientEmployeeRoleUriFactory(string serverIp)
        {
            ServerIp = serverIp;
        }

        public string CreateClientUri()
        {
            return new EmployeeRoleUriAddr(ServerIp).BuildUri();
        }
    }
}