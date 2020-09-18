using System;
using System.Threading.Tasks;
using adme360.cms.contracts.Stores;
using adme360.cms.repository.ContractRepositories;
using adme360.common.dtos.Vms.Stores;
using adme360.common.infrastructure.TypeMappings;

namespace adme360.cms.services.Stores
{
  public class InquiryStoreProcessor : IInquiryStoreProcessor
  {
    private readonly IAutoMapper _autoMapper;
    private readonly IStoreRepository _storeRepository;

    public InquiryStoreProcessor(IStoreRepository storeRepository, IAutoMapper autoMapper)
    {
      _storeRepository = storeRepository;
      _autoMapper = autoMapper;
    }

    public Task<StoreUiModel> GetStoreByIdAsync(Guid id)
    {
      return Task.Run(() => _autoMapper.Map<StoreUiModel>(_storeRepository.FindBy(id)));
    }

    public Task<StoreUiModel> GetStoreByEmailAsync(string email)
    {
      //return Task.Run(() => _autoMapper.Map<StoreUiModel>(_StoreRepository.FindStoreByEmail(email)));
      return null;
    }

    public Task<bool> SearchIfAnyStoreByEmailOrLoginExistsAsync(string email, string login)
    {
      //return Task.Run(() =>  _StoreRepository.FindStoreByEmailOrLogin(email, login).Count > 0);
      return null;
    }
  }
}