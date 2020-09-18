using System;
using System.Threading.Tasks;
using adme360.cms.contracts.Customers;
using adme360.cms.repository.ContractRepositories;
using adme360.common.dtos.Vms.Customers;
using adme360.common.infrastructure.TypeMappings;

namespace adme360.cms.services.Customers
{
  public class InquiryCustomerProcessor : IInquiryCustomerProcessor
  {
    private readonly IAutoMapper _autoMapper;
    private readonly ICustomerRepository _customerRepository;

    public InquiryCustomerProcessor(ICustomerRepository customerRepository, IAutoMapper autoMapper)
    {
      _customerRepository = customerRepository;
      _autoMapper = autoMapper;
    }

    public Task<CustomerUiModel> GetCustomerByIdAsync(Guid id)
    {
      var x = _customerRepository.FindBy(id);

      return Task.Run(() => _autoMapper.Map<CustomerUiModel>(_customerRepository.FindBy(id)));
    }

    public Task<CustomerUiModel> GetCustomerByEmailAsync(string email)
    {
      return Task.Run(() => _autoMapper.Map<CustomerUiModel>(_customerRepository.FindOneByEmail(email)));
    }

    public Task<bool> SearchIfAnyPersonByEmailOrLoginExistsAsync(string login)
    {
      return Task.Run(() =>  _customerRepository.FindCustomersByEmailOrLogin(login).Count > 0);
    }
  }
}