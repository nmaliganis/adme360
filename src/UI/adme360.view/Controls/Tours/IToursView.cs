using System.Collections.Generic;
using adme360.models.DTOs.Tours;
using adme360.models.DTOs.Trackables;

namespace adme360.view.Controls.Tours
{
    public interface IToursView : IMsgView
    {
        List<TourUiModel> Tours { get; set; }
        bool NoneTourWasRetrieved { set; }
    }
}