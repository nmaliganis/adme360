using System.Collections.Generic;
using System.Threading.Tasks;
using dl.wm.models.DTOs.Simcards;
using dl.wm.presenter.ServiceAgents.Contracts.Base;

namespace dl.wm.presenter.ServiceAgents.Contracts
{
    public interface ISimcardsService : IEntityService<SimcardUiModel>
    {
        Task<IList<SimcardUiModel>> GetAllActiveSimcardsAsync(bool active);
        Task<SimcardUiModel> CreateSimcardAsync(SimcardUiModel viewChangedSimcard, string authorizationToken = null);
    }
}