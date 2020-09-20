using adme360.models.DTOs.Containers;

namespace adme360.presenter.Commanding.Events.EventArgs.Containers
{
    public class ContainerEventArgs : System.EventArgs
    {
        public ContainerUiModel Container { get; private set; }

        public ContainerEventArgs(ContainerUiModel container)
        {
            this.Container = container;
        }
    }
}