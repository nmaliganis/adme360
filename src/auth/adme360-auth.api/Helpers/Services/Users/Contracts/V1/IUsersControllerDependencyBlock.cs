namespace adme360.auth.api.Helpers.Services.Users.Contracts.V1
{
    public interface IUsersControllerDependencyBlock
    {
        ICreateUserProcessor CreateUserProcessor { get; }
        IActivateUserProcessor ActivateUserProcessor { get; }
        IInquiryUserProcessor InquiryUserProcessor { get; }
        IInquiryAllUsersProcessor InquiryAllUsersProcessor { get; }
        IUpdateUserProcessor UpdateUserProcessor { get; }
    }
}