using System;
using adme360.cms.model.Users;
using adme360.common.infrastructure.Domain;

namespace adme360.cms.repository.ContractRepositories
{
    public interface IUserRepository : IRepository<User, Guid>
    {
        User FindUserByLogin(string login);
    }
}