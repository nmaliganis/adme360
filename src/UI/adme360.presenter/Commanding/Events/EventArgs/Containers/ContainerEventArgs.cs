using dl.wm.models.DTOs.Containers;

namespace dl.wm.presenter.Commanding.Events.EventArgs.Containers
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