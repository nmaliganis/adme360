using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using adme360.cms.api.Controllers.API.Base;
using adme360.cms.api.Validators;
using adme360.cms.contracts.Stores;
using adme360.cms.contracts.Users;
using adme360.cms.contracts.V1;
using adme360.cms.model.Stores;
using adme360.common.dtos.Links;
using adme360.common.dtos.Vms.Stores;
using adme360.common.dtos.Vms.Users;
using adme360.common.infrastructure.Extensions;
using adme360.common.infrastructure.Helpers;
using adme360.common.infrastructure.Helpers.ResourceParameters;
using adme360.common.infrastructure.PropertyMappings;
using adme360.common.infrastructure.PropertyMappings.TypeHelpers;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Serilog;

namespace adme360.cms.api.Controllers.API.V1
{
  [Produces("application/json")]
  [ApiVersion("1.0")]
  [ResponseCache(Duration = 0, NoStore = true, VaryByHeader = "*")]
  [Route("api/v{version:apiVersion}/[controller]")]
  [ApiController]
  //[Authorize]
  public class StoresController : BaseController
  {
    private readonly IUrlHelper _urlHelper;
    private readonly ITypeHelperService _typeHelperService;
    private readonly IPropertyMappingService _propertyMappingService;

    private readonly IInquiryAllStoresProcessor _inquiryAllStoresProcessor;
    private readonly IInquiryStoreProcessor _inquiryStoreProcessor;
    private readonly ICreateStoreProcessor _createStoreProcessor;
    private readonly IUpdateStoreProcessor _updateStoreProcessor;
    private readonly IDeleteStoreProcessor _deleteStoreProcessor;

    private readonly IInquiryUserProcessor _inquiryUserProcessor;


    public StoresController(IUrlHelper urlHelper,
      ITypeHelperService typeHelperService,
      IPropertyMappingService propertyMappingService,
      IStoresControllerDependencyBlock blockStore,
      IUsersControllerDependencyBlock blockUser)
    {
      _urlHelper = urlHelper;
      _typeHelperService = typeHelperService;
      _propertyMappingService = propertyMappingService;

      _inquiryAllStoresProcessor = blockStore.InquiryAllStoresProcessor;
      _inquiryStoreProcessor = blockStore.InquiryStoreProcessor;
      _createStoreProcessor = blockStore.CreateStoreProcessor;
      _updateStoreProcessor = blockStore.UpdateStoreProcessor;
      _deleteStoreProcessor = blockStore.DeleteStoreProcessor;

      _inquiryUserProcessor = blockUser.InquiryUserProcessor;
    }


    /// <summary>
    /// POST : Create a New Store.
    /// </summary>
    /// <param name="storeForCreationUiModel">StoreForCreationUiModel the Request Model for Creation</param>
    /// <remarks> return a ResponseEntity with status 201 (Created) if the new Store is created, 400 (Bad Request), 500 (Server Error) </remarks>
    /// <response code="201">Created (if the Store is created)</response>
    /// <response code="400">Bad Request</response>
    /// <response code="500">Internal Server Error</response>
    [HttpPost(Name = "PostStoreRoute")]
    [ValidateModel]
    public async Task<IActionResult> PostStoreRouteAsync(
      [FromBody] StoreForCreationUiModel storeForCreationUiModel)
    {
      var userAudit = await _inquiryUserProcessor.GetUserByLoginAsync(GetEmailFromClaims());

      if (userAudit == null)
      {
        userAudit = new UserUiModel()
        {
          Id = Guid.NewGuid()
        };
        //return BadRequest("AUDIT_USER_NOT_EXIST");
      }

      var newCreatedStore =
        await _createStoreProcessor.CreateStoreAsync(userAudit.Id, storeForCreationUiModel);

      switch (newCreatedStore.Message)
      {
        case ("SUCCESS_CREATION"):
        {
          Log.Information(
            $"--Method:PostStoreRouteAsync -- Message:STORE_CREATION_SUCCESSFULLY -- " +
            $"Datetime:{DateTime.Now} -- StoreInfo:{storeForCreationUiModel.StoreName}");
          return Created(nameof(PostStoreRouteAsync), newCreatedStore);
        }
        case ("ERROR_ALREADY_EXISTS"):
        {
          Log.Error(
            $"--Method:PostStoreRouteAsync -- Message:ERROR_STORE_ALREADY_EXISTS -- " +
            $"Datetime:{DateTime.Now} -- StoreInfo:{storeForCreationUiModel.StoreName}");
          return BadRequest(new {errorMessage = "STORE_ALREADY_EXISTS"});
        }
        case ("ERROR_STORE_NOT_MADE_PERSISTENT"):
        {
          Log.Error(
            $"--Method:PostStoreRouteAsync -- Message:ERROR_STORE_NOT_MADE_PERSISTENT -- " +
            $"Datetime:{DateTime.Now} -- StoreInfo:{storeForCreationUiModel.StoreName}");
          return BadRequest(new {errorMessage = "ERROR_CREATION_NEW_STORE"});
        }
        case ("UNKNOWN_ERROR"):
        {
          Log.Error(
            $"--Method:PostStoreRouteAsync -- Message:ERROR_CREATION_NEW_STORE -- " +
            $"Datetime:{DateTime.Now} -- StoreInfo:{storeForCreationUiModel.StoreName}");
          return BadRequest(new {errorMessage = "ERROR_CREATION_NEW_STORE"});
        }
      }

      return NotFound();
    }

