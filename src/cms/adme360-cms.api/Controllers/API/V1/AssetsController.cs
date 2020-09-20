using System;
using System.Threading.Tasks;
using adme360.cms.api.Controllers.API.Base;
using adme360.cms.api.Validators;
using adme360.cms.contracts.Customers;
using adme360.cms.contracts.Users;
using adme360.cms.contracts.V1;
using adme360.common.dtos.Vms.Assets;
using adme360.common.infrastructure.Helpers.ResourceParameters;
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
  public class AssetsController : BaseController
  {
    private readonly IUrlHelper _urlHelper;
    private readonly ITypeHelperService _typeHelperService;
    private readonly IPropertyMappingService _propertyMappingService;

    private readonly IInquiryCustomerProcessor _inquiryCustomerProcessor;
    private readonly ICreateCustomerProcessor _createCustomerProcessor;

    private readonly IInquiryUserProcessor _inquiryUserProcessor;


    public AssetsController(IUrlHelper urlHelper,
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
    /// Get : Retrieve Stored providing Asset Id
    /// </summary>
    /// <param name="id">Asset Id the Request Index for Retrieval</param>
    /// <param name="fields">Fiends to be filtered with for the returned Asset</param>
    /// <remarks>Retrieve Asset providing Id and [Optional] fields</remarks>
    /// <response code="200">Resource retrieved correctly</response>
    /// <response code="404">Resource Not Found</response>
    /// <response code="500">Internal Server Error.</response>
    [HttpGet("{id}", Name = "GetAssetRoot")]
    public async Task<IActionResult> GetAssetAsync(string id, [FromQuery] string fields)
    {
      return Ok();
    }

    /// <summary>
    /// Get : Retrieve All/or Partial Paged Stored Assets 
    /// </summary>
    /// <remarks>Retrieve paged Assets providing Paging Query</remarks>
    /// <response code="200">Resource retrieved correctly.</response>
    /// <response code="500">Internal Server Error.</response>
    [HttpGet(Name = "GetAssetsRoot")]
    public async Task<IActionResult> GetAssetsAsync(
      [FromQuery] AssetsResourceParameters assetsResourceParameters,
      [FromHeader(Name = "Accept")] string mediaType)
    {
      return Ok();
    }

    /// <summary>
    /// Get : Retrieve All/or Partial Paged Stored Assets by Advertised 
    /// </summary>
    /// <param name="advertisedId">Advertised Id for retrieving Assets</param>
    /// <param name="assetsResourceParameters">Advertised Id for retrieving Assets</param>
    /// <remarks>Retrieve paged Assets providing Paging Query and Advertised Id</remarks>
    /// <response code="200">Resource retrieved correctly.</response>
    /// <response code="500">Internal Server Error.</response>
    [HttpGet("advertised/{advertisedId}", Name = "GetAssetsByAdvertisedRoot")]
    public async Task<IActionResult> GetAssetsByAdvertisedAsync(Guid advertisedId, [FromQuery] AssetsResourceParameters assetsResourceParameters)
    {
      return Ok();
    }

    /// <summary>
    /// POST : Create an Input Asset for Advertised.
    /// </summary>
    /// <param name="assetForCreationUiModel">AssetForCreationUiModel the Request Model for Creation</param>
    /// <remarks> return a ResponseEntity with status 201 (Created) if the new Asset is created, 400 (Bad Request), 500 (Server Error) </remarks>
    /// <response code="201">Created (if the Asset is created)</response>
    /// <response code="400">Bad Request</response>
    /// <response code="500">Internal Server Error</response>
    [HttpPost("advertised/{advertisedId}", Name = "PostAssetInputForAdvertisedRoute")]
    [ValidateModel]
    public async Task<IActionResult> PostAssetInputForAdvertisedAsync(
      [FromBody] AssetForCreationUiModel assetForCreationUiModel)
    {
      return Ok();
    }

    /// <summary>
    /// PUT : Update an Input Asset for Advertised.
    /// </summary>
    /// <param name="id">Asset Id the Request Model for Creation</param>
    /// <param name="assetForCreationUiModel">AssetForModificationUiModel the Request Model for Creation</param>
    /// <remarks> return a ResponseEntity with status 201 (Created) if the new Asset is created, 400 (Bad Request), 500 (Server Error) </remarks>
    /// <response code="201">Created (if the Asset is created)</response>
    /// <response code="400">Bad Request</response>
    /// <response code="500">Internal Server Error</response>
    [HttpPut("{id}/advertised/{advertisedId}", Name = "PutAssetInputForAdvertisedRoute")]
    [ValidateModel]
    public async Task<IActionResult> PutAssetInputForAdvertisedAsync(Guid id, [FromBody] AssetForModificationUiModel assetForCreationUiModel)
    {
      return Ok();
    }
  }
}
