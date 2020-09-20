using adme360.models.DTOs.Simcards;

namespace adme360.presenter.Commanding.Events.EventArgs.Simcards
{
    public class SimcardEventArgs : System.EventArgs
    {
        public SimcardUiModel Simcard { get; private set; }

        public SimcardEventArgs(SimcardUiModel simcard)
        {
            this.Simcard = simcard;
        }
    }
}