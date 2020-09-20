using System.Collections.Generic;

namespace adme360.cms.api.Helpers.Loggings
{
  public class LoggingModel
  {
    public string Name { get; set; }
    public string Path { get; set; }
    public string Host { get; set; }
    public string Method { get; set; }

    public List<KeyValuePair<string, string>> UserClaims { get; set; }
  }
}