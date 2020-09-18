namespace magic.button.collector.api.Messaging.Commands.Servers
{
  public sealed class InboundServer : InboundBaseServer
  {
    private InboundServer()
    {

    }
    public static InboundServer GetInboundServer { get; } = new InboundServer();
  }
}
