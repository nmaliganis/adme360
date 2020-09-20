using dl.wm.presenter.Commanding.Events.EventArgs.Containers;

namespace dl.wm.presenter.Commanding.Listeners.Containers
{
    public interface IContainerPutDetectionActionListener
    {
        void Update(object sender, ContainerEventArgs e);
    }
}