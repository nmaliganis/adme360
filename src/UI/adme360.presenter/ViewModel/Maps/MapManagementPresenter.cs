using adme360.presenter.Base;
using adme360.presenter.ServiceAgents.Contracts;
using adme360.presenter.ServiceAgents.Impls;
using adme360.presenter.Utilities;
using adme360.view.Controls.Dashboards;
using adme360.view.Controls.Dashboards.Maps;

namespace adme360.presenter.ViewModel.Maps
{
    public class MapManagementPresenter : BasePresenter<IMapManagementView, IMapService>
    {
        public MapManagementPresenter(IMapManagementView view)
            : this(view, new MapService())
        {
        }

        public MapManagementPresenter(IMapManagementView view, MapService service)
            : base(view, service)
        {
        }

        public async void LoadDashboardGeofence()
        {
            var geofenceMapPoints = await Service.GetGeofencePoints("", ClientSettingsSingleton.InstanceSettings().TokenConfigValue);

            if (geofenceMapPoints?.Count == 0)
                View.NoneGeofencePointWasRetrieved = true;
            else
            {
                View.Geofence = geofenceMapPoints;
            }
        }

        public void ToggleAddRemoveDumpsterWasClicked()
        {
            
        }

        public async void StoreGeofenceWasClicked()
        {
            await Service.UpdateGeofenceEntitiesAsync(View.ChangedGeofence, "", ClientSettingsSingleton.InstanceSettings().TokenConfigValue);
        }

        public void AddOrNotGeofencepoint()
        {
            View.CanAddPointToMap = true;
        }
    }
}
