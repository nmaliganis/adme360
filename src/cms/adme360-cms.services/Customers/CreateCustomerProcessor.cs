using System;
using System.Linq;
using System.Threading.Tasks;
using adme360.cms.contracts.Customers;
using adme360.cms.model.Customers;
using adme360.cms.model.Users;
using adme360.cms.repository.ContractRepositories;
using adme360.common.dtos.Vms.Customers;
using adme360.common.infrastructure.Exceptions.Domain.Categories;
using adme360.common.infrastructure.Exceptions.Domain.Customers;
using adme360.common.infrastructure.Exceptions.Domain.Roles;
using adme360.common.infrastructure.TypeMappings;
using adme360.common.infrastructure.UnitOfWorks;
using Serilog;

namespace adme360.cms.services.Customers
{
  public class CreateCustomerProcessor : ICreateCustomerProcessor
  {
    private readonly IUnitOfWork _uOf;
    private readonly ICustomerRepository _customerRepository;
    private readonly IRoleRepository _roleRepository;
    private readonly ICategoryRepository _categoryRepository;
    private readonly IAutoMapper _autoMapper;

    public CreateCustomerProcessor(IUnitOfWork uOf, IAutoMapper autoMapper, ICategoryRepository categoryRepository,
      ICustomerRepository customerRepository, IRoleRepository roleRepository)
    {
      _uOf = uOf;
      _categoryRepository = categoryRepository;
      _customerRepository = customerRepository;
      _roleRepository = roleRepository;
      _autoMapper = autoMapper;
    }

