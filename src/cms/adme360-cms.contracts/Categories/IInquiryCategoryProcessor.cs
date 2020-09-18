using System;
using System.Threading.Tasks;
using adme360.common.dtos.Vms.Categories;

namespace adme360.cms.contracts.Categories
{
    public interface IInquiryCategoryProcessor
    {
        Task<CategoryUiModel> GetCategoryByIdAsync(Guid id);
        Task<CategoryUiModel> GetCategoryByEmailAsync(string email);
        Task<bool> SearchIfAnyCategoryByEmailOrLoginExistsAsync(string email, string login);
    }
}