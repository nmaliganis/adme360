using System;

namespace magic.button.collector.api.Commanding.Args
{
  public class TelemetryStoringEventArgs : EventArgs
  {
    public string Payload { get; private set; }
    public bool Success { get; private set; }
    public string SerialNumber { get; private set; }

    public TelemetryStoringEventArgs(string payload, bool success, string serialNumber)
    {
      this.Payload = payload;
      this.Success = success;
      this.SerialNumber = serialNumber;
    }
  }
}