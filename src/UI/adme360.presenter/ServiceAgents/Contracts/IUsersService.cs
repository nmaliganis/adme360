using System.Collections.Generic;
using System.Threading.Tasks;
using dl.wm.models.DTOs.Users;
using dl.wm.presenter.ServiceAgents.Contracts.Base;

namespace dl.wm.presenter.ServiceAgents.Contracts
{
    public interface IUsersService : IEntityService<UserUiModel>
    {
        Task<IList<UserUiModel>> GetAllActiveUsersAsync(bool active);
        Task<IList<UserForAllRetrievalUiModel>> GetUserEntitiesAsync(string authorizationToken = null);
        Task<UserUiModel> CreateRegisterNewUserAccountAsync(UserUiModel registerUser, string password, string authorizationToken = null);
    }
}