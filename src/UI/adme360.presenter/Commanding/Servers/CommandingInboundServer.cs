using adme360.presenter.Commanding.Servers.Base;

namespace adme360.presenter.Commanding.Servers
{
    public sealed class CommandingInboundServer : CommandingInboundBaseServer
    {
        private CommandingInboundServer()
        {

        }
        public static CommandingInboundServer GetCommandingInboundServer { get; } = new CommandingInboundServer();
    }
}