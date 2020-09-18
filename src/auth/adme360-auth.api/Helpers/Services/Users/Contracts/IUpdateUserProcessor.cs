using System;
using System.Threading.Tasks;
using adme360.common.dtos.Vms.Users;

namespace adme360.auth.api.Helpers.Services.Users.Contracts
{
    public interface IUpdateUserProcessor
    {
        Task<bool> UpdateUserRefreshTokenExpiredAsync(Guid refreshToken);
        Task<UserForRetrievalUiModel> UpdateUserRefreshTokenAsync(Guid refreshToken);
        Task<UserForRetrievalUiModel> UpdateUserWithNewRefreshTokenAsync(UserForRetrievalUiModel registeredUser, Guid refreshToken);
    }
}
