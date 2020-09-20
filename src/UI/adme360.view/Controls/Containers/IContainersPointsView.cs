using System.Collections.Generic;
using adme360.view;
using adme360.models.DTOs.Containers;

namespace adme360.view.Controls.Containers
{
    public interface IContainersPointsView : IView

    {
        bool NoneContainerPointWasRetrieved { set; }
        List<ContainerPointUiModel> ContainersPoints { set; }
        string OnContainerPointsMsgError { set; }
    }
}