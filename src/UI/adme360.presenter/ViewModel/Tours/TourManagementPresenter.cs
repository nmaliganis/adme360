using dl.wm.presenter.Base;
using dl.wm.presenter.Helpers;
using dl.wm.presenter.ServiceAgents.Contracts;
using dl.wm.presenter.ServiceAgents.Impls;
using dl.wm.presenter.Utilities;
using dl.wm.view.Controls.Tours;

namespace dl.wm.presenter.ViewModel.Tours
{
    public class TourManagementPresenter : BasePresenter<ITourManagementView, IToursService>
    {

        private readonly string _role = string.Empty;

        public TourManagementPresenter(ITourManagementView view)
            : this(view, new ToursService())
        {
        }

        public TourManagementPresenter(ITourManagementView view, IToursService service)
            : base(view, service)
        {
            _role = JwtHelper.ExtractRoleFromToken(ClientSettingsSingleton.InstanceSettings().TokenConfigValue);
        }

        public void UcLoadedOnDemand()
        {
            View.UcWasLoadedOnDemand = true;
        }

        public void FetchToursByScheduledDateWasToggled()
        {
            
        }
    }
}
