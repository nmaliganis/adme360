using System;
using System.Threading.Tasks;
using adme360.common.dtos.Vms.Roles;

namespace adme360.auth.api.Helpers.Services.Roles.Contracts
{
    public interface IInquiryRoleProcessor
    {
        Task<RoleUiModel> GetRoleByIdAsync(Guid id);
    }
}