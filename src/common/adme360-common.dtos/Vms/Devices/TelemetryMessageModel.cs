using System;

namespace adme360.common.dtos.Vms.Devices
{
  public class TelemetryMessageModel
  {
    public string deviceid { get; set; }
    public Guid correlationId { get; set; }
    public DateTime timestamp { get; set; }
    public int buttonStatus { get; set; }
    public double batValue { get; set; }
    public double tempValue { get; set; }
    public string  rssi { get; set; }
    public string  snr { get; set; }
  }
}