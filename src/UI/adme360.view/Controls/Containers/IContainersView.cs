using System.Collections.Generic;
using adme360.view;
using adme360.models.DTOs.Containers;

namespace adme360.view.Controls.Containers
{
    public interface IContainersView: IView
    {
    bool NoneContainerWasRetrieved { set; }
    List<ContainerUiModel> Containers { get; set; }
    }
}
