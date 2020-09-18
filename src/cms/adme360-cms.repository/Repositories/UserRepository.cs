using System;
using adme360.cms.model.Users;
using adme360.cms.repository.ContractRepositories;
using adme360.cms.repository.Repositories.Base;
using NHibernate;
using NHibernate.Criterion;

namespace adme360.cms.repository.Repositories
{
    public class UserRepository : RepositoryBase<User, Guid>, IUserRepository
    {
        public UserRepository(ISession session)
            : base(session)
        {
        }

        public User FindUserByLogin(string login)
        {
            return (User)
                Session.CreateCriteria(typeof(User))
                    .Add(Expression.Eq("IsActive", true))
                    .Add(Expression.Eq("Login", login))
                    .SetCacheable(true)
                    .SetCacheMode(CacheMode.Normal)
                    .SetFlushMode(FlushMode.Never)
                    .UniqueResult()
                ;
        }
    }
}
