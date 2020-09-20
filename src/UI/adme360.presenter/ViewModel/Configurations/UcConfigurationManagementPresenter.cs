using adme360.presenter.Base;
using adme360.view.Controls.Configurations;
using adme360.presenter.ServiceAgents.Contracts;
using adme360.presenter.ServiceAgents.Impls;

namespace adme360.presenter.ViewModel.Configurations
{
    public class UcConfigurationManagementPresenter : BasePresenter<IUcConfigurationManagementView, IVehiclesService>
    {
        public UcConfigurationManagementPresenter(IUcConfigurationManagementView view)
            : this(view, new VehiclesService())
        {
        }
        public UcConfigurationManagementPresenter(IUcConfigurationManagementView view, IVehiclesService service)
            : base(view, service)
        {
        }

        public void NavBarModuleLinkClicked()
        {
            View.PopulateUcCtrl = true;
        }
    }
}