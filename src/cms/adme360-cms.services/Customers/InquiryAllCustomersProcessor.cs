using System.Linq;
using System.Threading.Tasks;
using adme360.cms.contracts.Customers;
using adme360.cms.model.Customers;
using adme360.cms.repository.ContractRepositories;
using adme360.common.dtos.Vms.Customers;
using adme360.common.infrastructure.Extensions;
using adme360.common.infrastructure.Helpers.ResourceParameters;
using adme360.common.infrastructure.Paging;
using adme360.common.infrastructure.PropertyMappings;
using adme360.common.infrastructure.TypeMappings;

namespace adme360.cms.services.Customers
{
  public class InquiryAllCustomersProcessor : IInquiryAllCustomersProcessor
  {
    private readonly IAutoMapper _autoMapper;
    private readonly ICustomerRepository _customerRepository;
    private readonly IPropertyMappingService _propertyMappingService;

    public InquiryAllCustomersProcessor(IAutoMapper autoMapper,
      ICustomerRepository customerRepository, IPropertyMappingService propertyMappingService)
    {
      _autoMapper = autoMapper;
      _customerRepository = customerRepository;
      _propertyMappingService = propertyMappingService;
    }

    public Task<PagedList<Customer>> GetCustomersAsync(CustomersResourceParameters customersResourceParameters)
    {
      var collectionBeforePaging =
        QueryableExtensions.ApplySort(_customerRepository
            .FindAllCustomersPagedOf(customersResourceParameters.PageIndex,
              customersResourceParameters.PageSize),
          customersResourceParameters.OrderBy,
          _propertyMappingService.GetPropertyMapping<CustomerUiModel, Customer>());

      if (!string.IsNullOrEmpty(customersResourceParameters.Filter) &&
          !string.IsNullOrEmpty(customersResourceParameters.SearchQuery))
      {
        var searchQueryForWhereClauseFilterFields = customersResourceParameters.Filter
          .Trim().ToLowerInvariant();

        var searchQueryForWhereClauseFilterSearchQuery = customersResourceParameters.SearchQuery
          .Trim().ToLowerInvariant();

        collectionBeforePaging.QueriedItems = collectionBeforePaging.QueriedItems
          .AsEnumerable()
          .FilterData(searchQueryForWhereClauseFilterFields, searchQueryForWhereClauseFilterSearchQuery)
          .AsQueryable();
      }

      return Task.Run(() => PagedList<Customer>.Create(collectionBeforePaging,
        customersResourceParameters.PageIndex,
        customersResourceParameters.PageSize));
    }
  }
}