using System.Collections.Generic;
using adme360.models.DTOs.Devices;

namespace adme360.view.Controls.Sensors
{
    public interface IDevicesView : IMsgView
    {
        List<DeviceUiModel> Devices { get; set; }
        bool NoneDeviceWasRetrieved { set; }
    }
}