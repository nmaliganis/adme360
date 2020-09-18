using adme360.cms.contracts.Users;
using adme360.cms.contracts.V1;

namespace adme360.cms.services.V1
{
    public class UsersControllerDependencyBlock : IUsersControllerDependencyBlock
    {
        public UsersControllerDependencyBlock(IInquiryUserProcessor inquiryVehicleProcessor)

        {
            InquiryUserProcessor = inquiryVehicleProcessor;
        }

        public IInquiryUserProcessor InquiryUserProcessor { get; }
    }
}