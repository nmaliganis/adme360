using adme360.presenter.Commanding.Events.EventArgs.Devices;

namespace adme360.presenter.Commanding.Listeners.Devices
{
    public interface IDevicePostDetectionActionListener
    {
        void Update(object sender, DeviceEventArgs e);
    }
}