using System.Collections.Generic;
using System.Threading.Tasks;
using adme360.models.DTOs.Users.Roles;
using adme360.presenter.ServiceAgents.Contracts.Base;

namespace adme360.presenter.ServiceAgents.Contracts
{
    public interface IUserRolesService : IEntityService<UserRoleUiModel>
    {
        Task<IList<UserRoleUiModel>> GetAllActiveUserRolesAsync(bool active);
    }
}