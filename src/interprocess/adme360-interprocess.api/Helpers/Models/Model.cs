using System;

namespace magic.button.collector.api.Helpers.Models
{
  public class Model
  {
    public Guid deviceid { get; set; }
    public string value { get; set; }
    public DateTime timestamp { get; set; }
  }
}