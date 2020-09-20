using dl.wm.models.DTOs.Base;
using dl.wm.presenter.Commanding.Commands.Inbounds.Base;

namespace dl.wm.presenter.Commanding.Commands.Inbounds.Containers
{
    public class ContainerPostDetectedInboundCommandBuilder : InboundCommandBuilder, IInboundCommandBuilder
    {
        public InboundCommand Build(byte[] message)
        {
            return new ContainerPostDetected(BuildMessage(message));
        }

        public override void BuildPayload()
        {
            //Todo: Refactoring to support abstract builder for Attribute JSON
        }
    }
}