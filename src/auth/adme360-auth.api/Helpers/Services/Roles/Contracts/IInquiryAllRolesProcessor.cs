using System.Threading.Tasks;
using adme360.auth.api.Helpers.Models;
using adme360.common.infrastructure.Helpers.ResourceParameters;
using adme360.common.infrastructure.Paging;

namespace adme360.auth.api.Helpers.Services.Roles.Contracts
{
    public interface IInquiryAllRolesProcessor
    {
        Task<PagedList<Role>> GetRolesAsync(RolesResourceParameters rolesResourceParameters);
        Task<int> GetTotalCountRolesAsync();
    }
}