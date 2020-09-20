using dl.wm.presenter.ServiceAgents.Contracts;
using dl.wm.presenter.ServiceAgents.Impls;
using dl.wm.presenter.Utilities;
using dl.wm.view.Controls.Vehicles;
using dl.wm.presenter.Base;

namespace dl.wm.presenter.ViewModel.Vehicles
{
    public class VehiclesPresenter : BasePresenter<IVehiclesView, IVehiclesService>
    {
        public VehiclesPresenter(IVehiclesView view)
            : this(view, new VehiclesService())
        {
        }

        public VehiclesPresenter(IVehiclesView view, IVehiclesService service)
            : base(view, service)
        {
        }

        public async void LoadAllVehicles()
        {
            var vehicles = await Service.GetEntitiesAsync(ClientSettingsSingleton.InstanceSettings().TokenConfigValue);

            if (vehicles?.Count == 0)
                View.NoneVehicleWasRetrieved = true;
            else
            {
                View.Vehicles = vehicles;
            }
        }
    }
}