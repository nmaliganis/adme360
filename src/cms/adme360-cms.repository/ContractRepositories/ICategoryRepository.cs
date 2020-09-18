using System;
using System.Collections.Generic;
using adme360.cms.model.Categories;
using adme360.common.infrastructure.Domain;
using adme360.common.infrastructure.Domain.Queries;

namespace adme360.cms.repository.ContractRepositories
{
  public interface ICategoryRepository : IRepository<Category, Guid>
  {
    QueryResult<Category> FindAllCategoriesPagedOf(int? pageNum, int? pageSize);
    Category FindByName(string name);
  }
}
