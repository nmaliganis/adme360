using dl.wm.presenter.Base;
using dl.wm.presenter.ServiceAgents.Contracts;
using dl.wm.presenter.ServiceAgents.Impls;
using dl.wm.presenter.Utilities;
using dl.wm.view.Controls.Trackables;

namespace dl.wm.presenter.ViewModel.Trackables
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