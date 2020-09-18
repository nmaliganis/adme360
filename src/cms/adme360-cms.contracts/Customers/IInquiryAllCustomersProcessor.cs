using System.Collections.Generic;
using System.Threading.Tasks;
using adme360.cms.model.Customers;
using adme360.common.infrastructure.Helpers.ResourceParameters;
using adme360.common.infrastructure.Paging;

namespace adme360.cms.contracts.Customers
{
    public interface IInquiryAllCustomersProcessor
    {
      Task<PagedList<Customer>> GetCustomersAsync(CustomersResourceParameters customersResourceParameters);
      //Task<List<CustomerUiModel>> GetCustomersForRoutesAsync();
    }
}