using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using dl.wm.models.DTOs.Users.Roles;
using dl.wm.presenter.ServiceAgents.Contracts;
using dl.wm.presenter.ServiceAgents.Impls.Base;

namespace dl.wm.presenter.ServiceAgents.Impls
{
    public class UserRolesService : BaseService<UserRoleUiModel>, IUserRolesService
    {
        private static readonly string _serviceName = "UserRolesService";
        public UserRolesService() : base(_serviceName)
        {

        }

        public async Task<IList<UserRoleUiModel>> GetAllActiveUserRolesAsync(bool active)
        {
            UriBuilder builder = CreateUriBuilder();
            builder.Path += $"/{active.ToString()}" ;
            return await RequestProvider.GetAsync<IList<UserRoleUiModel>>(builder.ToString());

        }
    }
}