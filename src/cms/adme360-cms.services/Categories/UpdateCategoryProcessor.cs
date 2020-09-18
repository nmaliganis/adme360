using System;
using System.Threading.Tasks;
using adme360.cms.contracts.Categories;
using adme360.cms.repository.ContractRepositories;
using adme360.common.dtos.Vms.Categories;
using adme360.common.infrastructure.TypeMappings;
using adme360.common.infrastructure.UnitOfWorks;

namespace adme360.cms.services.Categories
{
    public class UpdateCategoryProcessor : IUpdateCategoryProcessor
    {
        private readonly IUnitOfWork _uOf;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IAutoMapper _autoMapper;
        public UpdateCategoryProcessor(IUnitOfWork uOf, IAutoMapper autoMapper, ICategoryRepository categoryRepository)
        {
            _uOf = uOf;
            _categoryRepository = categoryRepository;
            _autoMapper = autoMapper;
        }

        public Task<CategoryUiModel> UpdateCategoryAsync(CategoryForModificationUiModel updatedCategory)
        {
            throw new NotImplementedException();
        }
    }
}