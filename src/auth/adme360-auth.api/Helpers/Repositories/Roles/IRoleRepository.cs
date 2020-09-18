using System;
using adme360.auth.api.Helpers.Models;
using adme360.common.infrastructure.Domain;
using adme360.common.infrastructure.Domain.Queries;

namespace adme360.auth.api.Helpers.Repositories.Roles
{
    public interface IRoleRepository : IRepository<Role, Guid>
    {
        QueryResult<Role> FindAllActiveRolesPagedOf(int? pageNum, int? pageSize);
        int FindCountAllActiveRoles();

        Role FindRoleByName(string name);
    }
}
