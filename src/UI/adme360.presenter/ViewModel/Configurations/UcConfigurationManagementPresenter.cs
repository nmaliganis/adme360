using dl.wm.presenter.ServiceAgents.Contracts;
using dl.wm.presenter.ServiceAgents.Impls;
using dl.wm.presenter.Base;
using dl.wm.view.Controls.Configurations;

namespace dl.wm.presenter.ViewModel.Configurations
{
    public class UcConfigurationManagementPresenter : BasePresenter<IUcCnfigurationManagementView, IVehiclesService>
    {
        public UcConfigurationManagementPresenter(IUcCnfigurationManagementView view)
            : this(view, new VehiclesService())
        {
        }
        public UcConfigurationManagementPresenter(IUcCnfigurationManagementView view, IVehiclesService service)
            : base(view, service)
        {
        }

        public void NavBarModuleLinkClicked()
        {
            View.PopulateUcCtrl = true;
        }
    }
}