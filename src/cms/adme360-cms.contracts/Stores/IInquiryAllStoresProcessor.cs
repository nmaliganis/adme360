using System.Collections.Generic;
using System.Threading.Tasks;
using adme360.cms.model.Stores;
using adme360.common.dtos.Vms.Stores;
using adme360.common.infrastructure.Helpers.ResourceParameters;
using adme360.common.infrastructure.Paging;

namespace adme360.cms.contracts.Stores
{
  public interface IInquiryAllStoresProcessor
  {
    Task<PagedList<Store>> GetStoresAsync(StoresResourceParameters storesResourceParameters);
    Task<List<StoreUiModel>> GetStoresForRoutesAsync();
  }
}