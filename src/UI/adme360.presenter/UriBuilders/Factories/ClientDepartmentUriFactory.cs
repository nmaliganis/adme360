using adme360.presenter.UriBuilders.ApiFactories;

namespace adme360.presenter.UriBuilders.Factories
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