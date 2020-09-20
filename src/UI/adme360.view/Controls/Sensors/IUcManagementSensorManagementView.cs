using System;
using adme360.view;

namespace adme360.view.Controls.Sensors
{
    public interface IUcManagementSensorManagementView : IView
    {
        Guid SelectedSensorId { get; set; }

        bool InitialLoadingWasCaught { set; }
        bool OpenFlyoutForAddSensor { set; }
        bool OpenFlyoutForEditSensor { set; }
        bool RemoveSensorWasCaught { set; }
    }
}