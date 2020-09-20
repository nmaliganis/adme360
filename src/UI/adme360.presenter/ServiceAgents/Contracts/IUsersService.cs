using System.Collections.Generic;
using System.Threading.Tasks;
using adme360.models.DTOs.Users;
using adme360.presenter.ServiceAgents.Contracts.Base;

namespace adme360.presenter.ServiceAgents.Contracts
{
    public interface IUsersService : IEntityService<UserUiModel>
    {
        Task<IList<UserUiModel>> GetAllActiveUsersAsync(bool active);
        Task<IList<UserForAllRetrievalUiModel>> GetUserEntitiesAsync(string authorizationToken = null);
        Task<UserUiModel> CreateRegisterNewUserAccountAsync(UserUiModel registerUser, string password, string authorizationToken = null);
    }
}