using adme360.presenter.Base;
using adme360.presenter.ServiceAgents.Contracts;
using adme360.presenter.ServiceAgents.Impls;
using adme360.presenter.Utilities;
using adme360.view.Controls.Tours;

namespace adme360.presenter.ViewModel.Tours
{
    public class ToursPresenter : BasePresenter<IToursView, IToursService>
    {
        public ToursPresenter(IToursView view)
            : this(view, new ToursService())
        {
        }

        public ToursPresenter(IToursView view, IToursService service)
            : base(view, service)
        {
        }

        public async void LoadAllTours()
        {
            var tours = await Service.GetEntitiesAsync(ClientSettingsSingleton.InstanceSettings().TokenConfigValue);

            if (tours?.Count == 0)
                View.NoneTourWasRetrieved = true;
            else
            {
                View.Tours = tours;
            }
        }
    }
}