using System;
using System.Collections.Generic;
using adme360.cms.model.Categories;
using adme360.cms.model.Stores;
using adme360.common.infrastructure.Domain;
using adme360.common.infrastructure.Domain.Queries;

namespace adme360.cms.repository.ContractRepositories
{
  public interface IStoreRepository : IRepository<Store, Guid>
  {
    QueryResult<Store> FindAllCategoriesPagedOf(int? pageNum, int? pageSize);
    Store FindByFirstName(string name);
    IList<Store> FindActiveCategories(bool active);
    Store FindStoreByCustomerId(Guid customerId);
  }
}
