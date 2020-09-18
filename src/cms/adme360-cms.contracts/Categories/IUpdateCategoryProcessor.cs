using System.Threading.Tasks;
using adme360.common.dtos.Vms.Categories;

namespace adme360.cms.contracts.Categories
{
    public interface IUpdateCategoryProcessor
    {
        Task<CategoryUiModel> UpdateCategoryAsync(CategoryForModificationUiModel updatedCategory);
    }
}
