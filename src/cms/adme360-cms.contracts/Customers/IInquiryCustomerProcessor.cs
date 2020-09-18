using System;
using System.Threading.Tasks;
using adme360.common.dtos.Vms.Customers;

namespace adme360.cms.contracts.Customers
{
    public interface IInquiryCustomerProcessor
    {
    Task<CustomerUiModel> GetCustomerByIdAsync(Guid id);
    Task<CustomerUiModel> GetCustomerByEmailAsync(string email);
    Task<bool> SearchIfAnyPersonByEmailOrLoginExistsAsync(string login);
  }
}