using System;
using System.Linq;
using adme360.cms.model.Users;
using adme360.cms.repository.ContractRepositories;
using adme360.cms.repository.Repositories.Base;
using adme360.common.infrastructure.Domain.Queries;
using adme360.common.infrastructure.Paging;
using NHibernate;
using NHibernate.Criterion;

namespace adme360.cms.repository.Repositories
{
    public class RoleRepository : RepositoryBase<Role, Guid>, IRoleRepository
    {
        public RoleRepository(ISession session)
            : base(session)
        {
        }

        public QueryResult<Role> FindAllActiveRolesPagedOf(int? pageNum, int? pageSize)
        {
            var query = Session.QueryOver<Role>();

            if (pageNum == -1 & pageSize == -1)
            {
                return new QueryResult<Role>(query?
                    .Where(r => r.IsActive == true)
                    .WhereNot(r =>r.Name == "SU")
                    .List().AsQueryable());
            }

            return new QueryResult<Role>(query
                        .Where(r => r.IsActive == true)
                        .WhereNot(r =>r.Name == "SU")
                        .Skip(ResultsPagingUtility.CalculateStartIndex((int)pageNum, (int)pageSize))
                        .Take((int)pageSize).List().AsQueryable(),
                    query.ToRowCountQuery().RowCount(),
                    (int)pageSize)
                ;
        }

        public int FindCountAllActiveRoles()
        {
            int count = 0;

            count = Session
                .CreateCriteria<Role>()
                .Add(Expression.Eq("IsActive", true))
                .SetProjection(
                    Projections.Count(Projections.Id())
                )
                .UniqueResult<int>();

            return count;
        }

        public Role FindRoleByName(string name)
        {
            return
                (Role)
                Session.CreateCriteria(typeof(Role))
                    .Add(Expression.Eq("Name", name))
                    .Add(Expression.Eq("IsActive", true))
                    .SetCacheable(true)
                    .SetCacheMode(CacheMode.Normal)
                    .SetFlushMode(FlushMode.Never)
                    .UniqueResult()
                ;
        }
    }
}
