using dl.wm.presenter.Base;
using dl.wm.presenter.ServiceAgents.Contracts;
using dl.wm.presenter.ServiceAgents.Impls;
using dl.wm.presenter.Utilities;
using dl.wm.view.Controls.Tours;

namespace dl.wm.presenter.ViewModel.Tours
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