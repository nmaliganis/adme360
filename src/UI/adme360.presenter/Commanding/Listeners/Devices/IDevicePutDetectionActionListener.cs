using adme360.presenter.Commanding.Events.EventArgs.Devices;

namespace adme360.presenter.Commanding.Listeners.Devices
{
    public interface IDevicePutDetectionActionListener
    {
        void Update(object sender, DeviceEventArgs e);
    }
}