using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using adme360.cms.contracts.Categories;
using adme360.cms.model.Categories;
using adme360.cms.repository.ContractRepositories;
using adme360.common.dtos.Vms.Categories;
using adme360.common.infrastructure.Extensions;
using adme360.common.infrastructure.Helpers.ResourceParameters;
using adme360.common.infrastructure.Paging;
using adme360.common.infrastructure.PropertyMappings;
using adme360.common.infrastructure.TypeMappings;

namespace adme360.cms.services.Categories
{
  public class InquiryAllCategoriesProcessor : IInquiryAllCategoriesProcessor
  {
    private readonly IAutoMapper _autoMapper;
    private readonly ICategoryRepository _categoryRepository;
    private readonly IPropertyMappingService _propertyMappingService;

    public InquiryAllCategoriesProcessor(IAutoMapper autoMapper,
      ICategoryRepository categoryRepository, IPropertyMappingService propertyMappingService)
    {
      _autoMapper = autoMapper;
      _categoryRepository = categoryRepository;
      _propertyMappingService = propertyMappingService;
    }

    public Task<PagedList<Category>> GetCategoriesAsync(CategoriesResourceParameters categoriesResourceParameters)
    {
      var collectionBeforePaging =
        QueryableExtensions.ApplySort(_categoryRepository
            .FindAllCategoriesPagedOf(categoriesResourceParameters.PageIndex,
              categoriesResourceParameters.PageSize), 
          categoriesResourceParameters.OrderBy, 
          _propertyMappingService.GetPropertyMapping<CategoryUiModel, Category>());


      if (!string.IsNullOrEmpty(categoriesResourceParameters.SearchQuery))
      {
        // trim & ignore casing
        var searchQueryForWhereClause = categoriesResourceParameters.SearchQuery
          .Trim().ToLowerInvariant();

        collectionBeforePaging.QueriedItems = collectionBeforePaging.QueriedItems
          .Where(a => a.Name.ToLowerInvariant().Contains(searchQueryForWhereClause));
      }

      return Task.Run(() => PagedList<Category>.Create(collectionBeforePaging,
        categoriesResourceParameters.PageIndex,
        categoriesResourceParameters.PageSize));
    }
  }
}