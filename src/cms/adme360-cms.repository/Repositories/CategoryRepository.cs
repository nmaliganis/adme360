using System;
using System.Collections.Generic;
using System.Linq;
using adme360.cms.model.Categories;
using adme360.cms.repository.ContractRepositories;
using adme360.cms.repository.Repositories.Base;
using adme360.common.infrastructure.Domain.Queries;
using adme360.common.infrastructure.Paging;
using NHibernate;
using NHibernate.Criterion;

namespace adme360.cms.repository.Repositories
{
  public class CategoryRepository : RepositoryBase<Category, Guid>, ICategoryRepository
  {
    public CategoryRepository(ISession session)
      : base(session)
    {
    }

    public QueryResult<Category> FindAllCategoriesPagedOf(int? pageNum = -1, int? pageSize = -1)
    {
      var query = Session.QueryOver<Category>();

      if (pageNum == -1 & pageSize == -1)
      {
        return new QueryResult<Category>(query?
          .Where(e => e.IsActive)
          .List()
          .AsQueryable());
      }

      return new QueryResult<Category>(query
            .Where(e => e.IsActive)
            .Skip(ResultsPagingUtility.CalculateStartIndex((int)pageNum, (int)pageSize))
            .Take((int)pageSize).List().AsQueryable(),
          query.ToRowCountQuery().RowCount(),
          (int)pageSize)
        ;
    }

    public Category FindByName(string name)
    {
      return (Category)
        Session.CreateCriteria(typeof(Category))
          .Add(Expression.Eq("Name", name))
          .UniqueResult()
        ;
    }
  }
}
