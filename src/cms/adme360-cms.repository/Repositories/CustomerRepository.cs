using System;
using System.Collections.Generic;
using System.Linq;
using adme360.cms.model.Customers;
using adme360.cms.repository.ContractRepositories;
using adme360.cms.repository.Repositories.Base;
using adme360.common.infrastructure.Domain.Queries;
using adme360.common.infrastructure.Paging;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.SqlCommand;
using Serilog;

namespace adme360.cms.repository.Repositories
{
  public class CustomerRepository : RepositoryBase<Customer, Guid>, ICustomerRepository
  {
    public CustomerRepository(ISession session)
      : base(session)
    {
    }

    public QueryResult<Customer> FindAllCustomersPagedOf(int? pageNum = -1, int? pageSize = -1)
    {
      var query = Session.QueryOver<Customer>();

      if (pageNum == -1 & pageSize == -1)
      {
        return new QueryResult<Customer>(query?
          .List()
          .AsQueryable());
      }

      return new QueryResult<Customer>(query
            .Skip(ResultsPagingUtility.CalculateStartIndex((int) pageNum, (int) pageSize))
            .Take((int) pageSize).List().AsQueryable(),
          query.ToRowCountQuery().RowCount(),
          (int) pageSize)
        ;
    }

    public Customer FindOneByEmail(string email)
    {
      return (Customer)
        Session.CreateCriteria(typeof(Customer))
          .Add(Expression.Eq("Email", email))
          .UniqueResult()
        ;
    }

    public Customer FindOneByVat(string vat)
    {
      throw new NotImplementedException();
    }

    public Customer FindByFirstNameAndLastName(string lastName, string firstName)
    {
      return (Customer)
        Session.CreateCriteria(typeof(Customer))
          .Add(Expression.Eq("FirstName", firstName))
          .Add(Expression.Eq("LastName", lastName))
          .UniqueResult()
        ;
    }

    public IList<Customer> FindActiveCustomers(bool active)
    {
      return
        Session.CreateCriteria(typeof(Customer))
          .Add(Expression.Eq("Active", active))
          .SetCacheable(true)
          .SetCacheMode(CacheMode.Normal)
          .SetFlushMode(FlushMode.Never)
          .List<Customer>()
        ;
    }

    public Customer FindOneBy(Guid CustomerId)
    {
      return
        (Customer)
        Session.CreateCriteria(typeof(Customer))
          .Add(Expression.Eq("Id", CustomerId))
          .Add(Expression.Eq("IsActive", true))
          .SetCacheable(true)
          .SetCacheMode(CacheMode.Normal)
          .SetFlushMode(FlushMode.Never)
          .UniqueResult()
        ;
    }

    public int FindCountTotals()
    {
      int count = 0;
      try
      {
        count = Session
          .CreateCriteria<Customer>()
          .Add(Expression.Eq("IsActive", true))
          .SetProjection(
            Projections.Count(Projections.Id())
          )
          .UniqueResult<int>();
      }
      catch (Exception e)
      {
        Log.Error(
          $"FindCountTotals" + $"Error Message:{e.Message}" +
          "--CustomerRepository--  @fail@ [CustomerRepository]." +
          $" @inner-fault:{e?.Message} and {e?.InnerException}");
      }

      return count;
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
