using adme360.presenter.UriBuilders.ApiFactories;

namespace adme360.presenter.UriBuilders.Factories
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