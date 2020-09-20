using dl.wm.models.DTOs.Simcards;

namespace dl.wm.presenter.Commanding.Events.EventArgs.Simcards
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