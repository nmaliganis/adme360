using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using adme360.models.DTOs.Users.Roles;
using adme360.presenter.ServiceAgents.Contracts;
using adme360.presenter.ServiceAgents.Impls.Base;

namespace adme360.presenter.ServiceAgents.Impls
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