using adme360.models.DTOs.Base;
using adme360.presenter.Commanding.Commands.Inbounds.Base;
using adme360.presenter.Commanding.Events.Inbound;

namespace adme360.presenter.Commanding.Commands.Inbounds.Containers
{
    internal class ContainerPostDetected : InboundCommand
    {
        public ContainerPostDetected(IUiModel model)
        {
            EventRaisingBehavior = new ContainerPostDetectionEventRaising(model);
        }
    }
}