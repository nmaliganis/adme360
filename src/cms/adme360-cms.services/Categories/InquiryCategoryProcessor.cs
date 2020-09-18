using System;
using System.Threading.Tasks;
using adme360.cms.contracts.Categories;
using adme360.cms.repository.ContractRepositories;
using adme360.common.dtos.Vms.Categories;
using adme360.common.infrastructure.TypeMappings;

namespace adme360.cms.services.Categories
{
  public class InquiryCategoryProcessor : IInquiryCategoryProcessor
  {
    private readonly IAutoMapper _autoMapper;
    private readonly ICategoryRepository _categoryRepository;

    public InquiryCategoryProcessor(ICategoryRepository categoryRepository, IAutoMapper autoMapper)
    {
      _categoryRepository = categoryRepository;
      _autoMapper = autoMapper;
    }

    public Task<CategoryUiModel> GetCategoryByIdAsync(Guid id)
    {
      return Task.Run(() => _autoMapper.Map<CategoryUiModel>(_categoryRepository.FindBy(id)));
    }

    public Task<CategoryUiModel> GetCategoryByEmailAsync(string email)
    {
      //return Task.Run(() => _autoMapper.Map<CategoryUiModel>(_categoryRepository.FindCategoryByEmail(email)));
      return null;
    }

    public Task<bool> SearchIfAnyCategoryByEmailOrLoginExistsAsync(string email, string login)
    {
      //return Task.Run(() =>  _categoryRepository.FindCategoryByEmailOrLogin(email, login).Count > 0);
      return null;
    }
  }
}