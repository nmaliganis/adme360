using System;
using System.Threading.Tasks;
using adme360.common.dtos.Vms.Persons;

namespace adme360.auth.api.Helpers.Services.Persons
{
    public interface IInquiryPersonProcessor
    {
        Task<PersonUiModel> GetPersonAsync(Guid id);
        Task<PersonUiModel> GetPersonByEmailAsync(string email);
        Task<bool> SearchIfAnyPersonByEmailOrLoginExistsAsync(string login);
    }
}