using System;
using System.Threading.Tasks;
using adme360.cms.api.Controllers.API.Base;
using adme360.cms.api.Validators;
using adme360.cms.contracts.Customers;
using adme360.cms.contracts.Users;
using adme360.cms.contracts.V1;
using adme360.common.dtos.Vms.Categories;
using adme360.common.dtos.Vms.Customers;
using adme360.common.infrastructure.PropertyMappings;
using adme360.common.infrastructure.PropertyMappings.TypeHelpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace adme360.cms.api.Controllers.API.V1
{
  [Produces("application/json")]
  [ApiVersion("1.0")]
  [ResponseCache(Duration = 0, NoStore = true, VaryByHeader = "*")]
  [Route("api/v{version:apiVersion}/[controller]")]
  [ApiController]
  [Authorize]
  public class AdvertisersController : BaseController
  {
    private readonly IUrlHelper _urlHelper;
    private readonly ITypeHelperService _typeHelperService;
    private readonly IPropertyMappingService _propertyMappingService;

    private readonly IInquiryCustomerProcessor _inquiryCustomerProcessor;
    private readonly ICreateCustomerProcessor _createCustomerProcessor;

    private readonly IInquiryUserProcessor _inquiryUserProcessor;


    public AdvertisersController(IUrlHelper urlHelper,
      ITypeHelperService typeHelperService,
      IPropertyMappingService propertyMappingService,
      ICustomersControllerDependencyBlock blockCustomer,
      IUsersControllerDependencyBlock blockUser)
    {
      _urlHelper = urlHelper;
      _typeHelperService = typeHelperService;
      _propertyMappingService = propertyMappingService;

      _inquiryCustomerProcessor = blockCustomer.InquiryCustomerProcessor;
      _createCustomerProcessor = blockCustomer.CreateCustomerProcessor;

      _inquiryUserProcessor = blockUser.InquiryUserProcessor;
    }

    /// <summary>
    /// POST : Create a New Advertiser.
    /// </summary>
    /// <param name="customerForCreationUiModel">CustomerForCreationUiModel the Request Model for Creation</param>
    /// <remarks> return a ResponseEntity with status 201 (Created) if the new Advertiser is created, 400 (Bad Request), 500 (Server Error) </remarks>
    /// <response code="201">Created (if the Advertiser is created)</response>
    /// <response code="400">Bad Request</response>
    /// <response code="500">Internal Server Error</response>
    [HttpPost(Name = "PostAdvertiserRoute")]
    [ValidateModel]
    [Authorize(AuthenticationSchemes = "Bearer", Roles = "SU")]
    public async Task<IActionResult> PostAdvertiserAsync([FromBody] CustomerForCreationUiModel customerForCreationUiModel)
    {
      var userAudit = await _inquiryUserProcessor.GetUserByLoginAsync(GetEmailFromClaims());

      if (userAudit == null)
      {
        return BadRequest("AUDIT_USER_NOT_EXIST");
      }

      if (await _inquiryCustomerProcessor.SearchIfAnyPersonByEmailOrLoginExistsAsync(customerForCreationUiModel.CustomerUserLogin))
      {
        Log.Error(
          $"--Method:PostAdvertiserAsync -- Message:ADVERTISER_LOGIN_OR_EMAIL_ALREADY_EXIST-- Datetime:{DateTime.Now} " +
          $"-- UserInfo:{customerForCreationUiModel.CustomerUserLogin}, ");
        return BadRequest(new {errorMessage = "ADVERTISER_LOGIN_OR_EMAIL_ALREADY_EXIST"});
      }

      var newCreatedAdvertiser = await _createCustomerProcessor.CreateCustomerAsync(userAudit.Id, customerForCreationUiModel, true);

      switch (newCreatedAdvertiser.Message)
      {
        case ("SUCCESS_CREATION"):
          {
            Log.Information(
              $"--Method:PostAdvertiserAsync -- Message:ADVERTISER_CREATION_SUCCESSFULLY -- " +
              $"Datetime:{DateTime.Now} -- AdvertiserInfo:{customerForCreationUiModel.CustomerVat + customerForCreationUiModel.CustomerEmail}");
            return Created(nameof(PostAdvertiserAsync), newCreatedAdvertiser);
          }
        case ("ERROR_ALREADY_EXISTS"):
          {
            Log.Error(
              $"--Method:PostAdvertiserAsync -- Message:ERROR_ADVERTISER_ALREADY_EXISTS -- " +
              $"Datetime:{DateTime.Now} -- AdvertiserInfo:{customerForCreationUiModel.CustomerVat + customerForCreationUiModel.CustomerEmail}");
            return BadRequest(new { errorMessage = "ADVERTISER_ALREADY_EXISTS" });
          }
        case ("ERROR_NOT_MADE_PERSISTENT"):
          {
            Log.Error(
              $"--Method:PostAdvertiserAsync -- Message:ADVERTISER_NOT_MADE_PERSISTENT -- " +
              $"Datetime:{DateTime.Now} -- AdvertiserInfo:{customerForCreationUiModel.CustomerVat + customerForCreationUiModel.CustomerEmail}");
            return BadRequest(new { errorMessage = "ERROR_CREATION_NEW_ADVERTISER" });
          }
        case ("UNKNOWN_ERROR"):
          {
            Log.Error(
              $"--Method:PostAdvertiserAsync -- Message:ERROR_CREATION_NEW_ADVERTISER -- " +
              $"Datetime:{DateTime.Now} -- AdvertiserInfo:{customerForCreationUiModel.CustomerVat + customerForCreationUiModel.CustomerEmail}");
            return BadRequest(new { errorMessage = "ERROR_CREATION_NEW_ADVERTISER" });
          }
      }

      return NotFound();
    }


    /// <summary>
    /// Get : Retrieve Stored providing Advertiser Id
    /// </summary>
    /// <param name="id">Advertiser Id the Request Index for Retrieval</param>
    /// <param name="fields">Fiends to be filtered with for the returned Advertiser</param>
    /// <remarks>Retrieve Advertiser Role providing Id and [Optional] fields</remarks>
    /// <response code="200">Resource retrieved correctly</response>
    /// <response code="404">Resource Not Found</response>
    /// <response code="500">Internal Server Error.</response>
    [HttpGet("{id}", Name = "GetAdvertiser")]
    public async Task<IActionResult> GetAdvertiserAsync(Guid id, [FromQuery] string fields)
    {
      return Ok();
    }
  }
}
