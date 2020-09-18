using magic.button.collector.api.Messaging.Commands.Servers;

namespace magic.button.collector.api.Messaging.Commands.Inbounds.Events
{
  public class TelemetryDetectionEventRaising : IInboundEventRaisingBehavior
  {
    public string Payload { get; private set; }
    public string Topic { get; private set; }

    public TelemetryDetectionEventRaising(string payload, string topic)
    {
      this.Payload = payload;
      this.Topic = topic;
    }

    public void RaiseWmEvent(InboundBaseServer inboundEventServer)
    {
      inboundEventServer.RaiseTelemetryDetection(Payload, Topic);
    }
  }
}