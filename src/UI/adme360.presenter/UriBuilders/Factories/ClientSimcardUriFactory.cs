using dl.wm.presenter.UriBuilders.ApiFactories;

namespace dl.wm.presenter.UriBuilders.Factories
{
    public class ClientSimcardUriFactory : IClientUriFactory
    {
        public string ServerIp { get; }

        public ClientSimcardUriFactory(string serverIp)
        {
            ServerIp = serverIp;
        }

        public string CreateClientUri()
        {
            return new SimcardUriAddr(ServerIp).BuildUri();
        }
    }
}