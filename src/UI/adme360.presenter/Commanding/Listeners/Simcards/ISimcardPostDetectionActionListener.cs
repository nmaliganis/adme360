using adme360.presenter.Commanding.Events.EventArgs.Simcards;

namespace adme360.presenter.Commanding.Listeners.Simcards
{
    public interface ISimcardPostDetectionActionListener
    {
        void Update(object sender, SimcardEventArgs e);
    }
}