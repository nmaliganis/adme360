using adme360.presenter.UriBuilders.ApiFactories;

namespace adme360.presenter.UriBuilders.Factories
{
    public class ClientMainUriFactory : IClientUriFactory
    {
        public string ServerIp { get; }

        public ClientMainUriFactory(string serverIp)
        {
            ServerIp = serverIp;
        }

        public string CreateClientUri()
        {
            return new MainUriAddr(ServerIp).BuildUri();
        }
    }
}