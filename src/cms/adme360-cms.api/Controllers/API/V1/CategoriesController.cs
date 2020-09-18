using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using adme360.cms.api.Controllers.API.Base;
using adme360.cms.api.Validators;
using adme360.cms.contracts.Categories;
using adme360.cms.contracts.Users;
using adme360.cms.contracts.V1;
using adme360.cms.model.Categories;
using adme360.common.dtos.Links;
using adme360.common.dtos.Vms.Categories;
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
  [Authorize]
  public class CategoriesController : BaseController
  {
    private readonly IUrlHelper _urlHelper;
    private readonly ITypeHelperService _typeHelperService;
    private readonly IPropertyMappingService _propertyMappingService;

    private readonly IInquiryAllCategoriesProcessor _inquiryAllCategoriesProcessor;
    private readonly IInquiryCategoryProcessor _inquiryCategoryProcessor;
    private readonly ICreateCategoryProcessor _createCategoryProcessor;
    private readonly IUpdateCategoryProcessor _updateCategoryProcessor;
    private readonly IDeleteCategoryProcessor _deleteCategoryProcessor;

    private readonly IInquiryUserProcessor _inquiryUserProcessor;


    public CategoriesController(IUrlHelper urlHelper,
      ITypeHelperService typeHelperService,
      IPropertyMappingService propertyMappingService,
      ICategoriesControllerDependencyBlock blockCategory,
      IUsersControllerDependencyBlock blockUser)
    {
      _urlHelper = urlHelper;
      _typeHelperService = typeHelperService;
      _propertyMappingService = propertyMappingService;

      _inquiryAllCategoriesProcessor = blockCategory.InquiryAllCategoriesProcessor;
      _inquiryCategoryProcessor = blockCategory.InquiryCategoryProcessor;
      _createCategoryProcessor = blockCategory.CreateCategoryProcessor;
      _updateCategoryProcessor = blockCategory.UpdateCategoryProcessor;
      _deleteCategoryProcessor = blockCategory.DeleteCategoryProcessor;

      _inquiryUserProcessor = blockUser.InquiryUserProcessor;
    }


    /// <summary>
    /// POST : Create a New Category.
    /// </summary>
    /// <param name="categoryForCreationUiModel">CategoryForCreationUiModel the Request Model for Creation</param>
    /// <remarks> return a ResponseEntity with status 201 (Created) if the new Category is created, 400 (Bad Request), 500 (Server Error) </remarks>
    /// <response code="201">Created (if the Category is created)</response>
    /// <response code="400">Bad Request</response>
    /// <response code="500">Internal Server Error</response>
    [HttpPost(Name = "PostCategoryRoute")]
    [ValidateModel]
    public async Task<IActionResult> PostCategoryRouteAsync(
      [FromBody] CategoryForCreationUiModel categoryForCreationUiModel)
    {
      var userAudit = await _inquiryUserProcessor.GetUserByLoginAsync(GetEmailFromClaims());

      if (userAudit == null)
      {
        return BadRequest("AUDIT_USER_NOT_EXIST");
      }

      var newCreatedCategory =
        await _createCategoryProcessor.CreateCategoryAsync(userAudit.Id, categoryForCreationUiModel);

      switch (newCreatedCategory.Message)
      {
        case ("SUCCESS_CREATION"):
        {
          Log.Information(
            $"--Method:PostCategoryRouteAsync -- Message:CATEGORY_CREATION_SUCCESSFULLY -- " +
            $"Datetime:{DateTime.Now} -- CategoryInfo:{categoryForCreationUiModel.CategoryName}");
          return Created(nameof(PostCategoryRouteAsync), newCreatedCategory);
        }
        case ("ERROR_ALREADY_EXISTS"):
        {
          Log.Error(
            $"--Method:PostCategoryRouteAsync -- Message:ERROR_CATEGORY_ALREADY_EXISTS -- " +
            $"Datetime:{DateTime.Now} -- CategoryInfo:{categoryForCreationUiModel.CategoryName}");
          return BadRequest(new {errorMessage = "CATEGORY_ALREADY_EXISTS"});
        }
        case ("ERROR_CATEGORY_NOT_MADE_PERSISTENT"):
        {
          Log.Error(
            $"--Method:PostCategoryRouteAsync -- Message:ERROR_CATEGORY_NOT_MADE_PERSISTENT -- " +
            $"Datetime:{DateTime.Now} -- CategoryInfo:{categoryForCreationUiModel.CategoryName}");
          return BadRequest(new {errorMessage = "ERROR_CREATION_NEW_CATEGORY"});
        }
        case ("UNKNOWN_ERROR"):
        {
          Log.Error(
            $"--Method:PostCategoryRouteAsync -- Message:ERROR_CREATION_NEW_CATEGORY -- " +
            $"Datetime:{DateTime.Now} -- CategoryInfo:{categoryForCreationUiModel.CategoryName}");
          return BadRequest(new {errorMessage = "ERROR_CREATION_NEW_CATEGORY"});
        }
      }

      return NotFound();
    }

    /// <summary>
    /// Get : Retrieve Stored providing Category Id
    /// </summary>
    /// <param name="id">Category Id the Request Index for Retrieval</param>
    /// <param name="fields">Fiends to be filtered with for the returned Category</param>
    /// <remarks>Retrieve Category Role providing Id and [Optional] fields</remarks>
    /// <response code="200">Resource retrieved correctly</response>
    /// <response code="404">Resource Not Found</response>
    /// <response code="500">Internal Server Error.</response>
    [HttpGet("{id}", Name = "GetCategory")]
    public async Task<IActionResult> GetCategoryAsync(Guid id, [FromQuery] string fields)
    {
      if (!_typeHelperService.TypeHasProperties<CategoryUiModel>
        (fields))
      {
        return BadRequest();
      }

      var categoryFromRepo = await _inquiryCategoryProcessor.GetCategoryByIdAsync(id);

      if (categoryFromRepo == null)
      {
        return NotFound();
      }

      var category = Mapper.Map<CategoryUiModel>(categoryFromRepo);

      var links = CreateLinksForCategory(id, fields);

      var linkedResourceToReturn = category.ShapeData(fields)
        as IDictionary<string, object>;

      linkedResourceToReturn.Add("links", links);

      return Ok(linkedResourceToReturn);
    }

    /// <summary>
    /// PUT : Update an Existing Category.
    /// </summary>
    /// <param name="id">Category Id for Modification</param>
    /// <param name="categoryForModificationUiModel">CategoryForModificationUiModel the Request Model for Modification</param>
    /// <remarks> return a ResponseEntity with status 201 (Created) if the new Container is created, 400 (Bad Request), 500 (Server Error) </remarks>
    /// <response code="200">Ok (if the Category is updated)</response>
    /// <response code="400">Bad Request</response>
    /// <response code="500">Internal Server Error</response>
    [HttpPut("{id}", Name = "PutCategoryRoute")]
    [ValidateModel]
    public async Task<IActionResult> UpdateCategoryAsync(Guid id,
      [FromBody] CategoryForModificationUiModel categoryForModificationUiModel)
    {
      return BadRequest(new {errorMessage = "UNKNOWN_ERROR_UPDATE_Category"});
    }

    /// <summary>
    /// Delete - Delete an existing Category 
    /// </summary>
    /// <param name="id">Category Id for Deletion</param>
    /// <remarks>Delete Existing Category </remarks>
    /// <response code="200">Resource retrieved correctly</response>
    /// <response code="400">Resource Not Found</response>
    /// <response code="500">Internal Server Error.</response>
    [HttpDelete("{id}", Name = "DeleteCategoryRoot")]
    public async Task<IActionResult> DeleteCategoryAsync(Guid id)
    {
      var userAudit = await _inquiryUserProcessor.GetUserByLoginAsync(GetEmailFromClaims());

      if (userAudit == null)
        return BadRequest();

      var categoryToBeSoftDeleted = await _deleteCategoryProcessor.SoftDeleteCategoryAsync(userAudit.Id, id);

      return Ok(categoryToBeSoftDeleted);
    }

    /// <summary>
    /// Delete - Delete an existing Category 
    /// </summary>
    /// <param name="id">Category Id for Deletion</param>
    /// <remarks>Delete Existing Category </remarks>
    /// <response code="200">Resource retrieved correctly</response>
    /// <response code="400">Resource Not Found</response>
    /// <response code="500">Internal Server Error.</response>
    [HttpDelete("hard/{id}", Name = "DeleteHardCategoryRoot")]
    [Authorize(AuthenticationSchemes = "Bearer", Roles = "SU")]
    public async Task<IActionResult> DeleteHardCategoryAsync(Guid id)
    {
      var userAudit = await _inquiryUserProcessor.GetUserByLoginAsync(GetEmailFromClaims());

      if (userAudit == null)
        return BadRequest();

      var categoryToBeDeleted = await _deleteCategoryProcessor.HardDeleteCategoryAsync(userAudit.Id, id);

      return Ok(categoryToBeDeleted.DeletionStatus);
    }


    /// <summary>
    /// Get : Retrieve All/or Partial Paged Stored Categories 
    /// </summary>
    /// <remarks>Retrieve paged Categories providing Paging Query</remarks>
    /// <response code="200">Resource retrieved correctly.</response>
    /// <response code="500">Internal Server Error.</response>
    [HttpGet(Name = "GetCategories")]
    public async Task<IActionResult> GetCategoriesAsync([FromQuery]CategoriesResourceParameters categoriesResourceParameters,
      [FromHeader(Name = "Accept")] string mediaType)
    {
      if (!_propertyMappingService.ValidMappingExistsFor<CategoryUiModel, Category>
        (categoriesResourceParameters.OrderBy))
      {
        return BadRequest();
      }

      if (!_typeHelperService.TypeHasProperties<CategoryUiModel>
        (categoriesResourceParameters.Fields))
      {
        return BadRequest();
      }

      var categoriesQueryable =
        await _inquiryAllCategoriesProcessor.GetCategoriesAsync(categoriesResourceParameters);

      var categories = Mapper.Map<IEnumerable<CategoryUiModel>>(categoriesQueryable);

      if (mediaType.Contains("application/vnd.marvin.hateoas+json"))
      {
        var paginationMetadata = new
        {
          totalCount = categoriesQueryable.TotalCount,
          pageSize = categoriesQueryable.PageSize,
          currentPage = categoriesQueryable.CurrentPage,
          totalPages = categoriesQueryable.TotalPages,
        };

        Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(paginationMetadata));

        var links = CreateLinksForCategories(categoriesResourceParameters,
          categoriesQueryable.HasNext, categoriesQueryable.HasPrevious);

        var shapedCategories = categories.ShapeData(categoriesResourceParameters.Fields);

        var shapedCategoriesWithLinks = shapedCategories.Select(category =>
        {
          var categoryAsDictionary = category as IDictionary<string, object>;
          var categoryLinks =
            CreateLinksForCategory((Guid) categoryAsDictionary["Id"], categoriesResourceParameters.Fields);

          categoryAsDictionary.Add("links", categoryLinks);

          return categoryAsDictionary;
        });

        var linkedCollectionResource = new
        {
          value = shapedCategoriesWithLinks,
          links = links
        };

        return Ok(linkedCollectionResource);
      }
      else
      {
        var previousPageLink = categoriesQueryable.HasPrevious ? CreateCategoriesResourceUri(categoriesResourceParameters,
            ResourceUriType.PreviousPage)
          : null;

        var nextPageLink = categoriesQueryable.HasNext
          ? CreateCategoriesResourceUri(categoriesResourceParameters, ResourceUriType.NextPage)
          : null;

        var paginationMetadata = new
        {
          previousPageLink = previousPageLink,
          nextPageLink = nextPageLink,
          totalCount = categoriesQueryable.TotalCount,
          pageSize = categoriesQueryable.PageSize,
          currentPage = categoriesQueryable.CurrentPage,
          totalPages = categoriesQueryable.TotalPages
        };

        Response.Headers.Add("X-Pagination",
          JsonConvert.SerializeObject(paginationMetadata));

        return Ok(categories.ShapeData(categoriesResourceParameters.Fields));
      }
    }

    #region Link Builder

    private IEnumerable<LinkDto> CreateLinksForCategory(Guid id, string fields)
    {
      var links = new List<LinkDto>();

      if (String.IsNullOrWhiteSpace(fields))
      {
        links.Add(
          new LinkDto(_urlHelper.Link("GetCategory", new {id = id}),
            "self",
            "GET"));
      }
      else
      {
        links.Add(
          new LinkDto(_urlHelper.Link("GetCategory", new {id = id, fields = fields}),
            "self",
            "GET"));
      }

      return links;
    }


    private IEnumerable<LinkDto> CreateLinksForCategories(
      CategoriesResourceParameters categoriesResourceParameters,
      bool hasNext, bool hasPrevious)
    {
      var links = new List<LinkDto>
      {
        new LinkDto(CreateCategoriesResourceUri(categoriesResourceParameters,
            ResourceUriType.Current)
          , "self", "GET")
      };

      if (hasNext)
      {
        links.Add(
          new LinkDto(CreateCategoriesResourceUri(categoriesResourceParameters,
              ResourceUriType.NextPage),
            "nextPage", "GET"));
      }

      if (hasPrevious)
      {
        links.Add(
          new LinkDto(CreateCategoriesResourceUri(categoriesResourceParameters,
              ResourceUriType.PreviousPage),
            "previousPage", "GET"));
      }

      return links;
    }

    private string CreateCategoriesResourceUri(CategoriesResourceParameters categoriesResourceParameters,
      ResourceUriType type)
    {
      switch (type)
      {
        case ResourceUriType.PreviousPage:
          return _urlHelper.Link("GetCategories",
            new
            {
              fields = categoriesResourceParameters.Fields,
              orderBy = categoriesResourceParameters.OrderBy,
              searchQuery = categoriesResourceParameters.SearchQuery,
              pageNumber = categoriesResourceParameters.PageIndex - 1,
              pageSize = categoriesResourceParameters.PageSize
            });
        case ResourceUriType.NextPage:
          return _urlHelper.Link("GetCategories",
            new
            {
              fields = categoriesResourceParameters.Fields,
              orderBy = categoriesResourceParameters.OrderBy,
              searchQuery = categoriesResourceParameters.SearchQuery,
              pageNumber = categoriesResourceParameters.PageIndex + 1,
              pageSize = categoriesResourceParameters.PageSize
            });
        case ResourceUriType.Current:
        default:
          return _urlHelper.Link("GetCategories",
            new
            {
              fields = categoriesResourceParameters.Fields,
              orderBy = categoriesResourceParameters.OrderBy,
              searchQuery = categoriesResourceParameters.SearchQuery,
              pageNumber = categoriesResourceParameters.PageIndex,
              pageSize = categoriesResourceParameters.PageSize
            });
      }
    }

    #endregion
  }
}
