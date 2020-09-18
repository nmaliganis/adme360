using System;
using System.Collections.Generic;
using adme360.cms.model.Customers;
using adme360.common.infrastructure.Domain;
using adme360.common.infrastructure.Domain.Queries;

namespace adme360.cms.repository.ContractRepositories
{
  public interface ICustomerRepository : IRepository<Customer, Guid>
  {
    QueryResult<Customer> FindAllCustomersPagedOf(int? pageNum, int? pageSize);
    Customer FindOneByEmail(string email);
    Customer FindOneByVat(string vat);
    Customer FindByFirstNameAndLastName(string lastName, string firstName);
    IList<Customer> FindCustomersByEmailOrLogin(string login);
  }   
}