using adme360.cms.contracts.Users;

namespace adme360.cms.contracts.V1
{
    public interface IUsersControllerDependencyBlock
    {
        IInquiryUserProcessor InquiryUserProcessor { get; }
    }
}