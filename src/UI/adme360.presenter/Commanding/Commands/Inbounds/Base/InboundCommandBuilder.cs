using System;
using System.Text;
using dl.wm.models.DTOs.Base;

namespace dl.wm.presenter.Commanding.Commands.Inbounds.Base
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
