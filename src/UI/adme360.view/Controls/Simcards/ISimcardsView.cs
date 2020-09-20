using System.Collections.Generic;
using adme360.view;
using adme360.models.DTOs.Simcards;

namespace adme360.view.Controls.Simcards
{
    public interface ISimcardsView : IView

    {
        bool NoneSimcardWasRetrieved { set; }
        List<SimcardUiModel> Simcards { get; set; }
    }
}