using System.Collections.Generic;
using System.Threading.Tasks;
using dl.wm.models.DTOs.Trackables;
using dl.wm.presenter.ServiceAgents.Contracts.Base;

namespace dl.wm.presenter.ServiceAgents.Contracts
{
    public interface ITrackablesService : IEntityService<TrackableUiModel>
    {
        Task<IList<TrackableUiModel>> GetAllActiveTrackablesAsync(bool active);
        Task<TrackableUiModel> CreateTrackableAsync(TrackableUiModel newTrackable, string authorizationToken = null);
        Task<TrackableUiModel> UpdateTrackableAsync(TrackableUiModel viewChangedTrackable, string authorizationToken = null);
    }
}