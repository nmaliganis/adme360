using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using adme360.auth.api.Helpers.Security;
using adme360.auth.api.Helpers.Services.Users.Contracts;
using adme360.auth.api.Helpers.Services.Users.Contracts.V1;
using adme360.auth.api.Validators;
using adme360.common.dtos.Vms.Accounts;
using adme360.common.dtos.Vms.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Serilog;

namespace adme360.auth.api.Controllers.API
{
    //[ApiExplorerSettings(IgnoreApi = true)]
    [ApiVersionNeutral]
    [ResponseCache(Duration = 0, NoStore = true, VaryByHeader = "*")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserJwtController : ControllerBase
    {
      private readonly IConfiguration _configuration;
      private readonly IInquiryUserProcessor _inquiryUserProcessor;
      private readonly IUpdateUserProcessor _updateUserProcessor;

      public UserJwtController(IConfiguration configuration, IInquiryUserProcessor inquiryUserProcessor,
        IUsersControllerDependencyBlock userBlock)
      {
        _configuration = configuration;
        _inquiryUserProcessor = inquiryUserProcessor;
        _updateUserProcessor = userBlock.UpdateUserProcessor;
      }

      [Route("authtoken", Name = "SetUserJwtRoute")]
      [HttpPost]
      [AllowAnonymous]
      public async Task<IActionResult> SetUserJwtAsync([FromBody] LoginUiModel loginVm)
      {
        DateTime startDate;
        DateTime endDate;
        Log.Debug("---------------------");
        Log.Debug($"{startDate = DateTime.Now}");
        Log.Debug("---------------------");

        var registeredUser = await _inquiryUserProcessor.GetUserAuthJwtTokenByLoginAndPasswordAsync(loginVm.Login,
          HashHelper.Sha512(loginVm.Password + loginVm.Login));


        Log.Debug("---------------------");
        Log.Debug($"{endDate = DateTime.Now}");
        Log.Debug("---------------------");
        Log.Debug($"{(endDate - startDate).Milliseconds}.msec");
        Log.Debug("---------------------");

      if (registeredUser == null)
          return BadRequest("WRONG_USER_PASS");

        if (!registeredUser.IsActivated)
          return BadRequest("NOT_ACTIVATED");

        Guid newRefreshedToken = Guid.NewGuid();

        Log.Debug("---------------------");
        Log.Debug($"{startDate = DateTime.Now}");
        Log.Debug("---------------------");

      registeredUser =
          await _updateUserProcessor.UpdateUserWithNewRefreshTokenAsync(registeredUser, newRefreshedToken);

        Log.Debug("---------------------");
        Log.Debug($"{endDate = DateTime.Now}");
        Log.Debug("---------------------");
        Log.Debug($"{(endDate - startDate).Milliseconds}.msec");
        Log.Debug("---------------------");


      var tokenValue = GenerateJwtToken(registeredUser);

        return Ok(new AuthUiModel {Token = tokenValue, RefreshToken = newRefreshedToken.ToString()});
      }

      private string GenerateJwtToken(UserForRetrievalUiModel registeredUser)
      {
        List<Claim> claims = new List<Claim>
        {
          new Claim(ClaimTypes.Email, registeredUser.Login),
        };

        if (registeredUser.Roles != null)
        {
          foreach (var userRole in registeredUser.Roles)
          {
            claims.Add(new Claim(ClaimTypes.Role, userRole.Name));
          }
        }

        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(this._configuration.GetSection("TokenAuthentication:SecretKey").Value);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
          Subject = new ClaimsIdentity(claims),
          Expires = DateTime.Now.AddMinutes(int.Parse(this._configuration
            .GetSection("TokenAuthentication:ExpirationTimeInMinutes").Value)),
          Issuer = this._configuration.GetSection("TokenAuthentication:Issuer").Value,
          Audience = this._configuration.GetSection("TokenAuthentication:Audience").Value,
          SigningCredentials =
            new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        string tokenValue = tokenHandler.WriteToken(token);
        return tokenValue;
      }


      /// <summary>
      /// PUT : Expire OnDemand Refresh Token providing RefreshToken.
      /// </summary>
      /// <param name="refreshToken">RefreshToken key for specified user</param>
      /// <remarks> return the ResponseEntity with status 200 (Ok) and the new set of Auth and Refresh Token in body, or status 500 (Internal Server Error) if an error occured</remarks>
      /// <response code="200">(OK) and the activated user in body</response>
      /// <response code="500">500 (Internal Server Error)</response>
      [Route("authtoken/logout", Name = "PutUserExpireRefreshTokenRoute")]
      [HttpPut]
      [ValidateModel]
      [Authorize]
      public async Task<IActionResult> PutUserExpireRefreshTokenAsync(
        [Required] [FromBody] UserForRefreshTokenModificationUiModel refreshToken)
      {
        return Ok(await _updateUserProcessor.UpdateUserRefreshTokenExpiredAsync(new Guid(refreshToken.RefreshToken)));
      }

      /// <summary>
      /// GET : New Token providing RefreshToken.
      /// </summary>
      /// <param name="refreshToken">RefreshToken key for specified user</param>
      /// <remarks> return the ResponseEntity with status 200 (Ok) and the new set of Auth and Refresh Token in body, or status 500 (Internal Server Error) if an error occured</remarks>
      /// <response code="200">(OK) and the activated user in body</response>
      /// <response code="500">500 (Internal Server Error)</response>
      [Route("authtoken/{refreshToken}", Name = "GetNewTokenByRefreshRoute")]
      [HttpGet]
      [AllowAnonymous]
      public async Task<IActionResult> GetNewTokenByRefreshAsync(string refreshToken)
      {
        var registeredUser =
          await _inquiryUserProcessor.GetUserAuthJwtTokenByRefreshTokenAsync(new Guid(refreshToken));

        if (registeredUser == null)
          return BadRequest("WRONG_USER_REFRESH_TOKEN");

        if (!registeredUser.IsActivated)
          return BadRequest("NOT_ACTIVATED");

        registeredUser = await _updateUserProcessor.UpdateUserRefreshTokenAsync(new Guid(refreshToken));

        var tokenValue = GenerateJwtToken(registeredUser);

        return Ok(new AuthUiModel {Token = tokenValue, RefreshToken = registeredUser.RefreshToken});
      }
    }
}
