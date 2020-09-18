using System;
using System.Threading.Tasks;
using adme360.common.dtos.Vms.Categories;
using adme360.common.dtos.Vms.Stores;

namespace adme360.cms.contracts.Stores
{
    public interface IInquiryStoreProcessor
    {
        Task<StoreUiModel> GetStoreByIdAsync(Guid id);
        Task<StoreUiModel> GetStoreByEmailAsync(string email);
        Task<bool> SearchIfAnyStoreByEmailOrLoginExistsAsync(string email, string login);
    }
}