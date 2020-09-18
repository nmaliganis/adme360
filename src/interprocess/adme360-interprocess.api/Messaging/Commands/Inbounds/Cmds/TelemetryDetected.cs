using magic.button.collector.api.Messaging.Commands.Inbounds.Cmds.Base;
using magic.button.collector.api.Messaging.Commands.Inbounds.Events;

namespace magic.button.collector.api.Messaging.Commands.Inbounds.Cmds
{
  internal class TelemetryDetected : InboundCommand
  {
    private readonly string _topic;
    private readonly string _payload;

    public TelemetryDetected(string payload, string topic)
    {
      _topic = topic;
      _payload = payload;
      EventRaisingBehavior = new TelemetryDetectionEventRaising(_payload, topic);
    }
  }
}