using System;
using System.Threading.Tasks;
using adme360.auth.api.Helpers.Repositories.Roles;
using adme360.auth.api.Helpers.Services.Roles.Contracts;
using adme360.common.dtos.Vms.Roles;
using adme360.common.infrastructure.TypeMappings;
using adme360.common.infrastructure.UnitOfWorks;

namespace adme360.auth.api.Helpers.Services.Roles.Impls
{
    public class UpdateRoleProcessor : IUpdateRoleProcessor
    {
        private readonly IUnitOfWork _uOf;
        private readonly IRoleRepository _roleRepository;
        private readonly IAutoMapper _autoMapper;
        public UpdateRoleProcessor(IUnitOfWork uOf, IAutoMapper autoMapper, IRoleRepository roleRepository)
        {
            _uOf = uOf;
            _roleRepository = roleRepository;
            _autoMapper = autoMapper;
        }

        public Task<RoleUiModel> UpdateRoleAsync(Guid roleIdToBeUpdated, Guid accountIdToBeUpdatedThisRole, RoleForModificationUiModel updatedRole)
        {
            throw new NotImplementedException();
        }
    }
}