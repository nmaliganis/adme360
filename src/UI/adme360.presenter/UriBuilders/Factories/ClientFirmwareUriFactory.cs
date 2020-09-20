using dl.wm.presenter.UriBuilders.ApiFactories;

namespace dl.wm.presenter.UriBuilders.Factories
{
    public class ClientFirmwareUriFactory : IClientUriFactory
    {
        public string ServerIp { get; }

        public ClientFirmwareUriFactory(string serverIp)
        {
            ServerIp = serverIp;
        }

        public string CreateClientUri()
        {
            return new FirmwareUriAddr(ServerIp).BuildUri();
        }
    }
}