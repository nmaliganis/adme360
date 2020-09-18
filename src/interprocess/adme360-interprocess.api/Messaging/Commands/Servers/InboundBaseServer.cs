using System;
using magic.button.collector.api.Messaging.Commands.Inbounds.Events.Args;
using magic.button.collector.api.Messaging.Commands.Inbounds.Events.Listeners;

namespace magic.button.collector.api.Messaging.Commands.Servers
{
  public abstract class InboundBaseServer
  {
    public event EventHandler<TelemetryDetectionEventArgs> TelemetryDetector;

    #region Telemetry detection Event Manipulation

    private void OnTelemetryDetection(TelemetryDetectionEventArgs e)
    {
      TelemetryDetector?.Invoke(this, e);
    }

    public void RaiseTelemetryDetection(string payload, string topic)
    {
      OnTelemetryDetection(new TelemetryDetectionEventArgs(payload, topic, true));
    }

    public void Attach(ITelemetryDetectionActionListener listener)
    {
      TelemetryDetector += listener.Update;
    }

    public void Detach(ITelemetryDetectionActionListener listener)
    {
      TelemetryDetector -= listener.Update;
    }

    #endregion
  }
}