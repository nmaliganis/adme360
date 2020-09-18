using System;
using System.Threading.Tasks;
using adme360.cms.contracts.Stores;
using adme360.cms.repository.ContractRepositories;
using adme360.common.dtos.Vms.Stores;
using adme360.common.infrastructure.TypeMappings;
using adme360.common.infrastructure.UnitOfWorks;

namespace adme360.cms.services.Stores
{
    public class CreateStoreProcessor : ICreateStoreProcessor
    {
        private readonly IUnitOfWork _uOf;
        private readonly IStoreRepository _storeRepository;
        private readonly IAutoMapper _autoMapper;

        public CreateStoreProcessor(IUnitOfWork uOf, IAutoMapper autoMapper, IStoreRepository storeRepository)
        {
            _uOf = uOf;
            _storeRepository = storeRepository;
            _autoMapper = autoMapper;
        }

        public Task<StoreUiModel> CreateStoreAsync(Guid accountIdToCreateThisStore, StoreForCreationUiModel newStoreUiModel)
        {
          throw new NotImplementedException();
        }
    }
}
