using System;
using System.Threading.Tasks;
using adme360.common.dtos.Vms.Roles;

namespace adme360.auth.api.Helpers.Services.Roles.Contracts
{
    public interface IUpdateRoleProcessor
    {
        Task<RoleUiModel> UpdateRoleAsync(Guid roleIdToBeUpdated, Guid accountIdToBeUpdatedThisRole, RoleForModificationUiModel updatedRole);
    }
}
