using adme360.presenter.Commanding.Events.EventArgs.Simcards;

namespace adme360.presenter.Commanding.Listeners.Simcards
{
    public interface ISimcardPutDetectionActionListener
    {
        void Update(object sender, SimcardEventArgs e);
    }
}