using magic.button.collector.api.Messaging.Commands.Inbounds.Events;
using magic.button.collector.api.Messaging.Commands.Servers;

namespace magic.button.collector.api.Messaging.Commands.Inbounds.Cmds.Base
{
  public abstract class InboundCommand
  {
    public IInboundEventRaisingBehavior EventRaisingBehavior { get; set; }

    public void RaiseEvent(InboundBaseServer inboundEventServer)
    {
      EventRaisingBehavior.RaiseWmEvent(inboundEventServer);
    }
  }
}