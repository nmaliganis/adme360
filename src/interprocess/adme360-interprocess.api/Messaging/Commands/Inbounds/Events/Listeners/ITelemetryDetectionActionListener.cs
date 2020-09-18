using magic.button.collector.api.Messaging.Commands.Inbounds.Events.Args;

namespace magic.button.collector.api.Messaging.Commands.Inbounds.Events.Listeners
{
  public interface ITelemetryDetectionActionListener
  {
    void Update(object sender, TelemetryDetectionEventArgs e);
  }
}