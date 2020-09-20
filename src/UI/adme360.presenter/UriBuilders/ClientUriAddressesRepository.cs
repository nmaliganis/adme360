using System.Collections.Generic;
using dl.wm.presenter.UriBuilders.Factories;
using dl.wm.presenter.Utilities;

namespace dl.wm.presenter.UriBuilders
{
  public sealed class ClientUriAddressesRepository
  {
    private readonly IDictionary<string, IClientUriFactory> _clientUriFactory;
    private ClientUriAddressesRepository()
    {
      _clientUriFactory = new Dictionary<string, IClientUriFactory>()
                {
                    { "RoutesService", new ClientRoutesUriFactory(ClientSettingsSingleton.InstanceSettings().IpAddressConfigValue)},
                    { "MapService", new ClientMapUriFactory(ClientSettingsSingleton.InstanceSettings().IpAddressConfigValue)},
                    { "MainService", new ClientDashboardUriFactory(ClientSettingsSingleton.InstanceSettings().IpAddressConfigValue)},
                    { "DashboardService", new ClientDashboardUriFactory(ClientSettingsSingleton.InstanceSettings().IpAddressConfigValue)},
                    { "AccountsService", new ClientAccountUriFactory(ClientSettingsSingleton.InstanceSettings().IpAddressConfigValue)},
                    { "UsersService", new ClientUserUriFactory(ClientSettingsSingleton.InstanceSettings().IpAddressConfigValue)},
                    { "VehiclesService", new ClientVehicleUriFactory(ClientSettingsSingleton.InstanceSettings().IpAddressConfigValue)},
                    { "TrackablesService", new ClientTrackableUriFactory(ClientSettingsSingleton.InstanceSettings().IpAddressConfigValue)},
                    { "ToursService", new ClientTourUriFactory(ClientSettingsSingleton.InstanceSettings().IpAddressConfigValue)},
                    { "ContainersService", new ClientContainerUriFactory(ClientSettingsSingleton.InstanceSettings().IpAddressConfigValue)},
                    { "SimcardsService", new ClientSimcardUriFactory(ClientSettingsSingleton.InstanceSettings().IpAddressConfigValue)},
                    { "FirmwaresService", new ClientFirmwareUriFactory(ClientSettingsSingleton.InstanceSettings().IpAddressConfigValue)},
                    { "DevicesService", new ClientDeviceUriFactory(ClientSettingsSingleton.InstanceSettings().IpAddressConfigValue)},
                    { "DepartmentsService", new ClientDepartmentUriFactory(ClientSettingsSingleton.InstanceSettings().IpAddressConfigValue)},
                    { "EmployeeRolesService", new ClientEmployeeRoleUriFactory(ClientSettingsSingleton.InstanceSettings().IpAddressConfigValue)},
                    { "EmployeesService", new ClientEmployeeUriFactory(ClientSettingsSingleton.InstanceSettings().IpAddressConfigValue)},
                    { "UserjwtService", new ClientUserJwtUriFactory(ClientSettingsSingleton.InstanceSettings().IpAddressConfigValue)},
                    { "UserRolesService", new ClientUserRoleUriFactory(ClientSettingsSingleton.InstanceSettings().IpAddressConfigValue)},
                };
    }

    public static ClientUriAddressesRepository UriAddressesRepository { get; } = new ClientUriAddressesRepository();

    public string this[string index]
    {
      get
      {
        if (_clientUriFactory.ContainsKey(index))
        {
          RemoveClientEndpoint(index);
          CreateClientEndpoint(index);
        }
        return _clientUriFactory[index].CreateClientUri();
      }
    }

    private void RemoveClientEndpoint(string clientEndpointAddressName)
    {
      _clientUriFactory.Remove(clientEndpointAddressName);
    }

