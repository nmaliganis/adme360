using adme360.presenter.Base;
using adme360.presenter.ServiceAgents.Contracts;
using adme360.presenter.ServiceAgents.Impls;
using adme360.view.Controls.Containers;

namespace adme360.presenter.ViewModel.Containers
{
    public class ContainerManagementPresenter : BasePresenter<IContainerManagementView, IContainersService>
    {
        public ContainerManagementPresenter(IContainerManagementView view)
            : this(view, new ContainersService())
        {
        }

        public ContainerManagementPresenter(IContainerManagementView view, IContainersService service)
            : base(view, service)
        {
        }

        public void NavBarModuleLinkClicked()
        {
            View.PopulateUcCtrl = true;
        }
    }
}
