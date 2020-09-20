using adme360.presenter.Commanding.Servers.Base;

namespace adme360.presenter.Commanding.Events.Inbound

{
    public interface IInboundEventRaisingBehavior
    {
        void RaiseEvent(CommandingInboundBaseServer inboundEventServer);
    }
}