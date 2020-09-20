using adme360.presenter.Base;
using adme360.presenter.ServiceAgents.Contracts;
using adme360.presenter.ServiceAgents.Impls;
using adme360.presenter.Utilities;
using adme360.view.Controls.Containers;

namespace adme360.presenter.ViewModel.Containers
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