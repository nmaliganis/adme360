using dl.wm.presenter.ServiceAgents.Contracts;
using dl.wm.presenter.ServiceAgents.Impls;
using dl.wm.presenter.Utilities;
using dl.wm.view.Controls.Containers;
using dl.wm.presenter.Base;

namespace dl.wm.presenter.ViewModel.Containers
{
    public class ContainersPresenter : BasePresenter<IContainersView, IContainersService>
    {
        public ContainersPresenter(IContainersView view)
            : this(view, new ContainersService())
        {
        }

        public ContainersPresenter(IContainersView view, IContainersService service)
            : base(view, service)
        {
        }

        public async void LoadAllContainers()
        {
            var containers =
                await Service.GetEntitiesAsync(ClientSettingsSingleton.InstanceSettings().TokenConfigValue);

            if (containers?.Count == 0)
                View.NoneContainerWasRetrieved = true;
            else
            {
                View.Containers = containers;
            }
        }
        public async void LoadAllContainersWithoutDevice()
        {
            var containers =
                await Service.GetAllActiveContainersWithoutDeviceAssignedAsync(true, ClientSettingsSingleton.InstanceSettings().TokenConfigValue);

            if (containers?.Count == 0)
                View.NoneContainerWasRetrieved = true;
            else
            {
                View.Containers = containers;
            }
        }
    }
}