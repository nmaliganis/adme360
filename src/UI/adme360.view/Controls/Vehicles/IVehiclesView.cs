using System.Collections.Generic;
using adme360.models.DTOs.Vehicles;
using adme360.view;

namespace adme360.view.Controls.Vehicles
{
    public interface IVehiclesView : IMsgView
    {
        List<VehicleUiModel> Vehicles { get; set; }
        bool NoneVehicleWasRetrieved { set; }
    }
}