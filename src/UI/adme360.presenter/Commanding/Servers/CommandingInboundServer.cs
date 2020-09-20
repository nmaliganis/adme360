using dl.wm.presenter.Commanding.Servers.Base;

namespace dl.wm.presenter.Commanding.Servers
{
    public sealed class CommandingInboundServer : CommandingInboundBaseServer
    {
        private CommandingInboundServer()
        {

        }
        public static CommandingInboundServer GetCommandingInboundServer { get; } = new CommandingInboundServer();
    }
}