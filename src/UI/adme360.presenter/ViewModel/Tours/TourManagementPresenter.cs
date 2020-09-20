using adme360.presenter.Base;
using adme360.presenter.Helpers;
using adme360.presenter.ServiceAgents.Contracts;
using adme360.presenter.ServiceAgents.Impls;
using adme360.presenter.Utilities;
using adme360.view.Controls.Tours;

namespace adme360.presenter.ViewModel.Tours
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
