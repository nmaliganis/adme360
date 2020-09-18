using System;
using System.Collections.Generic;
using adme360.cms.model.Categories;
using adme360.cms.model.Customers;
using adme360.common.dtos.Vms.Categories;
using adme360.common.dtos.Vms.Customers;
using adme360.common.dtos.Vms.Devices;
using adme360.common.infrastructure.PropertyMappings;

namespace adme360.cms.api.Helpers
{
    public class PropertyMappingService : BasePropertyMapping
    {
        private readonly Dictionary<string, PropertyMappingValue> _devicePropertyMapping =
            new Dictionary<string, PropertyMappingValue>(StringComparer.OrdinalIgnoreCase)
            {
                {"id", new PropertyMappingValue(new List<string>() {"id"})},
                {"SerialNumber", new PropertyMappingValue(new List<string>() {"SerialNumber"})},
                {"CreatedDate", new PropertyMappingValue(new List<string>() {"CreatedDate"})},
                {"ActivationDate", new PropertyMappingValue(new List<string>() {"ActivationDate"})},
                {"ProvisioningDate", new PropertyMappingValue(new List<string>() {"ProvisioningDate"})},
                {"IsEnabled", new PropertyMappingValue(new List<string>() {"IsEnabled"})},
                {"IsActivated", new PropertyMappingValue(new List<string>() {"IsActivated"})},
            };

        private readonly Dictionary<string, PropertyMappingValue> _customerPropertyMapping =
            new Dictionary<string, PropertyMappingValue>(StringComparer.OrdinalIgnoreCase)
            {
                {"id", new PropertyMappingValue(new List<string>() {"id"})},
                {"Firstname", new PropertyMappingValue(new List<string>() {"Firstname"})},
                {"Lastname", new PropertyMappingValue(new List<string>() {"Lastname"})},
                {"Email", new PropertyMappingValue(new List<string>() {"Email"})},
                {"IsActive", new PropertyMappingValue(new List<string>() {"IsActive"})},
            };

        private readonly Dictionary<string, PropertyMappingValue> _categoryPropertyMapping =
          new Dictionary<string, PropertyMappingValue>(StringComparer.OrdinalIgnoreCase)
          {
            {"id", new PropertyMappingValue(new List<string>() {"id"})},
            {"Name", new PropertyMappingValue(new List<string>() {"Name"})},
            {"IsActive", new PropertyMappingValue(new List<string>() {"IsActive"})},
          };

        private static readonly IList<IPropertyMapping> PropertyMappings = new List<IPropertyMapping>();

        public PropertyMappingService() : base(PropertyMappings)
        {
            PropertyMappings.Add(new PropertyMapping<CategoryUiModel, Category>(_categoryPropertyMapping));
            PropertyMappings.Add(new PropertyMapping<CustomerUiModel, Customer>(_customerPropertyMapping));
        }
    }
}
