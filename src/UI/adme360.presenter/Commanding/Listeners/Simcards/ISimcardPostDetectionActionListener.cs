using dl.wm.presenter.Commanding.Events.EventArgs.Simcards;

namespace dl.wm.presenter.Commanding.Listeners.Simcards
{
    public interface ISimcardPostDetectionActionListener
    {
        void Update(object sender, SimcardEventArgs e);
    }
}