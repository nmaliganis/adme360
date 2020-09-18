using System;
using System.Linq;
using System.Threading.Tasks;
using adme360.auth.api.Helpers.Models;
using adme360.auth.api.Helpers.Repositories.Roles;
using adme360.auth.api.Helpers.Repositories.Users;
using adme360.auth.api.Helpers.Services.Users.Contracts;
using adme360.common.dtos.Vms.Accounts;
using adme360.common.dtos.Vms.Users;
using adme360.common.infrastructure.Exceptions.Domain.Roles;
using adme360.common.infrastructure.Exceptions.Domain.Users;
using adme360.common.infrastructure.TypeMappings;
using adme360.common.infrastructure.UnitOfWorks;
using Serilog;

namespace adme360.auth.api.Helpers.Services.Users.Impls
{
  public class CreateUserProcessor : ICreateUserProcessor
  {
    private readonly IUnitOfWork _uOf;
    private readonly IRoleRepository _roleRepository;
    private readonly IUserRepository _userRepository;
    private readonly IAutoMapper _autoMapper;

    public CreateUserProcessor(IUnitOfWork uOf, IAutoMapper autoMapper,
      IUserRepository userRepository,
      IRoleRepository roleRepository)
    {
      _uOf = uOf;
      _userRepository = userRepository;
      _roleRepository = roleRepository;
      _autoMapper = autoMapper;
    }

    public Task<UserUiModel> CreateUserAsync(Guid accountIdToCreateThisUser,
      UserForRegistrationUiModel newUserForRegistration)
    {
      var response =
        new UserUiModel()
        {
          Message = "START_CREATION"
        };

      if (newUserForRegistration == null)
      {
        response.Message = "ERROR_INVALID_USER_MODEL";
        return Task.Run(() => response);
      }

      try
      {
        var userToBeCreated = new User();
        userToBeCreated.InjectWithInitialAttributes(newUserForRegistration);
        userToBeCreated.InjectWithAuditCreation(accountIdToCreateThisUser);

        var roleToBeInjected = _roleRepository.FindBy(newUserForRegistration.UserRoleId);

        if (roleToBeInjected == null)
          throw new RoleDoesNotExistException(newUserForRegistration.UserRoleId);

        var userRoleToBeInjected = new UserRole();

        userRoleToBeInjected.InjectWithRole(roleToBeInjected);
        userRoleToBeInjected.InjectWithAuditCreation(accountIdToCreateThisUser);
        var customerToBeInjected = new Customer()
        {
          Firstname = newUserForRegistration.Firstname,
          Lastname = newUserForRegistration.Lastname,
          Phone = newUserForRegistration.Phone,
          Notes = newUserForRegistration.Notes,
          Address = new Address()
          {
            StreetOne = newUserForRegistration.AddressStreetOne,
            StreetTwo = newUserForRegistration.AddressStreetTwo,
            PostCode = newUserForRegistration.AddressPostCode,
            City = newUserForRegistration.AddressCity,
            Region = newUserForRegistration.AddressRegion,
          },
          Email = newUserForRegistration.Login,
        };

        customerToBeInjected.InjectWithAuditCreation(accountIdToCreateThisUser);

        userToBeCreated.InjectWithCustomer(customerToBeInjected);
        userToBeCreated.InjectWithUserRole(userRoleToBeInjected);

        ThrowExcIfUserCannotBeCreated(userToBeCreated);
        ThrowExcIfThisUserAlreadyExist(userToBeCreated);

        Log.Debug(
          $"Create User: {newUserForRegistration.Login}" +
          "--CreateUser--  @NotComplete@ [CreateUserProcessor]. " +
          "Message: Just Before MakeItPersistence");

        MakeUserPersistent(userToBeCreated);

        Log.Debug(
          $"Create User: {newUserForRegistration.Login}" +
          "--CreateUser--  @NotComplete@ [CreateUserProcessor]. " +
          "Message: Just After MakeItPersistence");
        response = ThrowExcIfUserWasNotBeMadePersistent(userToBeCreated);
        response.Message = "SUCCESS_CREATION";
      }
      catch (RoleDoesNotExistException r)
      {
        response.Message = "ERROR_INVALID_ROLE_NAME";
        Log.Error(
          $"Create User: {newUserForRegistration.Login}" +
          $"Error Message:{response.Message}" +
          "--CreateUser--  @NotComplete@ [CreateUserProcessor]");
      }
      catch (InvalidUserException e)
      {
        response.Message = "ERROR_INVALID_USER_MODEL";
        Log.Error(
          $"Create User: {newUserForRegistration.Login}" +
          $"Error Message:{response.Message}" +
          "--CreateUser--  @NotComplete@ [CreateUserProcessor]. " +
          $"Broken rules: {e.BrokenRules}");
      }
      catch (UserEmailOrLoginAlreadyExistsException ex)
      {
        response.Message = "ERROR_USER_ALREADY_EXISTS";
        Log.Error(
          $"Create User: {newUserForRegistration.Login}" +
          $"Error Message:{response.Message}" +
          "--CreateUser--  @fail@ [CreateUserProcessor]. " +
          $"@inner-fault:{ex?.Message} and {ex?.InnerException}");
      }
      catch (UserDoesNotExistAfterMadePersistentException exx)
      {
        response.Message = "ERROR_USER_NOT_MADE_PERSISTENT";
        Log.Error(
          $"Create User: {newUserForRegistration.Login}" +
          $"Error Message:{response.Message}" +
          "--CreateUser--  @fail@ [CreateUserProcessor]." +
          $" @inner-fault:{exx?.Message} and {exx?.InnerException}");
      }
      catch (Exception exxx)
      {
        response.Message = "UNKNOWN_ERROR";
        Log.Error(
          $"Create User: {newUserForRegistration.Login}" +
          $"Error Message:{response.Message}" +
          $"--CreateUser--  @fail@ [CreateUserProcessor]. " +
          $"@inner-fault:{exxx.Message} and {exxx.InnerException}");
      }

      return Task.Run(() => response);
    }



    private void ThrowExcIfThisUserAlreadyExist(User userToBeCreated)
    {
      var userRetrieved = _userRepository.FindUserByLoginAndEmail(userToBeCreated.Login, userToBeCreated.Customer?.Email);
      if (userRetrieved != null)
      {
        throw new UserEmailOrLoginAlreadyExistsException(userToBeCreated.Login, userToBeCreated.Customer?.Email,
          userToBeCreated.GetBrokenRulesAsString());
      }
    }

    private UserUiModel ThrowExcIfUserWasNotBeMadePersistent(User userToBeCreated)
    {
      var retrievedUser =
        _userRepository.FindUserByLoginAndEmail(userToBeCreated.Login, userToBeCreated.Customer?.Email);
      if (retrievedUser != null)
        return _autoMapper.Map<UserUiModel>(retrievedUser);
      throw new UserDoesNotExistAfterMadePersistentException(userToBeCreated.Login, userToBeCreated.Customer?.Email);
    }

    private void ThrowExcIfUserCannotBeCreated(User userToBeCreated)
    {
      bool canBeCreated = !userToBeCreated.GetBrokenRules().Any();
      if (!canBeCreated)
        throw new InvalidUserException(userToBeCreated.GetBrokenRulesAsString());
    }

    private void MakeUserPersistent(User userToBeMadePersistence)
    {
      _userRepository.Save(userToBeMadePersistence);
      _uOf.Commit();
    }
  }
}