    /// <summary>
    /// Get : Retrieve Stored providing Store Id
    /// </summary>
    /// <param name="id">Store Id the Request Index for Retrieval</param>
    /// <param name="fields">Fiends to be filtered with for the returned Store</param>
    /// <remarks>Retrieve Store Role providing Id and [Optional] fields</remarks>
    /// <response code="200">Resource retrieved correctly</response>
    /// <response code="404">Resource Not Found</response>
    /// <response code="500">Internal Server Error.</response>
    [HttpGet("{id}", Name = "GetStore")]
    public async Task<IActionResult> GetStoreAsync(Guid id, [FromQuery] string fields)
    {
      if (!_typeHelperService.TypeHasProperties<StoreUiModel>
        (fields))
      {
        return BadRequest();
      }

      var storeFromRepo = await _inquiryStoreProcessor.GetStoreByIdAsync(id);

      if (storeFromRepo == null)
      {
        return NotFound();
      }

      var store = Mapper.Map<StoreUiModel>(storeFromRepo);

      var links = CreateLinksForStore(id, fields);

      var linkedResourceToReturn = store.ShapeData(fields)
        as IDictionary<string, object>;

      linkedResourceToReturn.Add("links", links);

      return Ok(linkedResourceToReturn);
    }

    /// <summary>
    /// PUT : Update an Existing Store.
    /// </summary>
    /// <param name="id">Store Id for Modification</param>
    /// <param name="storeForModificationUiModel">StoreForModificationUiModel the Request Model for Modification</param>
    /// <remarks> return a ResponseEntity with status 201 (Created) if the new Container is created, 400 (Bad Request), 500 (Server Error) </remarks>
    /// <response code="200">Ok (if the Store is updated)</response>
    /// <response code="400">Bad Request</response>
    /// <response code="500">Internal Server Error</response>
    [HttpPut("{id}", Name = "PutStoreRoute")]
    [ValidateModel]
    public async Task<IActionResult> UpdateStoreAsync(Guid id,
      [FromBody] StoreForModificationUiModel storeForModificationUiModel)
    {
      return BadRequest(new {errorMessage = "UNKNOWN_ERROR_UPDATE_STORE"});
    }

    /// <summary>
    /// Delete - Delete an existing Store 
    /// </summary>
    /// <param name="id">Store Id for Deletion</param>
    /// <remarks>Delete Existing Store </remarks>
    /// <response code="200">Resource retrieved correctly</response>
    /// <response code="400">Resource Not Found</response>
    /// <response code="500">Internal Server Error.</response>
    [HttpDelete("{id}", Name = "DeleteStoreRoot")]
    public async Task<IActionResult> DeleteStoreAsync(Guid id)
    {
      var userAudit = await _inquiryUserProcessor.GetUserByLoginAsync(GetEmailFromClaims());

      if (userAudit == null)
        return BadRequest();

      var storeToBeSoftDeleted = await _deleteStoreProcessor.SoftDeleteStoreAsync(userAudit.Id, id);

      return Ok(storeToBeSoftDeleted);
    }

    /// <summary>
    /// Delete - Delete an existing Store 
    /// </summary>
    /// <param name="id">Store Id for Deletion</param>
    /// <remarks>Delete Existing Store </remarks>
    /// <response code="200">Resource retrieved correctly</response>
    /// <response code="400">Resource Not Found</response>
    /// <response code="500">Internal Server Error.</response>
    [HttpDelete("hard/{id}", Name = "DeleteHardStoreRoot")]
    [Authorize(AuthenticationSchemes = "Bearer", Roles = "SU")]
    public async Task<IActionResult> DeleteHardStoreAsync(Guid id)
    {
      var userAudit = await _inquiryUserProcessor.GetUserByLoginAsync(GetEmailFromClaims());

      if (userAudit == null)
        return BadRequest();

      var storeToBeDeleted = await _deleteStoreProcessor.HardDeleteStoreAsync(userAudit.Id, id);

      return Ok(storeToBeDeleted.DeletionStatus);
    }


