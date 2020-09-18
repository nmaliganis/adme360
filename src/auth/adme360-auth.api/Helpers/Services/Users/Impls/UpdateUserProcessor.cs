using System;
using System.Linq;
using System.Threading.Tasks;
using adme360.auth.api.Helpers.Models;
using adme360.auth.api.Helpers.Repositories.Users;
using adme360.auth.api.Helpers.Services.Users.Contracts;
using adme360.common.dtos.Vms.Users;
using adme360.common.infrastructure.Exceptions.Domain.Users;
using adme360.common.infrastructure.TypeMappings;
using adme360.common.infrastructure.UnitOfWorks;
using Serilog;

namespace adme360.auth.api.Helpers.Services.Users.Impls
{
    public class UpdateUserProcessor : IUpdateUserProcessor
    {
        private readonly IUnitOfWork _uOf;
        private readonly IUserRepository _userRepository;
        private readonly IAutoMapper _autoMapper;

        public UpdateUserProcessor(IUnitOfWork uOf, IAutoMapper autoMapper, IUserRepository userRepository)
        {
            _uOf = uOf;
            _userRepository = userRepository;
            _autoMapper = autoMapper;
        }

        public Task<bool> UpdateUserRefreshTokenExpiredAsync(Guid refreshToken)
        {
            var response = false;

            if (refreshToken == Guid.Empty)
            {
                return Task.Run(() => response);
            }

            try
            {
                var userToBeModified = _userRepository.FindUserByRefreshTokenAsync(refreshToken);

                if (userToBeModified == null)
                    throw new UserDoesNotExistException(refreshToken);

                userToBeModified.UserTokens.FirstOrDefault(r => r.RefreshToken == refreshToken)?.ModifyWithExpired();

                Log.Debug(
                    $"Update User with Expired RefreshToken: {refreshToken}" +
                    "--UpdateUserRefreshTokenExpiredAsync--  @NotComplete@ [UpdateUserProcessor]. " +
                    "Message: Just Before MakeItPersistence");

                MakePatientPersistent(userToBeModified);

                Log.Debug(
                    $"Update User with Expired RefreshToken: {refreshToken}" +
                    "--UpdateUserRefreshTokenExpiredAsync--  @NotComplete@ [UpdateUserProcessor]. " +
                    "Message: Just After MakeItPersistence");
                response = true;
            }
            catch (UserDoesNotExistException ex)
            {
                Log.Error(
                    $"Update User with Expired RefreshToken: {refreshToken}" +
                    $"--UpdateUserRefreshTokenExpiredAsync--  @fail@ [UpdateUserProcessor]. " +
                    $"@innerfault:{ex.Message} and {ex.InnerException}");
            }
            catch (Exception ex)
            {
                Log.Error(
                    $"Update User with Expired RefreshToken: {refreshToken}" +
                    $"--UpdateUserRefreshTokenExpiredAsync--  @fail@ [UpdateUserProcessor]. " +
                    $"@innerfault:{ex.Message} and {ex.InnerException}");
            }

            return Task.Run(() => response);
        }

