using System;
using System.Threading.Tasks;
using adme360.cms.contracts.Categories;
using adme360.cms.repository.ContractRepositories;
using adme360.common.dtos.Vms.Categories;
using adme360.common.infrastructure.UnitOfWorks;

namespace adme360.cms.services.Categories
{
    public class DeleteCategoryProcessor : IDeleteCategoryProcessor
    {
        private readonly IUnitOfWork _uOf;
        private readonly ICategoryRepository _categoryRepository;

        public DeleteCategoryProcessor(IUnitOfWork uOf,
            ICategoryRepository categoryRepository)
        {
            _uOf = uOf;
            _categoryRepository = categoryRepository;
        }

        public Task DeleteCategoryAsync(Guid categoryToBeDeletedId)
        {
            throw new NotImplementedException();
        }

        public Task<CategoryForDeletionUiModel> SoftDeleteCategoryAsync(Guid userAuditId, Guid id)
        {
          throw new NotImplementedException();
        }

        public Task<CategoryForDeletionUiModel> HardDeleteCategoryAsync(Guid userAuditId, Guid id)
        {
          throw new NotImplementedException();
        }
    }
}