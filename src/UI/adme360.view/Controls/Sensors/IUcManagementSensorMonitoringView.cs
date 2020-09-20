using System;
using adme360.view;

namespace adme360.view.Controls.Sensors
{
    public interface IUcManagementSensorMonitoringView : IView
    {
        Guid SelectedSensorId { get; set; }

        bool InitialLoadingWasCaught { set; }
    }
}