using adme360.models.DTOs.Base;
using adme360.presenter.Commanding.Commands.Inbounds.Base;

namespace adme360.presenter.Commanding
{
    public interface IInboundCommandBuilder
    {
        InboundCommand Build(byte[] message);
    }
}