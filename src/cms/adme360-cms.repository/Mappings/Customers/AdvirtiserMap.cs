using adme360.cms.model.Customers;
using adme360.cms.model.Stores;
using FluentNHibernate.Mapping;

namespace adme360.cms.repository.Mappings.Customers
{
  public class AdvertiserMap : SubclassMap<Advertiser>
  {
    public AdvertiserMap()
    {
      Table(@"advertisers");
      KeyColumn("id");

      HasMany<Store>(x => x.Stores)
        .Access.Property()
        .AsSet()
        .Cascade.None()
        .LazyLoad()
        .Inverse()
        .Generic()
        .KeyColumns.Add("store_id", mapping => mapping.Name("advertiser_id")
          .SqlType("uuid")
          .Not.Nullable());
    }
  }
}
