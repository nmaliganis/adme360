using dl.wm.models.DTOs.Devices;

namespace dl.wm.presenter.Commanding.Events.EventArgs.Devices
{
    public class DeviceEventArgs : System.EventArgs
    {
        public DeviceUiModel Device { get; private set; }

        public DeviceEventArgs(DeviceUiModel device)
        {
            this.Device = device;
        }
    }
}