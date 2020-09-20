using dl.wm.presenter.UriBuilders.ApiFactories;

namespace dl.wm.presenter.UriBuilders.Factories
{
    public class ClientTourUriFactory : IClientUriFactory
    {
        public string ServerIp { get; }

        public ClientTourUriFactory(string serverIp)
        {
            ServerIp = serverIp;
        }

        public string CreateClientUri()
        {
            return new TourUriAddr(ServerIp).BuildUri();
        }
    }
}