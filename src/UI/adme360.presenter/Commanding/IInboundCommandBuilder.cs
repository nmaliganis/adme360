using dl.wm.models.DTOs.Base;
using dl.wm.presenter.Commanding.Commands.Inbounds.Base;

namespace dl.wm.presenter.Commanding
{
    public interface IInboundCommandBuilder
    {
        InboundCommand Build(byte[] message);
    }
}