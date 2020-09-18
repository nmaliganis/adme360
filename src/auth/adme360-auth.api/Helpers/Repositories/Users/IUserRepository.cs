using System;
using adme360.auth.api.Helpers.Models;
using adme360.common.infrastructure.Domain;
using adme360.common.infrastructure.Domain.Queries;

namespace adme360.auth.api.Helpers.Repositories.Users
{
    public interface IUserRepository : IRepository<User, Guid>
    {
        QueryResult<User> GetUsersPagedAsync(int? pageNum, int? pageSize);

        User FindUserByLoginAndEmail(string login, string email);
        User FindUserByLogin(string login);
        User FindUserByLoginForRefreshToken(string login);

        User FindUserByLoginAndPasswordAsync(string login, string password);

        User FindByUserIdAndActivationKey(Guid userIdToBeActivated, Guid activationKey);
        User FindUserByRefreshTokenAsync(Guid refreshToken);
    }
}