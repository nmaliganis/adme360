using System;
using System.Threading.Tasks;

namespace adme360.auth.api.Helpers.Services.Roles.Contracts
{
    public interface IDeleteRoleProcessor
    {
        Task DeleteRoleAsync(Guid roleToBeDeletedId, Guid accountIdToDeleteThisRole);
    }
}