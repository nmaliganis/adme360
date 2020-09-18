using System.Threading.Tasks;
using adme360.common.dtos.Vms.Users;

namespace adme360.cms.contracts.Users
{
    public interface IInquiryUserProcessor
    {
        Task<UserUiModel> GetUserByLoginAsync(string login);
        Task<UserForRetrievalUiModel> GetAuthUserByLoginAsync(string login);
    }
}