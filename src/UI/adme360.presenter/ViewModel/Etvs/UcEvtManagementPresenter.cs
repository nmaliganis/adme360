using adme360.presenter.Base;
using adme360.presenter.ServiceAgents.Contracts;
using adme360.presenter.ServiceAgents.Impls;
using adme360.view.Controls.Evts;

namespace adme360.presenter.ViewModel.Etvs
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