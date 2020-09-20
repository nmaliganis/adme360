using System;
using adme360.view;

namespace adme360.view.Controls.Sensors
{
    public interface IUcManagementSensorSettingsSimcardView : IView
    {
        Guid SelectedSimcardId { get; set; }

        bool OpenFlyoutForAddSimcard { set; }
        bool OpenFlyoutForEditSimcard { set; }
        bool InitialLoadingWasCaught { set; }
        bool RemoveSimcardWasCaught { set; }
    }
}