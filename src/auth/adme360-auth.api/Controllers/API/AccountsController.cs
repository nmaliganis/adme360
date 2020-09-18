using System;
using System.Threading.Tasks;
using adme360.auth.api.Controllers.API.Base;
using adme360.auth.api.Helpers.Services.Persons;
using adme360.auth.api.Helpers.Services.Users.Contracts;
using adme360.auth.api.Helpers.Services.Users.Contracts.V1;
using adme360.auth.api.Validators;
using adme360.common.dtos.Vms.Accounts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace adme360.auth.api.Controllers.API
{
    [ApiVersionNeutral]
    [Produces("application/json")]
    [ResponseCache(Duration = 0, NoStore = true, VaryByHeader = "*")]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : BaseController
    {

        private readonly IInquiryPersonProcessor _inquiryPersonProcessor;
        private readonly ICreateUserProcessor _createUserProcessor;
        private readonly IActivateUserProcessor _activateUserProcessor;

        private readonly IInquiryUserProcessor _inquiryUserProcessor;


        public AccountsController(IInquiryPersonProcessor inquiryPersonProcessor, IUsersControllerDependencyBlock blockUser)
        {
            _inquiryPersonProcessor = inquiryPersonProcessor;
            _createUserProcessor = blockUser.CreateUserProcessor;
            _activateUserProcessor = blockUser.ActivateUserProcessor;
            _inquiryUserProcessor = blockUser.InquiryUserProcessor;
        }

        /// <summary>
        /// POST : Register a new user.
        /// </summary>
        /// <param name="managedUserVm">managedUserVM the managed user View Model</param>
        /// <remarks> return a ResponseEntity with status 201 (Created) if the new user is registered or 400 (Bad Request) if the login or email is already in use or Validation Request Model Error </remarks>
        /// <response code="201">Created (if the user is registered)</response>
        /// <response code="400">email in use</response>
        [Route("register", Name = "PostAccountRegisterRoute")]
        [HttpPost]
        [ValidateModel]
        [Authorize(Roles = "SU, ADMIN")]
        public async Task<IActionResult> PostAccountRegisterAsync([FromBody] UserForRegistrationUiModel managedUserVm)
        {
          try
          {
            var userAudit = await _inquiryUserProcessor.GetUserByLoginAsync(GetEmailFromClaims());

            if (userAudit == null)
              return BadRequest();

            if (await _inquiryPersonProcessor.SearchIfAnyPersonByEmailOrLoginExistsAsync(managedUserVm.Login))
            {
              Log.Error(
                $"--Method:PostAccountRegisterAsync -- Message:USER_REGISTERED_LOGIN_OR_EMAIL_ALREADY_EXIST-- Datetime:{DateTime.Now} " +
                $"-- UserInfo:{managedUserVm.Login}, ");
              return BadRequest(new {errorMessage = "USERNAME_OR_EMAIL_ALREADY_EXISTS"});
            }

            var registerResponse = await _createUserProcessor.CreateUserAsync(userAudit.Id, managedUserVm);

            switch (registerResponse.Message)
            {
              case ("SUCCESS_CREATION"):
              {
                Log.Information(
                  $"--Method:PostAccountRegisterAsync -- Message:USER_REGISTERED_SUCCESSFULLY -- Datetime:{DateTime.UtcNow} -- UserInfo:{managedUserVm.Login}");
                return Created("/register", new
                {
                  id = registerResponse.Id,
                  username = managedUserVm.Login,
                  email = managedUserVm.Login,
                  isActivated = false,
                  status = "user created - An activation code was created - Needs Activation"
                });
              }
              case ("ERROR_USER_ALREADY_EXISTS"):
              {
                Log.Error(
                  $"--Method:PostAccountRegisterAsync -- Message:ERROR_USER_ALREADY_EXISTS -- Datetime:{DateTime.UtcNow} -- UserInfo:{managedUserVm.Login}");
                return BadRequest(new {errorMessage = "USERNAME_OR_EMAIL_ALREADY_EXISTS"});
              }
              case ("ERROR_USER_NOT_MADE_PERSISTENT"):
              {
                Log.Error(
                  $"--Method:PostAccountRegisterAsync -- Message:ERROR_USER_NOT_MADE_PERSISTENT -- Datetime:{DateTime.UtcNow} -- UserInfo:{managedUserVm.Login}");
                return BadRequest(new {errorMessage = "ERROR_REGISTER_NEW_USER"});
              }
              case ("UNKNOWN_ERROR"):
              {
                Log.Error(
                  $"--Method:PostAccountRegisterAsync -- Message:ERROR_REGISTER_NEW_USER -- Datetime:{DateTime.UtcNow} -- UserInfo:{managedUserVm.Login}");
                return BadRequest(new {errorMessage = "ERROR_REGISTER_NEW_USER"});
              }
            }
          }
          catch (Exception e)
          {
            return BadRequest(new {errorMessage = e.Message});
          }

          return Ok();
        }


        /// <summary>
        /// PUT : Activate the registered user.
        /// </summary>
        /// <param name="userIdToBeActivated">registeredUser Registered User Id to be activated</param>
        /// <remarks> return the ResponseEntity with status 200 (OK) and the activated user in body, or status 500 (Internal Server Error) if the user couldn't be activated </remarks>
        /// <response code="200">(OK) and the activated user in body</response>
        /// <response code="500">500 (Internal Server Error)</response>
        [Route("activate/{userIdToBeActivated}", Name = "PutAccountActivateRoute")]
        [HttpPut]
        [Authorize(Roles = "SU, ADMIN")]
        [ValidateModel]
        public async Task<IActionResult> PutAccountActivateAsync(Guid userIdToBeActivated, [FromBody] AccountForActivationModification accountForActivation)
        {
            if (userIdToBeActivated == Guid.Empty || accountForActivation.ActivationKey == Guid.Empty)
                return BadRequest();

            var userAudit = await _inquiryUserProcessor.GetUserByLoginAsync(GetEmailFromClaims());

            if (userAudit == null)
                return BadRequest(new {errorMessage = "USER_ACTION_NOT_EXISTS"});

            if(!userAudit.IsActivated)
                return BadRequest(new {errorMessage = "USER_ACTION_NOT_ALLOWED"});

            await _activateUserProcessor.UpdateUserActivationΑsync(userIdToBeActivated, userAudit.Id, accountForActivation);

            return Ok(await _inquiryUserProcessor.GetUserByIdAsync(userIdToBeActivated));
        }


        /// <summary>
        /// POST  /account/change_password : changes the current user's password
        /// </summary>
        /// <remarks> return the current user </remarks>
        /// <response code="200">200 (OK) and the updated user in body</response>
        /// <response code="400">400 (Bad Request)</response>
        /// <response code="500">500 (Internal Server Error) if the user couldn't be updated</response>
        [Route("account/change_password", Name = "PostAccountChangePasswordRoute")]
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> PostAccountChangePasswordAsync(
            [FromBody] AccountWithNewPasswordModification passwordModification)
        {
            return Ok();
        }


        /// <summary>
        /// PUT   /account/reset_password/init : Send an email to reset the password of the user
        /// </summary>
        /// <remarks> return the current user </remarks>
        /// <response code="200">200 (OK) and the updated user in body</response>
        /// <response code="400">400 (Bad Request)</response>
        /// <response code="500">500 (Internal Server Error) if the user couldn't be updated</response>
        [Route("account/reset_password/init", Name = "PostAccountResetPasswordInitRoute")]
        [HttpPut]
        [Authorize]
        public async Task<IActionResult> PostAccountResetPasswordInitAsync()
        {
            return Ok();
        }


        /// <summary>
        /// POST   /account/reset_password/finish : Finish to reset the password of the user
        /// </summary>
        /// <remarks> return the current user </remarks>
        /// <response code="200">200 (OK) and the updated user in body</response>
        /// <response code="400">400 (Bad Request)</response>
        /// <response code="500">500 (Internal Server Error) if the user couldn't be updated</response>
        [Route("account/reset_password/finish", Name = "PostAccountResetPasswordFinishRoute")]
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> PostAccountResetPasswordFinishAsync(
            [FromBody] AccountWithNewPasswordModification passwordModification)
        {
            return Ok();
        }
    }
}
