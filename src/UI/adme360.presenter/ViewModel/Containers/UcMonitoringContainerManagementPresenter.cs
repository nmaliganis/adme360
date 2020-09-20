using adme360.presenter.Base;
using adme360.presenter.ServiceAgents.Contracts;
using adme360.presenter.ServiceAgents.Impls;
using adme360.view.Controls.Containers;

namespace adme360.presenter.ViewModel.Containers
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