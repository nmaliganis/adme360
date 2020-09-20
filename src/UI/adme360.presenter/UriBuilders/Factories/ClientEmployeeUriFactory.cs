using adme360.presenter.UriBuilders.ApiFactories;

namespace adme360.presenter.UriBuilders.Factories
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