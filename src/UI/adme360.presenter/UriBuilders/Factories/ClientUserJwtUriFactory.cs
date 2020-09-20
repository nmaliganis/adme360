using adme360.presenter.UriBuilders.ApiFactories;

namespace adme360.presenter.UriBuilders.Factories
{
    public class ClientUserJwtUriFactory : IClientUriFactory
    {
        public string ServerIp { get; }

        public ClientUserJwtUriFactory(string serverIp)
        {
            ServerIp = serverIp;
        }

        public string CreateClientUri()
        {
            return new UserJwtUriAddr(ServerIp).BuildUri();
        }
    }
}