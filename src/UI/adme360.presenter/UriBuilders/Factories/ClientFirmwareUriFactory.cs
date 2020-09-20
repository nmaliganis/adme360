using adme360.presenter.UriBuilders.ApiFactories;

namespace adme360.presenter.UriBuilders.Factories
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