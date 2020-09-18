using System;
using System.Threading.Tasks;
using adme360.auth.api.Helpers.Repositories.Users;
using adme360.auth.api.Helpers.Services.Users.Contracts;
using adme360.common.dtos.Vms.Users;
using adme360.common.infrastructure.TypeMappings;

namespace adme360.auth.api.Helpers.Services.Users.Impls
{
  public class InquiryUserProcessor : IInquiryUserProcessor
  {
    private readonly IAutoMapper _autoMapper;
    private readonly IUserRepository _userRepository;
    public InquiryUserProcessor(IUserRepository userRepository, IAutoMapper autoMapper)
    {
      _userRepository = userRepository;
      _autoMapper = autoMapper;
    }

    public Task<UserForRetrievalUiModel> GetUserAuthJwtTokenByRefreshTokenAsync(Guid refreshToken)
    {
      return Task.Run(() => _autoMapper.Map<UserForRetrievalUiModel>(_userRepository.FindUserByRefreshTokenAsync(refreshToken)));
    }

    public Task<UserForRetrievalUiModel> GetUserAuthJwtTokenByLoginAndPasswordAsync(string login, string password)
    {
      return Task.Run(() => _autoMapper.Map<UserForRetrievalUiModel>(_userRepository.FindUserByLoginAndPasswordAsync(login, password)));
    }

      public Task<UserUiModel> GetUserByLoginAsync(string login)
      {
          return Task.Run(() => _autoMapper.Map<UserUiModel>(_userRepository.FindUserByLoginForRefreshToken(login)));
      }

      public Task<UserForRetrievalUiModel> GetAuthUserByLoginAsync(string login)
      {
        return Task.Run(() => _autoMapper.Map<UserForRetrievalUiModel>(_userRepository.FindUserByLogin(login)));
    }

    public Task<UserActivationUiModel> GetUserByIdAsync(Guid userId)
      {
          return Task.Run(() => _autoMapper.Map<UserActivationUiModel>(_userRepository.FindBy(userId)));
      }
  }
}