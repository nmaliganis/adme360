using System;
using adme360.cms.model.Users;
using adme360.common.infrastructure.Domain;
using adme360.common.infrastructure.Domain.Queries;

namespace adme360.cms.repository.ContractRepositories
{
    public interface IRoleRepository : IRepository<Role, Guid>
    {
        QueryResult<Role> FindAllActiveRolesPagedOf(int? pageNum, int? pageSize);
        int FindCountAllActiveRoles();

        Role FindRoleByName(string name);
    }
}
