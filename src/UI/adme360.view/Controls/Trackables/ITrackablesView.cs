using System.Collections.Generic;
using adme360.models.DTOs.Trackables;
using adme360.view;

namespace adme360.view.Controls.Trackables
{
    public interface ITrackablesView : IMsgView
    {
        List<TrackableUiModel> Trackables { get; set; }
        bool NoneTrackableWasRetrieved { set; }
    }
}