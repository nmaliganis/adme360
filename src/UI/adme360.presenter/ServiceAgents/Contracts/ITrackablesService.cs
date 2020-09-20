using System.Collections.Generic;
using System.Threading.Tasks;
using adme360.models.DTOs.Trackables;
using adme360.presenter.ServiceAgents.Contracts.Base;

namespace adme360.presenter.ServiceAgents.Contracts
{
    public interface ITrackablesService : IEntityService<TrackableUiModel>
    {
        Task<IList<TrackableUiModel>> GetAllActiveTrackablesAsync(bool active);
        Task<TrackableUiModel> CreateTrackableAsync(TrackableUiModel newTrackable, string authorizationToken = null);
        Task<TrackableUiModel> UpdateTrackableAsync(TrackableUiModel viewChangedTrackable, string authorizationToken = null);
    }
}