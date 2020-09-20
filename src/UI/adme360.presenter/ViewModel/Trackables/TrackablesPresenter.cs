using adme360.presenter.Base;
using adme360.presenter.ServiceAgents.Contracts;
using adme360.presenter.ServiceAgents.Impls;
using adme360.presenter.Utilities;
using adme360.view.Controls.Trackables;

namespace adme360.presenter.ViewModel.Trackables
{
    public class TrackablesPresenter : BasePresenter<ITrackablesView, ITrackablesService>
    {
        public TrackablesPresenter(ITrackablesView view)
            : this(view, new TrackablesService())
        {
        }

        public TrackablesPresenter(ITrackablesView view, ITrackablesService service)
            : base(view, service)
        {
        }

        public async void LoadAllTrackables()
        {
            var trackables = await Service.GetEntitiesAsync(ClientSettingsSingleton.InstanceSettings().TokenConfigValue);

            if (trackables?.Count == 0)
                View.NoneTrackableWasRetrieved = true;
            else
            {
                View.Trackables = trackables;
            }
        }
    }
}