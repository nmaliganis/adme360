using dl.wm.presenter.ServiceAgents.Contracts;
using dl.wm.presenter.ServiceAgents.Impls;
using dl.wm.view.Controls.Containers;
using dl.wm.presenter.Base;

namespace dl.wm.presenter.ViewModel.Containers
{
    public class UcMonitoringContainerManagementPresenter : BasePresenter<IUcMonitoringContainerManagementView, IContainersService>
    {
        public UcMonitoringContainerManagementPresenter(IUcMonitoringContainerManagementView view)
            : this(view, new ContainersService())
        {
        }

        public UcMonitoringContainerManagementPresenter(IUcMonitoringContainerManagementView view, IContainersService service)
            : base(view, service)
        {
        }
    }
}