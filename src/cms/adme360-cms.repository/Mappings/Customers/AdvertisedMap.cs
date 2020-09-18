using adme360.cms.model.Customers;
using FluentNHibernate.Mapping;

namespace adme360.cms.repository.Mappings.Customers
{
  public class AdvertisedMap : SubclassMap<Advertised>
  {
    public AdvertisedMap()
    {
      Table(@"advertised");
      KeyColumn("id");
    }
  }
}