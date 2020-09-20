using dl.wm.presenter.Base;
using dl.wm.presenter.ServiceAgents.Contracts;
using dl.wm.presenter.ServiceAgents.Impls;
using dl.wm.presenter.Utilities;
using dl.wm.view.Controls.Sensors;

namespace dl.wm.presenter.ViewModel.Sensors
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