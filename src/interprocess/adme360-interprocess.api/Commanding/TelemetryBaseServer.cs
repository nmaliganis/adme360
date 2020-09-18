using System;
using magic.button.collector.api.Commanding.Args;
using magic.button.collector.api.Commanding.Listeners;

namespace magic.button.collector.api.Commanding
{
  public abstract class TelemetryBaseServer
  {
    public event EventHandler<TelemetryStoringEventArgs> TelemetryStoringDetector;

    #region Telemetry Storing Request detection Event Manipulation

    private void OnTelemetryStoringDetection(TelemetryStoringEventArgs e)
    {
      TelemetryStoringDetector?.Invoke(this, e);
    }

    public void RaiseTelemetryStoringDetection(string payload, string serialNumber)
    {
      OnTelemetryStoringDetection(new TelemetryStoringEventArgs(payload, true, serialNumber));
    }

    public void Attach(ITelemetryStoringActionListener listener)
    {
      TelemetryStoringDetector += listener.Update;
    }

    public void Detach(ITelemetryStoringActionListener listener)
    {
      TelemetryStoringDetector -= listener.Update;
    }

    #endregion
  }
}