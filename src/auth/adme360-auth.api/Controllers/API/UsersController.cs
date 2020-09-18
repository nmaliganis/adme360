using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using adme360.auth.api.Controllers.API.Base;
using adme360.auth.api.Helpers.Models;
using adme360.auth.api.Helpers.Services.Users.Contracts;
using adme360.auth.api.Helpers.Services.Users.Contracts.V1;
using adme360.common.dtos.Links;
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

namespace adme360.auth.api.Controllers.API
{
    [Produces("application/json")]
    [ApiVersion("1.0")]
    [ResponseCache(Duration = 0, NoStore = true, VaryByHeader = "*")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [Authorize(Roles = "SU, ADMIN")]
    public class UsersController : BaseController
    {
        private readonly IUrlHelper _urlHelper;
        private readonly ITypeHelperService _typeHelperService;
        private readonly IPropertyMappingService _propertyMappingService;

        private readonly IInquiryAllUsersProcessor _inquiryAllUsersProcessor;

        public UsersController(IUrlHelper urlHelper, ITypeHelperService typeHelperService, IPropertyMappingService propertyMappingService, IUsersControllerDependencyBlock blockUser)
        {
            _urlHelper = urlHelper;
            _typeHelperService = typeHelperService;
            _propertyMappingService = propertyMappingService;

            _inquiryAllUsersProcessor = blockUser.InquiryAllUsersProcessor;
        }

        /// <summary>
        /// Get - Retrieve All/or Partial Paged Stored Persons
        /// </summary>
        /// <remarks>Retrieve paged Persons providing Paging Query</remarks>
        /// <param name="usersResourceParameters"></param>
        /// <param name="mediaType">Header - use: "application/vnd.marvin.hateoas+json" for custom links response </param>
        /// <response code="200">Resource retrieved correctly.</response>
        /// <response code="500">Internal Server Error.</response>
        [HttpGet(Name = "GetUsers")]
        public async Task<IActionResult> GetUsersAsync([FromQuery] UsersResourceParameters usersResourceParameters,
            [FromHeader(Name = "Accept")] string mediaType)
        {
            if (!_propertyMappingService.ValidMappingExistsFor<UserUiModel, User>
                (usersResourceParameters.OrderBy))
            {
                return BadRequest();
            }

            if (!_typeHelperService.TypeHasProperties<UserUiModel>
                (usersResourceParameters.Fields))
            {
                return BadRequest();
            }

            var usersQueryable = await _inquiryAllUsersProcessor.GetUsersAsync(usersResourceParameters);

            var users = Mapper.Map<IEnumerable<UserForAllRetrievalUiModel>>(usersQueryable);

            if (mediaType.Contains("application/vnd.marvin.hateoas+json"))
            {
                var paginationMetadata = new
                {
                    totalCount = usersQueryable.TotalCount,
                    pageSize = usersQueryable.PageSize,
                    currentPage = usersQueryable.CurrentPage,
                    totalPages = usersQueryable.TotalPages,
                };

                Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(paginationMetadata));

                var links = CreateLinksForUsers(usersResourceParameters,
                    usersQueryable.HasNext, usersQueryable.HasPrevious);

                var shapedPersons = users.ShapeData(usersResourceParameters.Fields);

                var shapedPersonsWithLinks = shapedPersons.Select(person =>
                {
                    var personAsDictionary = person as IDictionary<string, object>;
                    var personLinks =
                        CreateLinksForUser((int) personAsDictionary["Id"], usersResourceParameters.Fields);

                    personAsDictionary.Add("links", personLinks);

                    return personAsDictionary;
                });

                var linkedCollectionResource = new
                {
                    value = shapedPersonsWithLinks,
                    links = links
                };

                return Ok(linkedCollectionResource);
            }
            else
            {
                var previousPageLink = usersQueryable.HasPrevious
                    ? CreateUsersResourceUri(usersResourceParameters,
                        ResourceUriType.PreviousPage)
                    : null;

                var nextPageLink = usersQueryable.HasNext
                    ? CreateUsersResourceUri(usersResourceParameters,
                        ResourceUriType.NextPage)
                    : null;

                var paginationMetadata = new
                {
                    previousPageLink = previousPageLink,
                    nextPageLink = nextPageLink,
                    totalCount = usersQueryable.TotalCount,
                    pageSize = usersQueryable.PageSize,
                    currentPage = usersQueryable.CurrentPage,
                    totalPages = usersQueryable.TotalPages
                };

                Response.Headers.Add("X-Pagination",
                    JsonConvert.SerializeObject(paginationMetadata));

                return Ok(users.ShapeData(usersResourceParameters.Fields));
            }
        }

        #region Link Builder

        private IEnumerable<LinkDto> CreateLinksForUser(int id, string fields)
        {
            var links = new List<LinkDto>();

            if (String.IsNullOrWhiteSpace(fields))
            {
                links.Add(
                    new LinkDto(_urlHelper.Link("GetUser", new {id = id}),
                        "self",
                        "GET"));
            }
            else
            {
                links.Add(
                    new LinkDto(_urlHelper.Link("GetUser", new {id = id, fields = fields}),
                        "self",
                        "GET"));
            }

            return links;
        }


        private IEnumerable<LinkDto> CreateLinksForUsers(UsersResourceParameters usersResourceParameters,
            bool hasNext, bool hasPrevious)
        {
            var links = new List<LinkDto>
            {
                new LinkDto(CreateUsersResourceUri(usersResourceParameters,
                        ResourceUriType.Current)
                    , "self", "GET")
            };

            if (hasNext)
            {
                links.Add(
                    new LinkDto(CreateUsersResourceUri(usersResourceParameters,
                            ResourceUriType.NextPage),
                        "nextPage", "GET"));
            }

            if (hasPrevious)
            {
                links.Add(
                    new LinkDto(CreateUsersResourceUri(usersResourceParameters,
                            ResourceUriType.PreviousPage),
                        "previousPage", "GET"));
            }

            return links;
        }

        private string CreateUsersResourceUri(UsersResourceParameters usersResourceParameters,
            ResourceUriType type)
        {
            switch (type)
            {
                case ResourceUriType.PreviousPage:
                    return _urlHelper.Link("GetUsers",
                        new
                        {
                            fields = usersResourceParameters.Fields,
                            orderBy = usersResourceParameters.OrderBy,
                            searchQuery = usersResourceParameters.SearchQuery,
                            pageNumber = usersResourceParameters.PageIndex - 1,
                            pageSize = usersResourceParameters.PageSize
                        });
                case ResourceUriType.NextPage:
                    return _urlHelper.Link("GetUsers",
                        new
                        {
                            fields = usersResourceParameters.Fields,
                            orderBy = usersResourceParameters.OrderBy,
                            searchQuery = usersResourceParameters.SearchQuery,
                            pageNumber = usersResourceParameters.PageIndex + 1,
                            pageSize = usersResourceParameters.PageSize
                        });
                case ResourceUriType.Current:
                default:
                    return _urlHelper.Link("GetUsers",
                        new
                        {
                            fields = usersResourceParameters.Fields,
                            orderBy = usersResourceParameters.OrderBy,
                            searchQuery = usersResourceParameters.SearchQuery,
                            pageNumber = usersResourceParameters.PageIndex,
                            pageSize = usersResourceParameters.PageSize
                        });
            }
        }

        #endregion
    }
}
