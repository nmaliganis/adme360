using System;
using System.Threading.Tasks;
using adme360.auth.api.Helpers.Repositories.Customers;
using adme360.common.dtos.Vms.Persons;
using adme360.common.infrastructure.TypeMappings;

namespace adme360.auth.api.Helpers.Services.Persons
{
    public class InquiryPersonProcessor : IInquiryPersonProcessor
    {
        private readonly IAutoMapper _autoMapper;
        private readonly ICustomerRepository _customerRepository;
        public InquiryPersonProcessor(ICustomerRepository customerRepository, IAutoMapper autoMapper)
        {
            _customerRepository = customerRepository;
            _autoMapper = autoMapper;
        }

        public Task<PersonUiModel> GetPersonAsync(Guid id)
        {
            return Task.Run(() => _autoMapper.Map<PersonUiModel>(_customerRepository.FindBy(id)));
        }

        public Task<PersonUiModel> GetPersonByEmailAsync(string email)
        {
            return Task.Run(() => _autoMapper.Map<PersonUiModel>(_customerRepository.FindCustomerByEmail(email)));
        }

        public Task<bool> SearchIfAnyPersonByEmailOrLoginExistsAsync(string login)
        {
            return Task.Run(() =>  _customerRepository.FindCustomersByEmailOrLogin(login).Count > 0);
        }
    }
}