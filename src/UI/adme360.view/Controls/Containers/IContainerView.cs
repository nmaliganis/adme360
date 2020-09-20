using System;
using adme360.models.DTOs.Containers;

namespace adme360.view.Controls.Containers
{
    public interface IContainerView : IMsgView
    {
        ContainerUiModel Container { set; }
        Guid SelectedContainerId { get; set; }
    }
}