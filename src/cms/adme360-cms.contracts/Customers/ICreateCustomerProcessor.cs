using System;
using System.Threading.Tasks;
using adme360.common.dtos.Vms.Customers;

namespace adme360.cms.contracts.Customers
{
  public interface ICreateCustomerProcessor
  {
    Task<CustomerUiModel> CreateCustomerAsync(Guid accountIdToCreateThisCustomer, CustomerForCreationUiModel newCustomerUiModel, bool isAdvertiser);
  }
}