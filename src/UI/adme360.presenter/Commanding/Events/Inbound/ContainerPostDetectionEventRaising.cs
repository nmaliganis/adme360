using dl.wm.models.DTOs.Base;
using dl.wm.models.DTOs.Containers;
using dl.wm.presenter.Commanding.Servers.Base;

namespace dl.wm.presenter.Commanding.Events.Inbound
{
    public class ContainerPostDetectionEventRaising : IInboundEventRaisingBehavior
    {
        public IUiModel Model { get; }

        public ContainerPostDetectionEventRaising(IUiModel model)
        {
            Model = model;
        }

        public void RaiseEvent(CommandingInboundBaseServer inboundEventServer)
        {
            inboundEventServer.RaiseContainerPostDetection((ContainerUiModel)Model);
        }
    }
}