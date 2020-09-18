using System;
using System.Threading.Tasks;
using adme360.auth.api.Helpers.Repositories.Roles;
using adme360.auth.api.Helpers.Services.Roles.Contracts;
using adme360.common.dtos.Vms.Roles;
using adme360.common.infrastructure.TypeMappings;

namespace adme360.auth.api.Helpers.Services.Roles.Impls
{
    public class InquiryRoleProcessor : IInquiryRoleProcessor
    {
        private readonly IAutoMapper _autoMapper;
        private readonly IRoleRepository _roleRepository;
        public InquiryRoleProcessor(IRoleRepository roleRepository, IAutoMapper autoMapper)
        {
            _roleRepository = roleRepository;
            _autoMapper = autoMapper;
        }

        public Task<RoleUiModel> GetRoleByIdAsync(Guid id)
        {
            return Task.Run(() => _autoMapper.Map<RoleUiModel>(_roleRepository.FindBy(id)));
        }
    }
}