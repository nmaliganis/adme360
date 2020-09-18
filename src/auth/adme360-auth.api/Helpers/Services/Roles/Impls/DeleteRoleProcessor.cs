using System;
using System.Threading.Tasks;
using adme360.auth.api.Helpers.Repositories.Roles;
using adme360.auth.api.Helpers.Services.Roles.Contracts;
using adme360.common.infrastructure.UnitOfWorks;

namespace adme360.auth.api.Helpers.Services.Roles.Impls
{
    public class DeleteRoleProcessor : IDeleteRoleProcessor
    {
        private readonly IUnitOfWork _uOf;
        private readonly IRoleRepository _roleRepository;

        public DeleteRoleProcessor(IUnitOfWork uOf,
            IRoleRepository roleRepository)
        {
            _uOf = uOf;
            _roleRepository = roleRepository;
        }

        public Task DeleteRoleAsync(Guid roleToBeDeletedId, Guid accountIdToDeleteThisRole)
        {
            throw new NotImplementedException();
        }
    }
}