using System;
using System.Threading.Tasks;
using adme360.cms.api.Controllers.API.Base;
using adme360.cms.api.Validators;
using adme360.cms.contracts.Customers;
using adme360.cms.contracts.Users;
using adme360.cms.contracts.V1;
using adme360.common.dtos.Vms.Customers;
using adme360.common.infrastructure.PropertyMappings;
using adme360.common.infrastructure.PropertyMappings.TypeHelpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace adme360.cms.api.Controllers.API.V1
{
  [Produces("application/json")]
  [ApiVersion("1.0")]
  [ResponseCache(Duration = 0, NoStore = true, VaryByHeader = "*")]
  [Route("api/v{version:apiVersion}/[controller]")]
  [ApiController]
  [Authorize]
  public class AdvertisedsController : BaseController
  {
    private readonly IUrlHelper _urlHelper;
    private readonly ITypeHelperService _typeHelperService;
    private readonly IPropertyMappingService _propertyMappingService;

    private readonly IInquiryAllCustomersProcessor _inquiryAllCustomersProcessor;
    private readonly IInquiryCustomerProcessor _inquiryCustomerProcessor;
    private readonly ICreateCustomerProcessor _createCustomerProcessor;

    private readonly IInquiryUserProcessor _inquiryUserProcessor;


    public AdvertisedsController(IUrlHelper urlHelper,
      ITypeHelperService typeHelperService,
      IPropertyMappingService propertyMappingService,
      ICustomersControllerDependencyBlock blockCustomer,
      IUsersControllerDependencyBlock blockUser)
    {
      _urlHelper = urlHelper;
      _typeHelperService = typeHelperService;
      _propertyMappingService = propertyMappingService;

      _inquiryAllCustomersProcessor = blockCustomer.InquiryAllCustomersProcessor;
      _inquiryCustomerProcessor = blockCustomer.InquiryCustomerProcessor;
      _createCustomerProcessor = blockCustomer.CreateCustomerProcessor;

      _inquiryUserProcessor = blockUser.InquiryUserProcessor;
    }

    /// <summary>
    /// POST : Create a New Advertised.
    /// </summary>
    /// <param name="customerForCreationUiModel">CustomerForCreationUiModel the Request Model for Creation</param>
    /// <remarks> return a ResponseEntity with status 201 (Created) if the new Category is created, 400 (Bad Request), 500 (Server Error) </remarks>
    /// <response code="201">Created (if the Advertiser is created)</response>
    /// <response code="400">Bad Request</response>
    /// <response code="500">Internal Server Error</response>
    [HttpPost(Name = "PostAdvertisedRoute")]
    [ValidateModel]
    [Authorize(AuthenticationSchemes = "Bearer", Roles = "SU")]
    public async Task<IActionResult> PostAdvertisedRouteAsync([FromBody] CustomerForCreationUiModel customerForCreationUiModel)
    {
      var userAudit = await _inquiryUserProcessor.GetUserByLoginAsync(GetEmailFromClaims());

      if (userAudit == null)
      {
        return BadRequest("AUDIT_USER_NOT_EXIST");
      }

      var newCreatedAdvertised =
        await _createCustomerProcessor.CreateCustomerAsync(userAudit.Id, customerForCreationUiModel, false);

      //switch (newCreatedCategory.Message)
      //{
      //  case ("SUCCESS_CREATION"):
      //  {
      //    Log.Information(
      //      $"--Method:PostCategoryRouteAsync -- Message:CATEGORY_CREATION_SUCCESSFULLY -- " +
      //      $"Datetime:{DateTime.Now} -- CategoryInfo:{categoryForCreationUiModel.CategoryName}");
      //    return Created(nameof(PostCategoryRouteAsync), newCreatedCategory);
      //  }
      //  case ("ERROR_ALREADY_EXISTS"):
      //  {
      //    Log.Error(
      //      $"--Method:PostCategoryRouteAsync -- Message:ERROR_CATEGORY_ALREADY_EXISTS -- " +
      //      $"Datetime:{DateTime.Now} -- CategoryInfo:{categoryForCreationUiModel.CategoryName}");
      //    return BadRequest(new {errorMessage = "CATEGORY_ALREADY_EXISTS"});
      //  }
      //  case ("ERROR_CATEGORY_NOT_MADE_PERSISTENT"):
      //  {
      //    Log.Error(
      //      $"--Method:PostCategoryRouteAsync -- Message:ERROR_CATEGORY_NOT_MADE_PERSISTENT -- " +
      //      $"Datetime:{DateTime.Now} -- CategoryInfo:{categoryForCreationUiModel.CategoryName}");
      //    return BadRequest(new {errorMessage = "ERROR_CREATION_NEW_CATEGORY"});
      //  }
      //  case ("UNKNOWN_ERROR"):
      //  {
      //    Log.Error(
      //      $"--Method:PostCategoryRouteAsync -- Message:ERROR_CREATION_NEW_CATEGORY -- " +
      //      $"Datetime:{DateTime.Now} -- CategoryInfo:{categoryForCreationUiModel.CategoryName}");
      //    return BadRequest(new {errorMessage = "ERROR_CREATION_NEW_CATEGORY"});
      //  }
      //}

      return NotFound();
    }

    /// <summary>
    /// Get : Retrieve Stored providing Advertised Id
    /// </summary>
    /// <param name="id">Advertised Id the Request Index for Retrieval</param>
    /// <param name="fields">Fiends to be filtered with for the returned Advertised</param>
    /// <remarks>Retrieve Advertised Role providing Id and [Optional] fields</remarks>
    /// <response code="200">Resource retrieved correctly</response>
    /// <response code="404">Resource Not Found</response>
    /// <response code="500">Internal Server Error.</response>
    [HttpGet("{id}", Name = "GetAdvertised")]
    public async Task<IActionResult> GetAdvertisedAsync(Guid id, [FromQuery] string fields)
    {
      return Ok();
    }
  }
}
