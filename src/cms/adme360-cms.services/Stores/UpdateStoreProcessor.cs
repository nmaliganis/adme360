using System;
using System.Threading.Tasks;
using adme360.cms.contracts.Categories;
using adme360.cms.contracts.Stores;
using adme360.cms.repository.ContractRepositories;
using adme360.common.dtos.Vms.Categories;
using adme360.common.dtos.Vms.Stores;
using adme360.common.infrastructure.TypeMappings;
using adme360.common.infrastructure.UnitOfWorks;

namespace adme360.cms.services.Stores
{
    public class UpdateStoreProcessor : IUpdateStoreProcessor
    {
        private readonly IUnitOfWork _uOf;
        private readonly IStoreRepository _storeRepository;
        private readonly IAutoMapper _autoMapper;
        public UpdateStoreProcessor(IUnitOfWork uOf, IAutoMapper autoMapper, IStoreRepository storeRepository)
        {
            _uOf = uOf;
            _storeRepository = storeRepository;
            _autoMapper = autoMapper;
        }

        public Task<StoreUiModel> UpdateStoreAsync(StoreForModificationUiModel updatedStore)
        {
            throw new NotImplementedException();
        }
    }
}