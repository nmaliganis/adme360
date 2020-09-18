using System;
using System.Collections.Generic;
using System.Linq;
using adme360.cms.model.Categories;
using adme360.cms.model.Stores;
using adme360.cms.repository.ContractRepositories;
using adme360.cms.repository.Repositories.Base;
using adme360.common.infrastructure.Domain.Queries;
using adme360.common.infrastructure.Paging;
using NHibernate;
using NHibernate.Criterion;

namespace adme360.cms.repository.Repositories
{
  public class StoreRepository : RepositoryBase<Store, Guid>, IStoreRepository
  {
    public StoreRepository(ISession session)
      : base(session)
    {
    }

    public QueryResult<Store> FindAllCategoriesPagedOf(int? pageNum = -1, int? pageSize = -1)
    {
      var query = Session.QueryOver<Store>();

      if (pageNum == -1 & pageSize == -1)
      {
        return new QueryResult<Store>(query?
          .Where(e => e.IsActive)
          .List()
          .AsQueryable());
      }

      return new QueryResult<Store>(query
            .Where(e => e.IsActive)
            .Skip(ResultsPagingUtility.CalculateStartIndex((int)pageNum, (int)pageSize))
            .Take((int)pageSize).List().AsQueryable(),
          query.ToRowCountQuery().RowCount(),
          (int)pageSize)
        ;
    }

    public Store FindByFirstName(string name)
    {
      return (Store)
        Session.CreateCriteria(typeof(Store))
          .Add(Expression.Eq("Name", name))
          .UniqueResult()
        ;
    }

    public IList<Store> FindActiveCategories(bool active)
    {
      return
        Session.CreateCriteria(typeof(Store))
          .Add(Expression.Eq("IsActive", active))
          .SetCacheable(true)
          .SetCacheMode(CacheMode.Normal)
          .SetFlushMode(FlushMode.Never)
          .List<Store>()
        ;
    }

    public Store FindStoreByCustomerId(Guid customerId)
    {
      throw new NotImplementedException();
    }
  }
}
