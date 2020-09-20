using dl.wm.presenter.UriBuilders.ApiFactories;

namespace dl.wm.presenter.UriBuilders.Factories
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