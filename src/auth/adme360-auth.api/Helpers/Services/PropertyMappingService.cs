using System;
using System.Collections.Generic;
using adme360.auth.api.Helpers.Models;
using adme360.common.dtos.Vms.Roles;
using adme360.common.dtos.Vms.Users;
using adme360.common.infrastructure.PropertyMappings;

namespace adme360.auth.api.Helpers.Services
{
    public class PropertyMappingService : BasePropertyMapping
    {
        private readonly Dictionary<string, PropertyMappingValue> _rolePropertyMapping =
            new Dictionary<string, PropertyMappingValue>(StringComparer.OrdinalIgnoreCase)
            {
                { "Id", new PropertyMappingValue(new List<string>() { "Id" } ) },
                { "Name", new PropertyMappingValue(new List<string>() { "Name"}) },
            };

        private readonly Dictionary<string, PropertyMappingValue> _userPropertyMapping =
            new Dictionary<string, PropertyMappingValue>(StringComparer.OrdinalIgnoreCase)
            {
                { "Id", new PropertyMappingValue(new List<string>() { "Id" } ) },
                { "Login", new PropertyMappingValue(new List<string>() { "Login"}) },
                { "IsActivated", new PropertyMappingValue(new List<string>() { "IsActivated"}) },
                { "CreatedBy", new PropertyMappingValue(new List<string>() { "CreatedBy"}) },
            };

        private static readonly IList<IPropertyMapping> PropertyMappings = new List<IPropertyMapping>();

        public PropertyMappingService() : base(PropertyMappings)
        {
            PropertyMappings.Add(new PropertyMapping<RoleUiModel, Role>(_rolePropertyMapping));
            PropertyMappings.Add(new PropertyMapping<UserUiModel, User>(_userPropertyMapping));
        }
    }
}
