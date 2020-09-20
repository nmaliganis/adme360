using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using dl.wm.models.DTOs.Users;
using dl.wm.presenter.ServiceAgents.Contracts.Base;

namespace dl.wm.presenter.ServiceAgents.Contracts
{
    public interface IUserJwtService : IEntityService<AuthUiModel>
    {
        Task<AuthUiModel> PostJwtUserAsync(string login, string password);
        Task<bool> PutUserExpireRefreshTokenAsync(string refreshToken);
        Task<AuthUiModel> GetNewTokenByRefreshAsync(string refreshToken);
    }
}