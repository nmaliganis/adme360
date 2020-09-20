using System.Threading.Tasks;
using adme360.models.DTOs.Users;
using adme360.presenter.ServiceAgents.Contracts.Base;

namespace adme360.presenter.ServiceAgents.Contracts
{
    public interface IAccountsService : IEntityService<UserUiModel>
    {
        Task<UserUiModel> CreateRegisterNewUserAccountAsync(AccountUiModel registerUser, string authorizationToken = null);
        Task<UserUiModel> UpdateRegisterExistingUserAccountAsync(AccountUiModel changedUser, string authorizationToken = null);
    }
}