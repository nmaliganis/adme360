using System.Collections.Generic;
using System.Threading.Tasks;
using adme360.cms.model.Categories;
using adme360.common.dtos.Vms.Categories;
using adme360.common.infrastructure.Helpers.ResourceParameters;
using adme360.common.infrastructure.Paging;

namespace adme360.cms.contracts.Categories
{
  public interface IInquiryAllCategoriesProcessor
  {
    Task<PagedList<Category>> GetCategoriesAsync(CategoriesResourceParameters categoriesResourceParameters);
  }
}