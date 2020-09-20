using dl.wm.presenter.Commanding.Events.EventArgs.Devices;

namespace dl.wm.presenter.Commanding.Listeners.Devices
{
    public interface IDevicePutDetectionActionListener
    {
        void Update(object sender, DeviceEventArgs e);
    }
}