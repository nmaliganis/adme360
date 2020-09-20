using System.Collections.Generic;
using adme360.view;
using adme360.models.DTOs.Dashboards;

namespace adme360.view.Controls.Dashboards.Maps
{
    public interface IMapManagementView : IView
    {
        List<MapUiModel> Geofence { get; set; }
        List<MapUiModel> ChangedGeofence { get; set; }
        bool NoneGeofencePointWasRetrieved { set; }
        bool CanAddPointToMap { get; set; }
        bool ToggleCanAddPointToMap { get; set; }
        bool ChkPopulateGeofenceOnDemand { get; set; }
    }
}
