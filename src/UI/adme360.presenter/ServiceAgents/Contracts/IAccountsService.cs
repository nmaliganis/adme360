using System.Threading.Tasks;
using dl.wm.models.DTOs.Users;
using dl.wm.presenter.ServiceAgents.Contracts.Base;

namespace dl.wm.presenter.ServiceAgents.Contracts
{
    public interface IAccountsService : IEntityService<UserUiModel>
    {
        Task<UserUiModel> CreateRegisterNewUserAccountAsync(AccountUiModel registerUser, string authorizationToken = null);
        Task<UserUiModel> UpdateRegisterExistingUserAccountAsync(AccountUiModel changedUser, string authorizationToken = null);
    }
}