    /// <summary>
    /// Get : Retrieve All/or Partial Paged Stored Stores 
    /// </summary>
    /// <remarks>Retrieve paged Stores providing Paging Query</remarks>
    /// <response code="200">Resource retrieved correctly.</response>
    /// <response code="500">Internal Server Error.</response>
    [HttpGet(Name = "GetStores")]
    public async Task<IActionResult> GetStoresAsync([FromQuery]StoresResourceParameters storesResourceParameters,
      [FromHeader(Name = "Accept")] string mediaType)
    {
      if (!_propertyMappingService.ValidMappingExistsFor<StoreUiModel, Store>
        (storesResourceParameters.OrderBy))
      {
        return BadRequest();
      }

      if (!_typeHelperService.TypeHasProperties<StoreUiModel>
        (storesResourceParameters.Fields))
      {
        return BadRequest();
      }

      var storesQueryable =
        await _inquiryAllStoresProcessor.GetStoresAsync(storesResourceParameters);

      var stores = Mapper.Map<IEnumerable<StoreUiModel>>(storesQueryable);

      if (mediaType.Contains("application/vnd.marvin.hateoas+json"))
      {
        var paginationMetadata = new
        {
          totalCount = storesQueryable.TotalCount,
          pageSize = storesQueryable.PageSize,
          currentPage = storesQueryable.CurrentPage,
          totalPages = storesQueryable.TotalPages,
        };

        Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(paginationMetadata));

        var links = CreateLinksForStores(storesResourceParameters,
          storesQueryable.HasNext, storesQueryable.HasPrevious);

        var shapedStores = stores.ShapeData(storesResourceParameters.Fields);

        var shapedStoresWithLinks = shapedStores.Select(store =>
        {
          var storeAsDictionary = store as IDictionary<string, object>;
          var storeLinks =
            CreateLinksForStore((Guid) storeAsDictionary["Id"], storesResourceParameters.Fields);

          storeAsDictionary.Add("links", storeLinks);

          return storeAsDictionary;
        });

        var linkedCollectionResource = new
        {
          value = shapedStoresWithLinks,
          links = links
        };

        return Ok(linkedCollectionResource);
      }
      else
      {
        var previousPageLink = storesQueryable.HasPrevious ? CreateStoresResourceUri(storesResourceParameters,
            ResourceUriType.PreviousPage)
          : null;

        var nextPageLink = storesQueryable.HasNext
          ? CreateStoresResourceUri(storesResourceParameters, ResourceUriType.NextPage)
          : null;

        var paginationMetadata = new
        {
          previousPageLink = previousPageLink,
          nextPageLink = nextPageLink,
          totalCount = storesQueryable.TotalCount,
          pageSize = storesQueryable.PageSize,
          currentPage = storesQueryable.CurrentPage,
          totalPages = storesQueryable.TotalPages
        };

        Response.Headers.Add("X-Pagination",
          JsonConvert.SerializeObject(paginationMetadata));

        return Ok(stores.ShapeData(storesResourceParameters.Fields));
      }
    }

    #region Link Builder

    private IEnumerable<LinkDto> CreateLinksForStore(Guid id, string fields)
    {
      var links = new List<LinkDto>();

      if (String.IsNullOrWhiteSpace(fields))
      {
        links.Add(
          new LinkDto(_urlHelper.Link("GetStore", new {id = id}),
            "self",
            "GET"));
      }
      else
      {
        links.Add(
          new LinkDto(_urlHelper.Link("GetStore", new {id = id, fields = fields}),
            "self",
            "GET"));
      }

      return links;
    }


    private IEnumerable<LinkDto> CreateLinksForStores(
      StoresResourceParameters storesResourceParameters,
      bool hasNext, bool hasPrevious)
    {
      var links = new List<LinkDto>
      {
        new LinkDto(CreateStoresResourceUri(storesResourceParameters,
            ResourceUriType.Current)
          , "self", "GET")
      };

      if (hasNext)
      {
        links.Add(
          new LinkDto(CreateStoresResourceUri(storesResourceParameters,
              ResourceUriType.NextPage),
            "nextPage", "GET"));
      }

      if (hasPrevious)
      {
        links.Add(
          new LinkDto(CreateStoresResourceUri(storesResourceParameters,
              ResourceUriType.PreviousPage),
            "previousPage", "GET"));
      }

      return links;
    }

    private string CreateStoresResourceUri(StoresResourceParameters storesResourceParameters,
      ResourceUriType type)
    {
      switch (type)
      {
        case ResourceUriType.PreviousPage:
          return _urlHelper.Link("GetStores",
            new
            {
              fields = storesResourceParameters.Fields,
              orderBy = storesResourceParameters.OrderBy,
              searchQuery = storesResourceParameters.SearchQuery,
              pageNumber = storesResourceParameters.PageIndex - 1,
              pageSize = storesResourceParameters.PageSize
            });
        case ResourceUriType.NextPage:
          return _urlHelper.Link("GetStores",
            new
            {
              fields = storesResourceParameters.Fields,
              orderBy = storesResourceParameters.OrderBy,
              searchQuery = storesResourceParameters.SearchQuery,
              pageNumber = storesResourceParameters.PageIndex + 1,
              pageSize = storesResourceParameters.PageSize
            });
        case ResourceUriType.Current:
        default:
          return _urlHelper.Link("GetStores",
            new
            {
              fields = storesResourceParameters.Fields,
              orderBy = storesResourceParameters.OrderBy,
              searchQuery = storesResourceParameters.SearchQuery,
              pageNumber = storesResourceParameters.PageIndex,
              pageSize = storesResourceParameters.PageSize
            });
      }
    }

    #endregion
  }
}
