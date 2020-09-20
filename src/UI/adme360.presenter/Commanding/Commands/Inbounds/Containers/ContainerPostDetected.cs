using dl.wm.models.DTOs.Base;
using dl.wm.presenter.Commanding.Commands.Inbounds.Base;
using dl.wm.presenter.Commanding.Events.Inbound;

namespace dl.wm.presenter.Commanding.Commands.Inbounds.Containers
{
    internal class ContainerPostDetected : InboundCommand
    {
        public ContainerPostDetected(IUiModel model)
        {
            EventRaisingBehavior = new ContainerPostDetectionEventRaising(model);
        }
    }
}