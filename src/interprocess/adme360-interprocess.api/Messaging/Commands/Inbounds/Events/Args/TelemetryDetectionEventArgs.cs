namespace magic.button.collector.api.Messaging.Commands.Inbounds.Events.Args
{
  public class TelemetryDetectionEventArgs : System.EventArgs
  {
    public string Topic { get; private set; }
    public string Payload { get; private set; }
    public bool Success { get; private set; }

    public TelemetryDetectionEventArgs(string payload, string topic, bool success)
    {
      this.Topic = topic;
      this.Payload = payload;
      this.Success = success;
    }
  }
}