using dl.wm.presenter.UriBuilders.ApiFactories;

namespace dl.wm.presenter.UriBuilders.Factories
{
    public class ClientEmployeeUriFactory : IClientUriFactory
    {
        public string ServerIp { get; }

        public ClientEmployeeUriFactory(string serverIp)
        {
            ServerIp = serverIp;
        }

        public string CreateClientUri()
        {
            return new EmployeeUriAddr(ServerIp).BuildUri();
        }
    }
}