using dl.wm.presenter.ServiceAgents.Contracts;
using dl.wm.presenter.ServiceAgents.Impls;
using dl.wm.view.Controls.Containers;
using dl.wm.presenter.Base;

namespace dl.wm.presenter.ViewModel.Containers
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
