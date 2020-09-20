using dl.wm.presenter.ServiceAgents.Contracts;
using dl.wm.presenter.ServiceAgents.Impls;
using dl.wm.view.Controls.Evts;
using dl.wm.presenter.Base;

namespace dl.wm.presenter.ViewModel.Etvs
{
    public class UcEvtManagementPresenter : BasePresenter<IUcEvtManagementView, IVehiclesService>
    {

        public UcEvtManagementPresenter(IUcEvtManagementView view)
            : this(view, new VehiclesService())
        {
        }

        public UcEvtManagementPresenter(IUcEvtManagementView view, IVehiclesService service)
            : base(view, service)
        {
        }

        public void NavBarModuleLinkClicked()
        {
            View.PopulateUcCtrl = true;
        }
    }
}