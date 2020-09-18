using magic.button.collector.api.Messaging.Commands.Inbounds.Cmds.Base;

namespace magic.button.collector.api.Messaging.Commands.Inbounds.Cmds
{
  public interface IInboundCommandBuilder
  {
    InboundCommand Build(byte[] package);
  }
}