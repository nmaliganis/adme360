using System;
using System.Threading.Tasks;
using adme360.common.dtos.Vms.Accounts;
using adme360.common.dtos.Vms.Users;

namespace adme360.auth.api.Helpers.Services.Users.Contracts
{
    public interface ICreateUserProcessor
    {
        Task<UserUiModel> CreateUserAsync(Guid accountIdToCreateThisRole, UserForRegistrationUiModel newUserForRegistration);
    }
}