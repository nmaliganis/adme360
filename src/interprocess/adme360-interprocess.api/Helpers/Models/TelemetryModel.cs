using System;

namespace magic.button.collector.api.Helpers.Models
{
  public class TelemetryModel
  {
    public string deviceid { get; set; }
    public Guid correlationId { get; set; }
    public DateTime timestamp { get; set; }
    public string buttonStatus { get; set; }
    public double batValue { get; set; }
    public double tempValue { get; set; }
    public string  rssi { get; set; }
    public string  snr { get; set; }
  }
}