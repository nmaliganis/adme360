using adme360.presenter.UriBuilders.ApiFactories;

namespace adme360.presenter.UriBuilders.Factories
{
    public class ClientDeviceUriFactory : IClientUriFactory
    {
        public string ServerIp { get; }

        public ClientDeviceUriFactory(string serverIp)
        {
            ServerIp = serverIp;
        }

        public string CreateClientUri()
        {
            return new DeviceUriAddr(ServerIp).BuildUri();
        }
    }
}