using adme360.presenter.Commanding.Events.EventArgs.Containers;

namespace adme360.presenter.Commanding.Listeners.Containers
{
    public interface IContainerPostDetectionActionListener
    {
        void Update(object sender, ContainerEventArgs e);
    }
}