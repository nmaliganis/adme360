using magic.button.collector.api.Messaging.Commands.Servers;

namespace magic.button.collector.api.Messaging.Commands.Inbounds.Events

{
  public interface IInboundEventRaisingBehavior
  {
    void RaiseWmEvent(InboundBaseServer inboundEventServer);
  }
}