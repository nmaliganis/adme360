using dl.wm.presenter.Commanding.Events.EventArgs.Devices;

namespace dl.wm.presenter.Commanding.Listeners.Devices
{
    public interface IDevicePostDetectionActionListener
    {
        void Update(object sender, DeviceEventArgs e);
    }
}