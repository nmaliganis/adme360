using System;
using System.Threading.Tasks;
using adme360.common.dtos.Vms.Categories;

namespace adme360.cms.contracts.Categories
{
  public interface ICreateCategoryProcessor
  {
    Task<CategoryUiModel> CreateCategoryAsync(Guid accountIdToCreateThisCategory, CategoryForCreationUiModel newCategoryUiModel);
  }
}