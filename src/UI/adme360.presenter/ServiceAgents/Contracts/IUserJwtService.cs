using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using adme360.models.DTOs.Users;
using adme360.presenter.ServiceAgents.Contracts.Base;

namespace adme360.presenter.ServiceAgents.Contracts
{
    public interface IUserJwtService : IEntityService<AuthUiModel>
    {
        Task<AuthUiModel> PostJwtUserAsync(string login, string password);
        Task<bool> PutUserExpireRefreshTokenAsync(string refreshToken);
        Task<AuthUiModel> GetNewTokenByRefreshAsync(string refreshToken);
    }
}