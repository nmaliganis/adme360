namespace magic.button.collector.api.Commanding
{
  public sealed class TelemetryServer : TelemetryBaseServer
  {
    private TelemetryServer()
    {

    }
    public static TelemetryServer GetTelemetryServer { get; } = new TelemetryServer();
  }
}