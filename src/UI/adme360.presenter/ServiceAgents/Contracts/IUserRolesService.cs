using System.Collections.Generic;
using System.Threading.Tasks;
using dl.wm.models.DTOs.Users.Roles;
using dl.wm.presenter.ServiceAgents.Contracts.Base;

namespace dl.wm.presenter.ServiceAgents.Contracts
{
    public interface IUserRolesService : IEntityService<UserRoleUiModel>
    {
        Task<IList<UserRoleUiModel>> GetAllActiveUserRolesAsync(bool active);
    }
}