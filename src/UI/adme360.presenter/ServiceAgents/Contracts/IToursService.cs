using System.Collections.Generic;
using System.Threading.Tasks;
using dl.wm.models.DTOs.Tours;
using dl.wm.presenter.ServiceAgents.Contracts.Base;

namespace dl.wm.presenter.ServiceAgents.Contracts
{
    public interface IToursService : IEntityService<TourUiModel>
    {
        Task<IList<TourUiModel>> GetAllActiveToursAsync(bool active);
        Task<TourUiModel> CreateTourAsync(TourUiModel newTour, string authorizationToken = null);
        Task<TourUiModel> UpdateTourAsync(TourUiModel viewChangedTour, string authorizationToken = null);
    }
}