using System;
using System.Linq;
using System.Threading.Tasks;
using adme360.auth.api.Helpers.Models;
using adme360.auth.api.Helpers.Repositories.Roles;
using adme360.auth.api.Helpers.Services.Roles.Contracts;
using adme360.common.dtos.Vms.Roles;
using adme360.common.infrastructure.Exceptions.Domain.Roles;
using adme360.common.infrastructure.TypeMappings;
using adme360.common.infrastructure.UnitOfWorks;
using Serilog;

namespace adme360.auth.api.Helpers.Services.Roles.Impls
{
    public class CreateRoleProcessor : ICreateRoleProcessor
    {
        private readonly IUnitOfWork _uOf;
        private readonly IRoleRepository _roleRepository;
        private readonly IAutoMapper _autoMapper;

        public CreateRoleProcessor(IUnitOfWork uOf, IAutoMapper autoMapper,
            IRoleRepository roleRepository)
        {
            _uOf = uOf;
            _roleRepository = roleRepository;
            _autoMapper = autoMapper;
        }

        public Task<RoleCreationUiModel> CreateRoleAsync(Guid accountIdToCreateThisRole, RoleForCreationUiModel newRoleUiModel)
        {
            var response =
                new RoleCreationUiModel()
                {
                    Message = "START_CREATION"
                };

            if (newRoleUiModel == null)
            {
                response.Message = "ERROR_INVALID_ROLE_MODEL";
                return Task.Run(() => response);
            }

            try
            {
                var roleToBeCreated = new Role();

                roleToBeCreated.InjectWithInitialAttributes(newRoleUiModel);
                roleToBeCreated.InjectWithAudit(accountIdToCreateThisRole);

                ThrowExcIfRoleCannotBeCreated(roleToBeCreated);
                ThrowExcIfThisRoleAlreadyExist(roleToBeCreated);

                Log.Debug(
                    $"Create Role: {newRoleUiModel.Name}" +
                    "--CreateRole--  @NotComplete@ [CreateRoleProcessor]. " +
                    "Message: Just Before MakeItPersistence");

                MakeRolePersistent(roleToBeCreated);

                Log.Debug(
                    $"Create Role: {newRoleUiModel.Name}" +
                    "--CreateRole--  @NotComplete@ [CreateRoleProcessor]. " +
                    "Message: Just After MakeItPersistence");
                response = ThrowExcIfRoleWasNotBeMadePersistent(roleToBeCreated);
                response.Message = "SUCCESS_CREATION";
            }
            catch (InvalidRoleException e)
            {
                response.Message = "ERROR_INVALID_ROLE_MODEL";
                Log.Error(
                    $"Create Role: {newRoleUiModel.Name}" +
                    $"Error Message:{response.Message}" +
                    "--CreateRole--  @NotComplete@ [CreateRoleProcessor]. " +
                    $"Broken rules: {e.BrokenRules}");
            }
            catch (RoleAlreadyExistsException ex)
            {
                response.Message = "ERRR_ROLE_ALREADY_EXISTS";
                Log.Error(
                    $"Create Role: {newRoleUiModel.Name}" +
                    $"Error Message:{response.Message}" +
                    "--CreateRole--  @fail@ [CreateRoleProcessor]. " +
                    $"@innerfault:{ex?.Message} and {ex?.InnerException}");
            }
            catch (RoleDoesNotExistAfterMadePersistentException exx)
            {
                response.Message = "ERROR_ROLE_NOT_MADE_PERSISTENT";
                Log.Error(
                    $"Create Role: {newRoleUiModel.Name}" +
                    $"Error Message:{response.Message}" +
                    "--CreateRole--  @fail@ [CreateRoleProcessor]." +
                    $" @innerfault:{exx?.Message} and {exx?.InnerException}");
            }
            catch (Exception exxx)
            {
                response.Message = "UNKNOWN_ERROR";
                Log.Error(
                    $"Create Role: {newRoleUiModel.Name}" +
                    $"Error Message:{response.Message}" +
                    $"--CreateRole--  @fail@ [CreateRoleProcessor]. " +
                    $"@innerfault:{exxx.Message} and {exxx.InnerException}");
            }

            return Task.Run(() => response);
        }

        private void ThrowExcIfThisRoleAlreadyExist(Role roleToBeCreated)
        {
            var roleRetrieved = _roleRepository.FindRoleByName(roleToBeCreated.Name);
            if (roleRetrieved != null)
            {
                throw new RoleAlreadyExistsException(roleToBeCreated.Name,
                    roleToBeCreated.GetBrokenRulesAsString());
            }
        }

        private RoleCreationUiModel ThrowExcIfRoleWasNotBeMadePersistent(Role roleToBeCreated)
        {
            var retreievedRole = _roleRepository.FindRoleByName(roleToBeCreated.Name);
            if (retreievedRole  != null)
                return _autoMapper.Map<RoleCreationUiModel>(retreievedRole);
            throw new RoleDoesNotExistAfterMadePersistentException(roleToBeCreated.Name);
        }

        private void ThrowExcIfRoleCannotBeCreated(Role roleToBeCreated)
        {
            bool canBeCreated = !roleToBeCreated.GetBrokenRules().Any();
            if (!canBeCreated)
                throw new InvalidRoleException(roleToBeCreated.GetBrokenRulesAsString());
        }

        private void MakeRolePersistent(Role roleToBeMadePersistence)
        {
            _roleRepository.Save(roleToBeMadePersistence);
            _uOf.Commit();
        }
    }
}
