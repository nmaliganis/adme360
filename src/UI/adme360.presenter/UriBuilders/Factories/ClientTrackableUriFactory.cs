using dl.wm.presenter.UriBuilders.ApiFactories;

namespace dl.wm.presenter.UriBuilders.Factories
{
    public class ClientTrackableUriFactory : IClientUriFactory
    {
        public string ServerIp { get; }

        public ClientTrackableUriFactory(string serverIp)
        {
            ServerIp = serverIp;
        }

        public string CreateClientUri()
        {
            return new TrackableUriAddr(ServerIp).BuildUri();
        }
    }
}