using System;
using System.Threading.Tasks;
using adme360.common.dtos.Vms.Categories;

namespace adme360.cms.contracts.Categories
{
    public interface IDeleteCategoryProcessor
    {
        Task DeleteCategoryAsync(Guid categoryToBeDeletedId);
        Task<CategoryForDeletionUiModel> SoftDeleteCategoryAsync(Guid userAuditId, Guid id);
        Task<CategoryForDeletionUiModel> HardDeleteCategoryAsync(Guid userAuditId, Guid id);
    }
}