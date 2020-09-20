using adme360.models.DTOs.Devices;

namespace adme360.presenter.Commanding.Events.EventArgs.Devices
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