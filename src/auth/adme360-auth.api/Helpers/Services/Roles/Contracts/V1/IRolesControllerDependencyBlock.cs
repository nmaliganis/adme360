namespace adme360.auth.api.Helpers.Services.Roles.Contracts.V1
{
    public interface IRolesControllerDependencyBlock
    {
        ICreateRoleProcessor CreateRoleProcessor { get; }
        IInquiryRoleProcessor InquiryRoleProcessor { get; }
        IUpdateRoleProcessor UpdateRoleProcessor { get; }
        IInquiryAllRolesProcessor InquiryAllRolesProcessor { get; }
        IDeleteRoleProcessor DeleteRoleProcessor { get; }
    }
}