    private void CreateClientEndpoint(string clientUriAddressName)
    {
      if (clientUriAddressName == "RoutesService")
      {
            _clientUriFactory.Add(clientUriAddressName,
                new ClientRoutesUriFactory(ClientSettingsSingleton.InstanceSettings().IpAddressConfigValue));
      }
      if (clientUriAddressName == "MapService")
      {
        _clientUriFactory.Add(clientUriAddressName,
            new ClientMapUriFactory(ClientSettingsSingleton.InstanceSettings().IpAddressConfigValue));
      }
      if (clientUriAddressName == "MainService")
      {
        _clientUriFactory.Add(clientUriAddressName,
            new ClientDashboardUriFactory(ClientSettingsSingleton.InstanceSettings().IpAddressConfigValue));
      }
      if (clientUriAddressName == "DashboardService")
      {
        _clientUriFactory.Add(clientUriAddressName,
            new ClientDashboardUriFactory(ClientSettingsSingleton.InstanceSettings().IpAddressConfigValue));
      }
      if (clientUriAddressName == "AccountsService")
      {
        _clientUriFactory.Add(clientUriAddressName,
            new ClientAccountUriFactory(ClientSettingsSingleton.InstanceSettings().IpAddressConfigValue));
      }
      if (clientUriAddressName == "UsersService")
      {
        _clientUriFactory.Add(clientUriAddressName,
            new ClientUserUriFactory(ClientSettingsSingleton.InstanceSettings().IpAddressConfigValue));
      }
      if (clientUriAddressName == "VehiclesService")
      {
        _clientUriFactory.Add(clientUriAddressName,
            new ClientVehicleUriFactory(ClientSettingsSingleton.InstanceSettings().IpAddressConfigValue));
      }
      if (clientUriAddressName == "TrackablesService")
      {
        _clientUriFactory.Add(clientUriAddressName,
            new ClientTrackableUriFactory(ClientSettingsSingleton.InstanceSettings().IpAddressConfigValue));
      }
      if (clientUriAddressName == "ToursService")
      {
        _clientUriFactory.Add(clientUriAddressName,
            new ClientTourUriFactory(ClientSettingsSingleton.InstanceSettings().IpAddressConfigValue));
      }
      if (clientUriAddressName == "ContainersService")
      {
        _clientUriFactory.Add(clientUriAddressName,
            new ClientContainerUriFactory(ClientSettingsSingleton.InstanceSettings().IpAddressConfigValue));
      }
      if (clientUriAddressName == "SimcardsService")
      {
          _clientUriFactory.Add(clientUriAddressName,
              new ClientSimcardUriFactory(ClientSettingsSingleton.InstanceSettings().IpAddressConfigValue));
      }
      if (clientUriAddressName == "FirmwaresService")
      {
          _clientUriFactory.Add(clientUriAddressName,
              new ClientFirmwareUriFactory(ClientSettingsSingleton.InstanceSettings().IpAddressConfigValue));
      }
      if (clientUriAddressName == "DevicesService")
      {
        _clientUriFactory.Add(clientUriAddressName,
            new ClientDeviceUriFactory(ClientSettingsSingleton.InstanceSettings().IpAddressConfigValue));
      }
      if (clientUriAddressName == "DepartmentsService")
      {
        _clientUriFactory.Add(clientUriAddressName,
            new ClientDepartmentUriFactory(ClientSettingsSingleton.InstanceSettings().IpAddressConfigValue));
      }
      if (clientUriAddressName == "EmployeeRolesService")
      {
        _clientUriFactory.Add(clientUriAddressName,
            new ClientEmployeeRoleUriFactory(ClientSettingsSingleton.InstanceSettings().IpAddressConfigValue));
      }
      if (clientUriAddressName == "EmployeesService")
      {
        _clientUriFactory.Add(clientUriAddressName,
            new ClientEmployeeUriFactory(ClientSettingsSingleton.InstanceSettings().IpAddressConfigValue));
      }
      if (clientUriAddressName == "UserjwtService")
      {
        _clientUriFactory.Add(clientUriAddressName,
            new ClientUserJwtUriFactory(ClientSettingsSingleton.InstanceSettings().IpAddressConfigValue));
      }
      if (clientUriAddressName == "UserRolesService")
      {
        _clientUriFactory.Add(clientUriAddressName,
            new ClientUserRoleUriFactory(ClientSettingsSingleton.InstanceSettings().IpAddressConfigValue));
      }
    }
  }
}
