using dl.wm.presenter.UriBuilders.ApiFactories;

namespace dl.wm.presenter.UriBuilders.Factories
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