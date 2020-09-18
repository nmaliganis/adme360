using adme360.auth.api.Helpers.Services.Roles.Contracts;
using adme360.auth.api.Helpers.Services.Roles.Contracts.V1;

namespace adme360.auth.api.Helpers.Services.Roles.Impls.V1
{
    public class RolesControllerDependencyBlock : IRolesControllerDependencyBlock
    {
        public RolesControllerDependencyBlock(ICreateRoleProcessor createRoleProcessor
            ,IInquiryRoleProcessor inquiryRoleProcessor
            ,IUpdateRoleProcessor updateRoleProcessor
            ,IInquiryAllRolesProcessor allRoleProcessor
            ,IDeleteRoleProcessor deleteRoleProcessor
        )

        {
            CreateRoleProcessor = createRoleProcessor;
            InquiryRoleProcessor = inquiryRoleProcessor;
            UpdateRoleProcessor = updateRoleProcessor;
            InquiryAllRolesProcessor = allRoleProcessor;
            DeleteRoleProcessor = deleteRoleProcessor;
        }

        public ICreateRoleProcessor CreateRoleProcessor { get; private set; }
        public IInquiryRoleProcessor InquiryRoleProcessor { get; private set; }
        public IUpdateRoleProcessor UpdateRoleProcessor { get; private set; }
        public IInquiryAllRolesProcessor InquiryAllRolesProcessor { get; private set; }
        public IDeleteRoleProcessor DeleteRoleProcessor { get; private set; }
    }
}