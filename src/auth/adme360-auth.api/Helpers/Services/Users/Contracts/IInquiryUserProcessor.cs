using System;
using System.Threading.Tasks;
using adme360.common.dtos.Vms.Users;

namespace adme360.auth.api.Helpers.Services.Users.Contracts
{
  public interface IInquiryUserProcessor
  {
    Task<UserForRetrievalUiModel> GetUserAuthJwtTokenByRefreshTokenAsync(Guid refreshToken);
    Task<UserForRetrievalUiModel> GetUserAuthJwtTokenByLoginAndPasswordAsync(string login, string password);
    Task<UserUiModel> GetUserByLoginAsync(string login);
    Task<UserForRetrievalUiModel> GetAuthUserByLoginAsync(string login);
    Task<UserActivationUiModel> GetUserByIdAsync(Guid userId);
  }
}