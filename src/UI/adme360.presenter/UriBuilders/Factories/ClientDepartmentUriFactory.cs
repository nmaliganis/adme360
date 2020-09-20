using dl.wm.presenter.UriBuilders.ApiFactories;

namespace dl.wm.presenter.UriBuilders.Factories
{
    public class ClientDepartmentUriFactory : IClientUriFactory
    {
        public string ServerIp { get; }

        public ClientDepartmentUriFactory(string serverIp)
        {
            ServerIp = serverIp;
        }

        public string CreateClientUri()
        {
            return new DepartmentUriAddr(ServerIp).BuildUri();
        }
    }
}