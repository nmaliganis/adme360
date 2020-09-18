using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;

namespace adme360.cms.api.Controllers.API.Base
{
  public abstract class BaseController : ControllerBase
  {
    protected string GetEmailFromClaims()
    {
      var claimsPrincipal = User as ClaimsPrincipal;
      var email = claimsPrincipal?.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress")
        .Value;
      return email;
    }
  }
}