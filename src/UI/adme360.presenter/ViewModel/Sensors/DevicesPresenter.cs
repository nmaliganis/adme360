using adme360.presenter.Base;
using adme360.presenter.ServiceAgents.Contracts;
using adme360.presenter.ServiceAgents.Impls;
using adme360.presenter.Utilities;
using adme360.view.Controls.Sensors;

namespace adme360.presenter.ViewModel.Sensors
{
    public class DevicesPresenter : BasePresenter<IDevicesView, IDevicesService>
    {
        public DevicesPresenter(IDevicesView view)
            : this(view, new DevicesService())
        {
        }

        public DevicesPresenter(IDevicesView view, IDevicesService service)
            : base(view, service)
        {
        }

        public async void LoadAllDevices()
        {
            var devices = await Service.GetEntitiesAsync(ClientSettingsSingleton.InstanceSettings().TokenConfigValue);

            if (devices?.Count == 0)
                View.NoneDeviceWasRetrieved = true;
            else
            {
                View.Devices = devices;
            }
        }
        public async void LoadAllDevicesWithoutSimcard()
        {
            var devices = await Service.GetAllActiveDevicesWithoutSimcardAssignedAsync(true, ClientSettingsSingleton.InstanceSettings().TokenConfigValue);

            if (devices?.Count == 0)
                View.NoneDeviceWasRetrieved = true;
            else
            {
                View.Devices = devices;
            }
        }
    }
}