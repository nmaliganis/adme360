using dl.wm.presenter.Base;
using dl.wm.presenter.ServiceAgents.Contracts;
using dl.wm.presenter.ServiceAgents.Impls;
using dl.wm.view.Controls.Routes;

namespace dl.wm.presenter.ViewModel.Routes
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