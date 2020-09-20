using System.Collections.Generic;
using System.Threading.Tasks;
using adme360.models.DTOs.Simcards;
using adme360.presenter.ServiceAgents.Contracts.Base;

namespace adme360.presenter.ServiceAgents.Contracts
{
    public interface ISimcardsService : IEntityService<SimcardUiModel>
    {
        Task<IList<SimcardUiModel>> GetAllActiveSimcardsAsync(bool active);
        Task<SimcardUiModel> CreateSimcardAsync(SimcardUiModel viewChangedSimcard, string authorizationToken = null);
    }
}