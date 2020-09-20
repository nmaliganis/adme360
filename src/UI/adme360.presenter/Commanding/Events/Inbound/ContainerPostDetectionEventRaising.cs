using adme360.models.DTOs.Base;
using adme360.models.DTOs.Containers;
using adme360.presenter.Commanding.Servers.Base;

namespace adme360.presenter.Commanding.Events.Inbound
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