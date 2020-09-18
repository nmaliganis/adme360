using System;
using System.Linq;
using System.Threading.Tasks;
using adme360.cms.contracts.Categories;
using adme360.cms.model.Categories;
using adme360.cms.repository.ContractRepositories;
using adme360.common.dtos.Vms.Categories;
using adme360.common.infrastructure.Exceptions.Domain.Categories;
using adme360.common.infrastructure.TypeMappings;
using adme360.common.infrastructure.UnitOfWorks;
using Serilog;

namespace adme360.cms.services.Categories
{
  public class CreateCategoryProcessor : ICreateCategoryProcessor
  {
    private readonly IUnitOfWork _uOf;
    private readonly ICategoryRepository _categoryRepository;
    private readonly IAutoMapper _autoMapper;

    public CreateCategoryProcessor(IUnitOfWork uOf, IAutoMapper autoMapper, ICategoryRepository categoryRepository)
    {
      _uOf = uOf;
      _categoryRepository = categoryRepository;
      _autoMapper = autoMapper;
    }

    public Task<CategoryUiModel> CreateCategoryAsync(Guid accountIdToCreateThisCategory,
      CategoryForCreationUiModel newCategoryUiModel)
    {
      var response =
        new CategoryUiModel()
        {
          Message = "START_CREATION"
        };

      if (newCategoryUiModel == null)
      {
        response.Message = "ERROR_INVALID_CATEGORY_MODEL";
        return Task.Run(() => response);
      }

      try
      {
        var categoryToBeCreated = _autoMapper.Map<Category>(newCategoryUiModel);

        categoryToBeCreated.InjectWithAudit(accountIdToCreateThisCategory);

        ThrowExcIfCategoryCannotBeCreated(categoryToBeCreated);
        ThrowExcIfThisCategoryAlreadyExist(categoryToBeCreated);

        Log.Debug(
          $"Create Category: {newCategoryUiModel.CategoryName}" +
          "--CreateCategory--  @NotComplete@ [CreateCategoryProcessor]. " +
          "Message: Just Before MakeItPersistence");

        MakeCategoryPersistent(categoryToBeCreated);

        Log.Debug(
          $"Create Category: {newCategoryUiModel.CategoryName}" +
          "--CreateCategory--  @Complete@ [CreateCategoryProcessor]. " +
          "Message: Just After MakeItPersistence");
        response = ThrowExcIfCategoryWasNotBeMadePersistent(categoryToBeCreated);
        response.Message = "SUCCESS_CREATION";
      }
      catch (InvalidCategoryException e)
      {
        response.Message = "ERROR_INVALID_CATEGORY_MODEL";
        Log.Error(
          $"Create Category: {newCategoryUiModel.CategoryName}" +
          "--CreateCategory--  @NotComplete@ [CreateCategoryProcessor]. " +
          $"Broken rules: {e.BrokenRules}");
      }
      catch (CategoryAlreadyExistsException ex)
      {
        response.Message = "ERROR_CATEGORY_ALREADY_EXISTS";
        Log.Error(
          $"Create Category: {newCategoryUiModel.CategoryName}" +
          "--CreateCategory--  @fail@ [CreateCategoryProcessor]. " +
          $"@innerfault:{ex?.Message} and {ex?.InnerException}");
      }
      catch (CategoryDoesNotExistAfterMadePersistentException exx)
      {
        response.Message = "ERROR_CATEGORY_NOT_MADE_PERSISTENT";
        Log.Error(
          $"Create Category: {newCategoryUiModel.CategoryName}" +
          "--CreateCategory--  @fail@ [CreateCategoryProcessor]." +
          $" @innerfault:{exx?.Message} and {exx?.InnerException}");
      }
      catch (Exception exxx)
      {
        response.Message = "UNKNOWN_ERROR";
        Log.Error(
          $"Create Category: {newCategoryUiModel.CategoryName}" +
          $"--CreateCategory--  @fail@ [CreateCategoryProcessor]. " +
          $"@innerfault:{exxx.Message} and {exxx.InnerException}");
      }

      return Task.Run(() => response);
    }

    private void MakeCategoryPersistent(Category categoryToBeCreated)
    {
      _categoryRepository.Save(categoryToBeCreated);
      _uOf.Commit();
    }

    private CategoryUiModel ThrowExcIfCategoryWasNotBeMadePersistent(Category categoryToBeCreated)
    {
      var retrievedCategory = _categoryRepository.FindByName(categoryToBeCreated.Name);
      if (retrievedCategory != null)
        return _autoMapper.Map<CategoryUiModel>(retrievedCategory);
      throw new CategoryDoesNotExistAfterMadePersistentException(categoryToBeCreated.Name);
    }

    private void ThrowExcIfThisCategoryAlreadyExist(Category categoryToBeCreated)
    {
      var customerRetrieved = _categoryRepository.FindByName(categoryToBeCreated.Name);
      if (customerRetrieved != null)
      {
        throw new CategoryAlreadyExistsException(categoryToBeCreated.Name,
          categoryToBeCreated.GetBrokenRulesAsString());
      }
    }

    private void ThrowExcIfCategoryCannotBeCreated(Category categoryToBeCreated)
    {
      bool canBeCreated = !categoryToBeCreated.GetBrokenRules().Any();
      if (!canBeCreated)
        throw new InvalidCategoryException(categoryToBeCreated.GetBrokenRulesAsString());
    }
  }
}
