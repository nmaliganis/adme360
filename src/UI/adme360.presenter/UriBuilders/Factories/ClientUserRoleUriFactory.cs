using adme360.presenter.UriBuilders.ApiFactories;

namespace adme360.presenter.UriBuilders.Factories
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