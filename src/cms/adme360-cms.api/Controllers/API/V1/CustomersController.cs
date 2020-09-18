using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using adme360.cms.api.Controllers.API.Base;
using adme360.cms.api.Validators;
using adme360.cms.contracts.Customers;
using adme360.cms.contracts.Users;
using adme360.cms.contracts.V1;
using adme360.cms.model.Customers;
using adme360.common.dtos.Links;
using adme360.common.dtos.Vms.Customers;
using adme360.common.infrastructure.Extensions;
using adme360.common.infrastructure.Helpers;
using adme360.common.infrastructure.Helpers.ResourceParameters;
using adme360.common.infrastructure.PropertyMappings;
using adme360.common.infrastructure.PropertyMappings.TypeHelpers;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace adme360.cms.api.Controllers.API.V1
{
  [Produces("application/json")]
  [ApiVersion("1.0")]
  [ResponseCache(Duration = 0, NoStore = true, VaryByHeader = "*")]
  [Route("api/v{version:apiVersion}/[controller]")]
  [ApiController]
  [Authorize]
  public class CustomersController : BaseController
  {
    private readonly IUrlHelper _urlHelper;
    private readonly ITypeHelperService _typeHelperService;
    private readonly IPropertyMappingService _propertyMappingService;

    private readonly IInquiryAllCustomersProcessor _inquiryAllCustomersProcessor;
    private readonly IInquiryCustomerProcessor _inquiryCustomerProcessor;

    private readonly IInquiryUserProcessor _inquiryUserProcessor;


    public CustomersController(IUrlHelper urlHelper,
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

      _inquiryUserProcessor = blockUser.InquiryUserProcessor;
    }

    /// <summary>
    /// Get : Retrieve Stored providing Customer Id
    /// </summary>
    /// <param name="id">Customer Id the Request Index for Retrieval</param>
    /// <param name="fields">Fiends to be filtered with for the returned Customer</param>
    /// <remarks>Retrieve Customer Role providing Id and [Optional] fields</remarks>
    /// <response code="200">Resource retrieved correctly</response>
    /// <response code="404">Resource Not Found</response>
    /// <response code="500">Internal Server Error.</response>
    [HttpGet("{id}", Name = "GetCustomer")]
    public async Task<IActionResult> GetCustomerAsync(Guid id, [FromQuery] string fields)
    {
      if (!_typeHelperService.TypeHasProperties<CustomerUiModel>
        (fields))
      {
        return BadRequest();
      }

      var customerFromRepo = await _inquiryCustomerProcessor.GetCustomerByIdAsync(id);

      if (customerFromRepo == null)
      {
        return NotFound();
      }

      var customer = Mapper.Map<CustomerUiModel>(customerFromRepo);

      var links = CreateLinksForCustomer(id, fields);

      var linkedResourceToReturn = customer.ShapeData(fields)
        as IDictionary<string, object>;

      linkedResourceToReturn.Add("links", links);

      return Ok(linkedResourceToReturn);
    }

    /// <summary>
    /// Get : Retrieve All/or Partial Paged Stored Customers 
    /// </summary>
    /// <remarks>Retrieve paged Customers providing Paging Query</remarks>
    /// <response code="200">Resource retrieved correctly.</response>
    /// <response code="500">Internal Server Error.</response>
    [HttpGet(Name = "GetCustomers")]
    public async Task<IActionResult> GetCustomersAsync([FromQuery] CustomersResourceParameters customersResourceParameters, 
      [FromHeader(Name = "Accept")] string mediaType)
    {
      if (!_propertyMappingService.ValidMappingExistsFor<CustomerUiModel, Customer>
        (customersResourceParameters.OrderBy))
      {
        return BadRequest();
      }

      if (!_typeHelperService.TypeHasProperties<CustomerUiModel>
        (customersResourceParameters.Fields))
      {
        return BadRequest();
      }

      var customersQueryable =
        await _inquiryAllCustomersProcessor.GetCustomersAsync(customersResourceParameters);

      var customers = Mapper.Map<IEnumerable<CustomerUiModel>>(customersQueryable);

      if (mediaType.Contains("application/vnd.marvin.hateoas+json"))
      {
        var paginationMetadata = new
        {
          totalCount = customersQueryable.TotalCount,
          pageSize = customersQueryable.PageSize,
          currentPage = customersQueryable.CurrentPage,
          totalPages = customersQueryable.TotalPages,
        };

        Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(paginationMetadata));

        var links = CreateLinksForCustomers(customersResourceParameters,
          customersQueryable.HasNext, customersQueryable.HasPrevious);

        var shapedCustomers = customers.ShapeData(customersResourceParameters.Fields);

        var shapedCustomersWithLinks = shapedCustomers.Select(customer =>
        {
          var customerAsDictionary = customer as IDictionary<string, object>;
          var customerLinks =
            CreateLinksForCustomer((Guid)customerAsDictionary["Id"], customersResourceParameters.Fields);

          customerAsDictionary.Add("links", customerLinks);

          return customerAsDictionary;
        });

        var linkedCollectionResource = new
        {
          value = shapedCustomersWithLinks,
          links = links
        };

        return Ok(linkedCollectionResource);
      }
      else
      {
        var previousPageLink = customersQueryable.HasPrevious ? CreateCustomersResourceUri(customersResourceParameters,
            ResourceUriType.PreviousPage)
          : null;

        var nextPageLink = customersQueryable.HasNext
          ? CreateCustomersResourceUri(customersResourceParameters, ResourceUriType.NextPage)
          : null;

        var paginationMetadata = new
        {
          previousPageLink = previousPageLink,
          nextPageLink = nextPageLink,
          totalCount = customersQueryable.TotalCount,
          pageSize = customersQueryable.PageSize,
          currentPage = customersQueryable.CurrentPage,
          totalPages = customersQueryable.TotalPages
        };

        Response.Headers.Add("X-Pagination",
          JsonConvert.SerializeObject(paginationMetadata));

        return Ok(customers.ShapeData(customersResourceParameters.Fields));
      }
    }

    #region Link Builder

    private IEnumerable<LinkDto> CreateLinksForCustomer(Guid id, string fields)
    {
      var links = new List<LinkDto>();

      if (String.IsNullOrWhiteSpace(fields))
      {
        links.Add(
          new LinkDto(_urlHelper.Link("GetCustomer", new { id = id }),
            "self",
            "GET"));
      }
      else
      {
        links.Add(
          new LinkDto(_urlHelper.Link("GetCustomer", new { id = id, fields = fields }),
            "self",
            "GET"));
      }

      return links;
    }


    private IEnumerable<LinkDto> CreateLinksForCustomers(CustomersResourceParameters customersResourceParameters,
      bool hasNext, bool hasPrevious)
    {
      var links = new List<LinkDto>
      {
        new LinkDto(CreateCustomersResourceUri(customersResourceParameters,
            ResourceUriType.Current)
          , "self", "GET")
      };

      if (hasNext)
      {
        links.Add(
          new LinkDto(CreateCustomersResourceUri(customersResourceParameters,
              ResourceUriType.NextPage),
            "nextPage", "GET"));
      }

      if (hasPrevious)
      {
        links.Add(
          new LinkDto(CreateCustomersResourceUri(customersResourceParameters,
              ResourceUriType.PreviousPage),
            "previousPage", "GET"));
      }

      return links;
    }

    private string CreateCustomersResourceUri(CustomersResourceParameters customersResourceParameters, ResourceUriType type)
    {
      switch (type)
      {
        case ResourceUriType.PreviousPage:
          return _urlHelper.Link("GetCustomers",
            new
            {
              fields = customersResourceParameters.Fields,
              orderBy = customersResourceParameters.OrderBy,
              searchQuery = customersResourceParameters.SearchQuery,
              pageNumber = customersResourceParameters.PageIndex - 1,
              pageSize = customersResourceParameters.PageSize
            });
        case ResourceUriType.NextPage:
          return _urlHelper.Link("GetCustomers",
            new
            {
              fields = customersResourceParameters.Fields,
              orderBy = customersResourceParameters.OrderBy,
              searchQuery = customersResourceParameters.SearchQuery,
              pageNumber = customersResourceParameters.PageIndex + 1,
              pageSize = customersResourceParameters.PageSize
            });
        case ResourceUriType.Current:
        default:
          return _urlHelper.Link("GetCustomers",
            new
            {
              fields = customersResourceParameters.Fields,
              orderBy = customersResourceParameters.OrderBy,
              searchQuery = customersResourceParameters.SearchQuery,
              pageNumber = customersResourceParameters.PageIndex,
              pageSize = customersResourceParameters.PageSize
            });
      }
    }

    #endregion
  }
}
