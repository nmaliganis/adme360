using System.Collections.Generic;
using System.Threading.Tasks;
using adme360.models.DTOs.Tours;
using adme360.presenter.ServiceAgents.Contracts.Base;

namespace adme360.presenter.ServiceAgents.Contracts
{
    public interface IToursService : IEntityService<TourUiModel>
    {
        Task<IList<TourUiModel>> GetAllActiveToursAsync(bool active);
        Task<TourUiModel> CreateTourAsync(TourUiModel newTour, string authorizationToken = null);
        Task<TourUiModel> UpdateTourAsync(TourUiModel viewChangedTour, string authorizationToken = null);
    }
}