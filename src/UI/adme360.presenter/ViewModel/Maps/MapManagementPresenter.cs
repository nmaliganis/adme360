using dl.wm.presenter.ServiceAgents.Contracts;
using dl.wm.presenter.ServiceAgents.Impls;
using dl.wm.presenter.Utilities;
using dl.wm.view.Controls.Dashboards;
using dl.wm.view.Controls.Dashboards.Maps;
using dl.wm.presenter.Base;

namespace dl.wm.presenter.ViewModel.Maps
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
