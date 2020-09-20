using dl.wm.presenter.ServiceAgents.Contracts;
using dl.wm.presenter.ServiceAgents.Impls;
using dl.wm.presenter.Utilities;
using dl.wm.view.Controls.Simcards;
using dl.wm.presenter.Base;

namespace dl.wm.presenter.ViewModel.Simcards
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