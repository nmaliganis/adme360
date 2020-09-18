using System;
using System.Threading.Tasks;
using adme360.common.dtos.Vms.Stores;

namespace adme360.cms.contracts.Stores
{
    public interface IDeleteStoreProcessor
    {
        Task DeleteStoreAsync(Guid storeToBeDeletedId);
        Task<StoreForDeletionUiModel> SoftDeleteStoreAsync(Guid userAuditId, Guid id);
        Task<StoreForDeletionUiModel> HardDeleteStoreAsync(Guid userAuditId, Guid id);
    }
}