using adme360.cms.model.Customers;
using adme360.cms.model.Devices;
using adme360.cms.model.Stores;
using FluentNHibernate.Mapping;
using NHibernate.Spatial.Type;

namespace adme360.cms.repository.Mappings.Stores
{
  public class StoreMap : ClassMap<Store>
  {
    public StoreMap()
    {
      Table(@"stores");

      Id(x => x.Id)
        .Column("id")
        .CustomType("Guid")
        .Access.Property()
        .CustomSqlType("uuid")
        .Not.Nullable()
        .GeneratedBy
        .GuidComb()
        ;

      Map(m => m.Point, "point")
        .CustomType<PostGisGeometryType>()
        .LazyLoad();

      Map(x => x.Name)
        .Column("name")
        .CustomType("String")
        .Unique()
        .Access.Property()
        .Generated.Never()
        .CustomSqlType("varchar(128)")
        .Not.Nullable()
        .Length(256);

      Map(x => x.CreatedBy)
        .Column("created_by")
        .CustomType("Guid")
        .Access.Property()
        .Generated.Never()
        .CustomSqlType("UUID")
        .Nullable()
        ;

      Map(x => x.ModifiedBy)
        .Column("modified_by")
        .CustomType("Guid")
        .Access.Property()
        .Generated.Never()
        .CustomSqlType("UUID")
        .Nullable()
        ;

      Map(x => x.CreatedDate)
        .Column("created_date")
        .CustomType("DateTime")
        .Access.Property()
        .Generated.Never()
        .Not.Nullable()
        ;

      Map(x => x.ModifiedDate)
        .Column("modified_date")
        .CustomType("DateTime")
        .Access.Property()
        .Generated.Never()
        .Not.Nullable()
        ;

      Component(x => x.Address,
        storeAddress =>
        {
          storeAddress.Access.Property();
          storeAddress.Map(x => x.StreetOne)
            .Column("address_street_1")
            .CustomType("string")
            .Access.Property()
            .Generated.Never()
            .CustomSqlType("varchar")
            .Not.Nullable()
            .Length(128)
            ;

          storeAddress.Map(x => x.StreetTwo)
            .Column("address_street_2")
            .CustomType("string")
            .Access.Property()
            .Generated.Never()
            .CustomSqlType("varchar")
            .Nullable()
            .Length(128)
            ;

          storeAddress.Map(x => x.PostCode)
            .Column("address_postcode")
            .CustomType("string")
            .Access.Property()
            .Generated.Never()
            .CustomSqlType("varchar")
            .Not.Nullable()
            .Length(8)
            ;

          storeAddress.Map(x => x.City)
            .Column("address_city")
            .CustomType("string")
            .Access.Property()
            .Generated.Never()
            .CustomSqlType("varchar")
            .Not.Nullable()
            .Length(64)
            ;

          storeAddress.Map(x => x.Region)
            .Column("address_region")
            .CustomType("string")
            .Access.Property()
            .Generated.Never()
            .CustomSqlType("varchar")
            .Not.Nullable()
            .Length(64)
            ;
        });

      Map(x => x.Status)
        .Column("status")
        .CustomType<StoreStatus>()
        .Access.Property()
        .Generated.Never()
        .Default(@"1")
        .CustomSqlType("integer")
        .Not.Nullable()
        ;

      Map(x => x.IsActive)
        .Column("active")
        .CustomType("Boolean")
        .Access.Property()
        .Generated.Never()
        .Default("true")
        .CustomSqlType("boolean")
        .Not.Nullable()
        ;

      References(x => x.Advertiser)
        .Class<Advertiser>()
        .Access.Property()
        .Cascade.SaveUpdate()
        .LazyLoad()
        .Columns("advertiser_id");

      HasMany<WorkingHour>(x => x.WorkingHours)
        .Access.Property()
        .AsSet()
        .Cascade.None()
        .LazyLoad()
        .Inverse()
        .Generic()
        .KeyColumns.Add("store_id", mapping => mapping.Name("store_id")
          .SqlType("uuid")
          .Not.Nullable());

      //HasMany<Registration>(x => x.Registrations)
      //  .Access.Property()
      //  .AsSet()
      //  .Cascade.None()
      //  .LazyLoad()
      //  .Inverse()
      //  .Generic()
      //  .KeyColumns.Add("store_id", mapping => mapping.Name("store_id")
      //    .SqlType("uuid")
      //    .Not.Nullable());
    }
  }
}
