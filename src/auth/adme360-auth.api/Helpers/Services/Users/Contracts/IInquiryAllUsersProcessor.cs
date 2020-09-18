using System.Threading.Tasks;
using adme360.auth.api.Helpers.Models;
using adme360.common.infrastructure.Helpers.ResourceParameters;
using adme360.common.infrastructure.Paging;

namespace adme360.auth.api.Helpers.Services.Users.Contracts
{
    public interface IInquiryAllUsersProcessor
    {
        Task<PagedList<User>> GetUsersAsync(UsersResourceParameters personsResourceParameters);
    }
}