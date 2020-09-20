using adme360.presenter.UriBuilders.ApiFactories;

namespace adme360.presenter.UriBuilders.Factories
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