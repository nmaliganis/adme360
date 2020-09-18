using System.Linq;
using System.Threading.Tasks;
using adme360.auth.api.Helpers.Models;
using adme360.auth.api.Helpers.Repositories.Users;
using adme360.auth.api.Helpers.Services.Users.Contracts;
using adme360.common.dtos.Vms.Users;
using adme360.common.infrastructure.Extensions;
using adme360.common.infrastructure.Helpers.ResourceParameters;
using adme360.common.infrastructure.Paging;
using adme360.common.infrastructure.PropertyMappings;
using adme360.common.infrastructure.TypeMappings;

namespace adme360.auth.api.Helpers.Services.Users.Impls
{
    public class InquiryAllUsersProcessor : IInquiryAllUsersProcessor
    {
        private readonly IAutoMapper _autoMapper;
        private readonly IUserRepository _personRepository;
        private readonly IPropertyMappingService _propertyMappingService;

        public InquiryAllUsersProcessor(IAutoMapper autoMapper,
            IUserRepository personRepository, IPropertyMappingService propertyMappingService)
        {
            _autoMapper = autoMapper;
            _personRepository = personRepository;
            _propertyMappingService = propertyMappingService;
        }

        public Task<PagedList<User>> GetUsersAsync(UsersResourceParameters personsResourceParameters)
        {
            var collectionBeforePaging =
                QueryableExtensions.ApplySort(_personRepository
                        .GetUsersPagedAsync(personsResourceParameters.PageIndex,
                            personsResourceParameters.PageSize),
                    personsResourceParameters.OrderBy,
                    _propertyMappingService.GetPropertyMapping<UserUiModel, User>());


            if (!string.IsNullOrEmpty(personsResourceParameters.SearchQuery))
            {
                // trim & ignore casing
                var searchQueryForWhereClause = personsResourceParameters.SearchQuery
                    .Trim().ToLowerInvariant();

                collectionBeforePaging.QueriedItems = collectionBeforePaging.QueriedItems
                    .Where(a => a.Login.ToLowerInvariant().Contains(searchQueryForWhereClause));
            }

            return Task.Run(() => PagedList<User>.Create(collectionBeforePaging,
                personsResourceParameters.PageIndex,
                personsResourceParameters.PageSize));
        }
    }
}