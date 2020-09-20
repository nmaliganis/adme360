using adme360.presenter.UriBuilders.ApiFactories;

namespace adme360.presenter.UriBuilders.Factories
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