using adme360.presenter.UriBuilders.ApiFactories;

namespace adme360.presenter.UriBuilders.Factories
{
    public class ClientVehicleUriFactory : IClientUriFactory
    {
        public string ServerIp { get; }

        public ClientVehicleUriFactory(string serverIp)
        {
            ServerIp = serverIp;
        }

        public string CreateClientUri()
        {
            return new VehicleUriAddr(ServerIp).BuildUri();
        }
    }
}