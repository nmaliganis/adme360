using adme360.presenter.Base;
using adme360.presenter.ServiceAgents.Contracts;
using adme360.presenter.ServiceAgents.Impls;
using adme360.presenter.Utilities;
using adme360.view.Controls.Vehicles;

namespace adme360.presenter.ViewModel.Vehicles
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