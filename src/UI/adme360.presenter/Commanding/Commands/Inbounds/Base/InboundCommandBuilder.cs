using System;
using System.Text;
using adme360.models.DTOs.Base;

namespace adme360.presenter.Commanding.Commands.Inbounds.Base
{
    public abstract class InboundCommandBuilder
    {
        public abstract void BuildPayload();

        protected virtual IUiModel BuildMessage(byte[] package)
        {
            BuildPayload();
            return Model;
        }

        public IUiModel Model { get; set; }
    }
}
