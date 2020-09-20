using adme360.presenter.Base;
using adme360.presenter.ServiceAgents.Contracts;
using adme360.presenter.ServiceAgents.Impls;
using adme360.presenter.Utilities;
using adme360.view.Controls.Simcards;

namespace adme360.presenter.ViewModel.Simcards
{
    public class SimcardsPresenter : BasePresenter<ISimcardsView, ISimcardsService>
    {
        public SimcardsPresenter(ISimcardsView view)
            : this(view, new SimcardsService())
        {
        }

        public SimcardsPresenter(ISimcardsView view, ISimcardsService service)
            : base(view, service)
        {
        }

        public async void LoadAllSimcards()
        {
            var simcards = await Service.GetEntitiesAsync(ClientSettingsSingleton.InstanceSettings().TokenConfigValue);

            if (simcards?.Count == 0)
                View.NoneSimcardWasRetrieved = true;
            else
            {
                View.Simcards = simcards;
            }
        }
    }
}