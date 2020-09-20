using adme360.presenter.Base;
using adme360.presenter.ServiceAgents.Contracts;
using adme360.presenter.ServiceAgents.Impls;
using adme360.view.Controls.Routes;

namespace adme360.presenter.ViewModel.Routes
{
    public class UcRoutesManagementPresenter : BasePresenter<IUcRoutesManagementView, IRoutesService> 
    {
        public UcRoutesManagementPresenter(IUcRoutesManagementView view)
            : this(view, new RoutesService())
        {
        }

        public UcRoutesManagementPresenter(IUcRoutesManagementView view, IRoutesService service)
            : base(view, service)
        {
        }

        public void UcWasLoaded()
        {
            View.InitialLoadingWasCaught = true;
        }
    }
}