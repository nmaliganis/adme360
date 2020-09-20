using dl.wm.presenter.Commanding.Events.Inbound;
using dl.wm.presenter.Commanding.Servers.Base;

namespace dl.wm.presenter.Commanding.Commands.Inbounds.Base
{

    public interface ICommand
    {
    }

    public abstract class Command : ICommand
    {
    }

    public abstract class InboundCommand : Command
    {
        public IInboundEventRaisingBehavior EventRaisingBehavior { get; set; }

        public void RaiseEvent(CommandingInboundBaseServer inboundEventServer)
        {
            EventRaisingBehavior.RaiseEvent(inboundEventServer);
        }
    }
}