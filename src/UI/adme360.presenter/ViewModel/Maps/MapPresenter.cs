using adme360.presenter.Base;
using adme360.presenter.ServiceAgents.Contracts;
using adme360.presenter.ServiceAgents.Impls;
using adme360.presenter.Utilities;
using adme360.view.Controls.Maps;

namespace adme360.presenter.ViewModel.Maps
{
    public class MapPresenter : BasePresenter<IMapView, IMapService>
    {
        public MapPresenter(IMapView view)
            : this(view, new MapService())
        {
        }

        public MapPresenter(IMapView view, MapService service)
            : base(view, service)
        {
        }

        public async void PopulateAddressWithSelectedMapPoint()
        {
            View.PointAddress = await Service.GetAddressFromPoint(View.PointLat, View.PointLon, ClientSettingsSingleton.InstanceSettings().TokenConfigValue);
        }
    }
}
