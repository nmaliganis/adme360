using System;
using System.Threading.Tasks;
using adme360.common.dtos.Vms.Stores;

namespace adme360.cms.contracts.Stores
{
  public interface ICreateStoreProcessor
  {
    Task<StoreUiModel> CreateStoreAsync(Guid accountIdToCreateThisStore, StoreForCreationUiModel newStoreUiModel);
  }
}