        public Task<UserForRetrievalUiModel> UpdateUserRefreshTokenAsync(Guid refreshToken)
        {
            var response =
                new UserForRetrievalUiModel()
                {
                    Message = "START_MODIFICATION"
                };

            if (refreshToken == Guid.Empty)
            {
                response.Message = "ERROR_INVALID_USER_REFRESH_TOKEN";
                return Task.Run(() => response);
            }

            try
            {
                var userToBeModified = _userRepository.FindUserByRefreshTokenAsync(refreshToken);

                if (userToBeModified == null)
                    throw new UserDoesNotExistException(refreshToken);

                userToBeModified.ModifyWithRefreshToken(refreshToken);

                userToBeModified.InjectWithUserToken(new UserToken());

                Log.Debug(
                    $"Update User with RefreshToken: {refreshToken}" +
                    "--UpdateUserRefreshTokenAsync--  @NotComplete@ [UpdateUserProcessor]. " +
                    "Message: Just Before MakeItPersistence");

                MakePatientPersistent(userToBeModified);

                Log.Debug(
                    $"Update User with RefreshToken: {refreshToken}" +
                    "--UpdateUserRefreshTokenAsync--  @NotComplete@ [UpdateUserProcessor]. " +
                    "Message: Just After MakeItPersistence");

                response.Message = "SUCCESS_CREATION";

                return Task.Run(() => _autoMapper.Map<UserForRetrievalUiModel>(userToBeModified));
            }
            catch (UserDoesNotExistException ex)
            {
                response.Message = "ERROR_USER_DOES_NOT_EXISTS";
                Log.Error(
                    $"Update User with RefreshToken: {refreshToken}" +
                    $"Error Message:{response.Message}" +
                    $"--UpdateUserRefreshTokenAsync--  @fail@ [UpdateUserProcessor]. " +
                    $"@innerfault:{ex.Message} and {ex.InnerException}");
            }
            catch (Exception ex)
            {
                response.Message = "UNKNOWN_ERROR";
                Log.Error(
                    $"Update User with RefreshToken: {refreshToken}" +
                    $"Error Message:{response.Message}" +
                    $"--UpdateUserRefreshTokenAsync--  @fail@ [UpdateUserProcessor]. " +
                    $"@innerfault:{ex.Message} and {ex.InnerException}");
            }

            return Task.Run(() => response);
        }

        public Task<UserForRetrievalUiModel> UpdateUserWithNewRefreshTokenAsync(UserForRetrievalUiModel registeredUser, Guid refreshToken)
        {
            var response =
                new UserForRetrievalUiModel()
                {
                    Message = "START_MODIFICATION"
                };

            if (refreshToken == Guid.Empty || string.IsNullOrEmpty(registeredUser.Login))
            {
                response.Message = "ERROR_INVALID_USER_REFRESH_TOKEN_OR_LOGIN";
                return Task.Run(() => response);
            }

            try
            {
                var userToBeModified = _userRepository.FindUserByLoginForRefreshToken(registeredUser.Login);

                if (userToBeModified == null)
                    throw new UserDoesNotExistException(refreshToken);

                userToBeModified.InjectWithUserToken(new UserToken()
                {
                    RefreshToken = refreshToken
                });

                Log.Debug(
                    $"Update User with RefreshToken: {refreshToken}" +
                    "--UpdateUserRefreshTokenAsync--  @NotComplete@ [UpdateUserProcessor]. " +
                    "Message: Just Before MakeItPersistence");

                MakePatientPersistent(userToBeModified);

                Log.Debug(
                    $"Update User with RefreshToken: {refreshToken}" +
                    "--UpdateUserRefreshTokenAsync--  @NotComplete@ [UpdateUserProcessor]. " +
                    "Message: Just After MakeItPersistence");

                response.Message = "SUCCESS_CREATION";

                return Task.Run(() => _autoMapper.Map<UserForRetrievalUiModel>(userToBeModified));
            }
            catch (UserDoesNotExistException ex)
            {
                response.Message = "ERROR_USER_DOES_NOT_EXISTS";
                Log.Error(
                    $"Update User with RefreshToken: {refreshToken}" +
                    $"Error Message:{response.Message}" +
                    $"--UpdateUserRefreshTokenAsync--  @fail@ [UpdateUserProcessor]. " +
                    $"@innerfault:{ex.Message} and {ex.InnerException}");
            }
            catch (Exception ex)
            {
                response.Message = "UNKNOWN_ERROR";
                Log.Error(
                    $"Update User with RefreshToken: {refreshToken}" +
                    $"Error Message:{response.Message}" +
                    $"--UpdateUserRefreshTokenAsync--  @fail@ [UpdateUserProcessor]. " +
                    $"@innerfault:{ex.Message} and {ex.InnerException}");
            }

            return Task.Run(() => response);
        }

        private void MakePatientPersistent(User userToBeMadePersistence)
        {
            _userRepository.Save(userToBeMadePersistence);
            _uOf.Commit();
        }
    }
}