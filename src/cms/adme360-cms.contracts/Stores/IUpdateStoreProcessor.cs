using System.Threading.Tasks;
using adme360.common.dtos.Vms.Categories;
using adme360.common.dtos.Vms.Stores;

namespace adme360.cms.contracts.Stores
{
    public interface IUpdateStoreProcessor
    {
        Task<StoreUiModel> UpdateStoreAsync(StoreForModificationUiModel updatedStore);
    }
}
