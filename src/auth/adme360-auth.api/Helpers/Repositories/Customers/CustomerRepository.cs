using System;
using System.Collections.Generic;
using adme360.auth.api.Helpers.Models;
using adme360.auth.api.Helpers.Repositories.Base;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.SqlCommand;

namespace adme360.auth.api.Helpers.Repositories.Customers
{
    public class CustomerRepository : RepositoryBase<Customer, Guid>, ICustomerRepository
    {
        public CustomerRepository(ISession session)
            : base(session)
        {
        }

        public Customer FindCustomerByEmail(string email)
        {
            return
                (Customer)
                Session.CreateCriteria(typeof(Customer))
                    .Add(Expression.Eq("Email", email))
                    .SetCacheable(true)
                    .SetCacheMode(CacheMode.Normal)
                    .SetFlushMode(FlushMode.Never)
                    .UniqueResult()
                ;
        }

        public IList<Customer> FindCustomersByEmailOrLogin(string login)
        {
            return
                Session.CreateCriteria(typeof(Customer))
                    .CreateAlias("User", "u", JoinType.InnerJoin)
                    .Add(Restrictions.Or(
                        Restrictions.Eq("Email", login), 
                        Restrictions.Eq("u.Login", login)))
                    .SetCacheable(true)
                    .SetCacheMode(CacheMode.Normal)
                    .SetFlushMode(FlushMode.Never)
                    .List<Customer>()
                ;
        }
    }
}
