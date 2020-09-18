using System;
using System.Threading.Tasks;
using adme360.cms.contracts.Stores;
using adme360.cms.repository.ContractRepositories;
using adme360.common.dtos.Vms.Stores;
using adme360.common.infrastructure.UnitOfWorks;

namespace adme360.cms.services.Stores
{
    public class DeleteStoreProcessor : IDeleteStoreProcessor
    {
        private readonly IUnitOfWork _uOf;
        private readonly IStoreRepository _storeRepository;

        public DeleteStoreProcessor(IUnitOfWork uOf,
            IStoreRepository storeRepository)
        {
            _uOf = uOf;
            _storeRepository = storeRepository;
        }

        public Task DeleteStoreAsync(Guid storeToBeDeletedId)
        {
            throw new NotImplementedException();
        }

        public Task<StoreForDeletionUiModel> SoftDeleteStoreAsync(Guid userAuditId, Guid id)
        {
          throw new NotImplementedException();
        }

        public Task<StoreForDeletionUiModel> HardDeleteStoreAsync(Guid userAuditId, Guid id)
        {
          throw new NotImplementedException();
        }
    }
}