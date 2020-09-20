using adme360.presenter.Commanding.Events.EventArgs.Containers;

namespace adme360.presenter.Commanding.Listeners.Containers
{
    public interface IContainerPutDetectionActionListener
    {
        void Update(object sender, ContainerEventArgs e);
    }
}