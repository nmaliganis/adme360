using System.Collections.Generic;
using System.Threading.Tasks;
using adme360.cms.contracts.Categories;
using adme360.cms.contracts.Stores;
using adme360.cms.model.Categories;
using adme360.cms.model.Stores;
using adme360.cms.repository.ContractRepositories;
using adme360.common.dtos.Vms.Categories;
using adme360.common.dtos.Vms.Stores;
using adme360.common.infrastructure.Helpers.ResourceParameters;
using adme360.common.infrastructure.Paging;
using adme360.common.infrastructure.PropertyMappings;
using adme360.common.infrastructure.TypeMappings;

namespace adme360.cms.services.Stores
{
  public class InquiryAllStoresProcessor : IInquiryAllStoresProcessor
  {
    private readonly IAutoMapper _autoMapper;
    private readonly IStoreRepository _storeRepository;
    private readonly IPropertyMappingService _propertyMappingService;

    public InquiryAllStoresProcessor(IAutoMapper autoMapper,
      IStoreRepository storeRepository, IPropertyMappingService propertyMappingService)
    {
      _autoMapper = autoMapper;
      _storeRepository = storeRepository;
      _propertyMappingService = propertyMappingService;
    }

    public Task<PagedList<Store>> GetStoresAsync(StoresResourceParameters storesResourceParameters)
    {
      throw new System.NotImplementedException();
    }

    public Task<List<StoreUiModel>> GetStoresForRoutesAsync()
    {
      throw new System.NotImplementedException();
    }
  }
}