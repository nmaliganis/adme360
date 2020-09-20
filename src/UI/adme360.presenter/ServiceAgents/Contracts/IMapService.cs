using System.Collections.Generic;
using System.Threading.Tasks;
using dl.wm.models.DTOs.Dashboards;
using dl.wm.presenter.ServiceAgents.Contracts.Base;

namespace dl.wm.presenter.ServiceAgents.Contracts
{
    public interface IMapService : IEntityService<MapUiModel>
    {
        Task<string> GetAddressFromPoint(double lat , double lon, string authorizationToken = null);
        Task<List<MapUiModel>> GetGeofencePoints(string geofenceId, string authorizationToken = null);
        Task<bool> UpdateGeofenceEntitiesAsync(List<MapUiModel> viewChangedGeofence, string geofenceId, string authorizationToken = null);
    }
}