    public Task<CustomerUiModel> CreateCustomerAsync(Guid accountIdToCreateThisCustomer,
      CustomerForCreationUiModel newCustomerUiModel, bool isAdvertiser)
    {
      var response =
        new CustomerUiModel()
        {
          Message = "START_CREATION"
        };

      if (newCustomerUiModel == null)
      {
        response.Message = "ERROR_INVALID_CUSTOMER_MODEL";
        return Task.Run(() => response);
      }

      try
      {
        var userToBeCreated = new User();
        userToBeCreated.InjectWithInitialAttributes(newCustomerUiModel.CustomerUserLogin,
          newCustomerUiModel.CustomerUserPassword);
        userToBeCreated.InjectWithAuditCreation(accountIdToCreateThisCustomer);

        var roleAdminToBeInjected = _roleRepository.FindRoleByName("ADMIN");
        if (roleAdminToBeInjected == null)
          throw new RoleDoesNotExistException("ADMIN");
        var roleUserToBeInjected = _roleRepository.FindRoleByName("USER");
        if (roleUserToBeInjected == null)
          throw new RoleDoesNotExistException("USER");

        var userRoleAdminToBeInjected = new UserRole();

        userRoleAdminToBeInjected.InjectWithRole(roleAdminToBeInjected);
        userRoleAdminToBeInjected.InjectWithAuditCreation(accountIdToCreateThisCustomer);

        userToBeCreated.InjectWithUserRole(userRoleAdminToBeInjected);

        var userRoleUserToBeInjected = new UserRole();

        userRoleUserToBeInjected.InjectWithRole(roleUserToBeInjected);
        userRoleUserToBeInjected.InjectWithAuditCreation(accountIdToCreateThisCustomer);

        userToBeCreated.InjectWithUserRole(userRoleUserToBeInjected);

        var categoryToBeInjected = _categoryRepository.FindBy(newCustomerUiModel.CustomerCategoryId);
        if (categoryToBeInjected == null)
          throw new CategoryDoesNotExistException(newCustomerUiModel.CustomerCategoryId);

        Customer customerToBeInjected = isAdvertiser ? (Customer) new Advertiser() : new Advertised();

        customerToBeInjected = isAdvertiser
          ? (Customer) _autoMapper.Map<Advertiser>(newCustomerUiModel)
          : _autoMapper.Map<Advertised>(newCustomerUiModel);

        customerToBeInjected.InjectWithAuditCreation(accountIdToCreateThisCustomer);
        customerToBeInjected.InjectWithUser(userToBeCreated);
        customerToBeInjected.InjectWithCategory(categoryToBeInjected);
        
        ThrowExcIfCustomerCannotBeCreated(customerToBeInjected);
        ThrowExcIfThisCustomerAlreadyExist(customerToBeInjected);

        Log.Debug(
          $"Create Customer: {newCustomerUiModel.CustomerVat}" +
          "--CreateCustomer--  @NotComplete@ [CreateCustomerProcessor]. " +
          "Message: Just Before MakeItPersistence");

        MakeCustomerPersistent(customerToBeInjected);

        Log.Debug(
          $"Create Customer: {newCustomerUiModel.CustomerVat}" +
          "--CreateCustomer--  @Complete@ [CreateCustomerProcessor]. " +
          "Message: Just After MakeItPersistence");

        //Todo: Azure Action Send Email for Verification

        response = ThrowExcIfCustomerWasNotBeMadePersistent(customerToBeInjected);
        response.Message = "SUCCESS_CREATION";
      }
      catch (InvalidCustomerException e)
      {
        response.Message = "ERROR_INVALID_CUSTOMER_MODEL";
        Log.Error(
          $"Create Customer: {newCustomerUiModel.CustomerVat}" +
          "--CreateCustomer--  @NotComplete@ [CreateCustomerProcessor]. " +
          $"Broken rules: {e.BrokenRules}");
      }
      catch (CustomerAlreadyExistsException ex)
      {
        response.Message = "ERROR_CUSTOMER_ALREADY_EXISTS";
        Log.Error(
          $"Create Customer: {newCustomerUiModel.CustomerVat}" +
          "--CreateCustomer--  @fail@ [CreateCustomerProcessor]. " +
          $"@innerfault:{ex?.Message} and {ex?.InnerException}");
      }
      catch (CustomerDoesNotExistAfterMadePersistentException exx)
      {
        response.Message = "ERROR_CUSTOMER_NOT_MADE_PERSISTENT";
        Log.Error(
          $"Create Customer: {newCustomerUiModel.CustomerVat}" +
          "--CreateCustomer--  @fail@ [CreateCustomerProcessor]." +
          $" @innerfault:{exx?.Message} and {exx?.InnerException}");
      }
      catch (Exception exxx)
      {
        response.Message = "UNKNOWN_ERROR";
        Log.Error(
          $"Create Customer: {newCustomerUiModel.CustomerVat}" +
          $"--CreateCustomer--  @fail@ [CreateCustomerProcessor]. " +
          $"@innerfault:{exxx.Message} and {exxx.InnerException}");
      }

      return Task.Run(() => response);
    }

    private void MakeCustomerPersistent(Customer customerToBeCreated)
    {
      _customerRepository.Save(customerToBeCreated);
      _uOf.Commit();
    }

    private CustomerUiModel ThrowExcIfCustomerWasNotBeMadePersistent(Customer customerToBeCreated)
    {
      var retrievedCustomer = _customerRepository.FindOneByVat(customerToBeCreated.Vat);
      if (retrievedCustomer != null)
        return _autoMapper.Map<CustomerUiModel>(retrievedCustomer);
      throw new CustomerDoesNotExistAfterMadePersistentException(customerToBeCreated.Vat);
    }

    private void ThrowExcIfThisCustomerAlreadyExist(Customer customerToBeCreated)
    {
      var customerRetrieved = _customerRepository.FindOneByVat(customerToBeCreated.Vat);
      if (customerRetrieved != null)
      {
        throw new CustomerAlreadyExistsException(customerToBeCreated.Vat,
          customerToBeCreated.GetBrokenRulesAsString());
      }
    }

    private void ThrowExcIfCustomerCannotBeCreated(Customer customerToBeCreated)
    {
      bool canBeCreated = !customerToBeCreated.GetBrokenRules().Any();
      if (!canBeCreated)
        throw new InvalidCustomerException(customerToBeCreated.GetBrokenRulesAsString());
    }
  }
}
