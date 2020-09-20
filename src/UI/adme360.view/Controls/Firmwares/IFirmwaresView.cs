using System.Collections.Generic;
using adme360.view;
using adme360.models.DTOs.Firmwares;

namespace adme360.view.Controls.Firmwares
{
    public interface IFirmwaresView: IView
    {
        bool NoneFirmwareWasRetrieved { set; }
        List<FirmwareUiModel> Firmwares { get; set; }
    }
}