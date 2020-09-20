using adme360.presenter.Commanding.Events.Inbound;
using adme360.presenter.Commanding.Servers.Base;

namespace adme360.presenter.Commanding.Commands.Inbounds.Base
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