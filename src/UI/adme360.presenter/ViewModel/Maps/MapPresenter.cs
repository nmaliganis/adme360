using dl.wm.presenter.ServiceAgents.Contracts;
using dl.wm.presenter.ServiceAgents.Impls;
using dl.wm.presenter.Base;
using dl.wm.presenter.Utilities;
using dl.wm.view.Controls.Maps;

namespace dl.wm.presenter.ViewModel.Maps
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
