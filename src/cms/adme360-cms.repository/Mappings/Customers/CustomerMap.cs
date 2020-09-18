using adme360.cms.model.Categories;
using adme360.cms.model.Customers;
using adme360.cms.model.Users;
using FluentNHibernate.Mapping;

namespace adme360.cms.repository.Mappings.Customers
{
  public class CustomerMap : ClassMap<Customer>
  {
    public CustomerMap()
    {
      Table(@"customers");

      Id(x => x.Id)
        .Column("id")
        .CustomType("Guid")
        .Access.Property()
        .CustomSqlType("uuid")
        .Not.Nullable()
        .GeneratedBy
        .GuidComb()
        ;

      Map(x => x.Firstname)
        .Column("firstname")
        .CustomType("string")
        .Access.Property()
        .Generated.Never()
        .CustomSqlType("varchar(128)")
        .Not.Nullable()
        .Length(128);

      Map(x => x.Lastname)
        .Column("lastname")
        .CustomType("string")
        .Access.Property()
        .Generated.Never()
        .CustomSqlType("varchar(128)")
        .Not.Nullable()
        .Length(128);

      Map(x => x.Email)
        .Column("email")
        .CustomType("string")
        .Unique()
        .Access.Property()
        .Generated.Never()
        .CustomSqlType("varchar(128)")
        .Not.Nullable()
        .Length(128);

      Map(x => x.Brand)
        .Column("brandname")
        .CustomType("string")
        .Unique()
        .Access.Property()
        .Generated.Never()
        .CustomSqlType("varchar(128)")
        .Not.Nullable()
        .Length(128);

      Map(x => x.Phone)
        .Column("phone")
        .CustomType("string")
        .Unique()
        .Access.Property()
        .Generated.Never()
        .CustomSqlType("varchar(20)")
        .Not.Nullable()
        .Length(20);

      Map(x => x.Vat)
        .Column("vat")
        .CustomType("string")
        .Unique()
        .Access.Property()
        .Generated.Never()
        .CustomSqlType("varchar(128)")
        .Not.Nullable()
        .Length(128);

      Map(x => x.Website)
        .Column("website")
        .CustomType("string")
        .Unique()
        .Access.Property()
        .Generated.Never()
        .CustomSqlType("varchar(128)")
        .Not.Nullable()
        .Length(128);

      Map(x => x.Notes)
        .Column("notes")
        .CustomType("string")
        .Access.Property()
        .Generated.Never()
        .CustomSqlType("varchar")
        .Nullable()
        ;

      Map(x => x.Activated)
        .Column("activated")
        .CustomType("Boolean")
        .Access.Property()
        .Generated.Never()
        .Default("false")
        .CustomSqlType("boolean")
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

      Component(x => x.Address,
        customerAddress =>
        {
          customerAddress.Access.Property();
          customerAddress.Map(x => x.StreetOne)
            .Column("address_street_1")
            .CustomType("string")
            .Access.Property()
            .Generated.Never()
            .CustomSqlType("varchar")
            .Not.Nullable()
            .Length(128)
            ;

          customerAddress.Map(x => x.StreetTwo)
            .Column("address_street_2")
            .CustomType("string")
            .Access.Property()
            .Generated.Never()
            .CustomSqlType("varchar")
            .Nullable()
            .Length(128)
            ;

          customerAddress.Map(x => x.PostCode)
            .Column("address_postcode")
            .CustomType("string")
            .Access.Property()
            .Generated.Never()
            .CustomSqlType("varchar")
            .Not.Nullable()
            .Length(8)
            ;

          customerAddress.Map(x => x.City)
            .Column("address_city")
            .CustomType("string")
            .Access.Property()
            .Generated.Never()
            .CustomSqlType("varchar")
            .Not.Nullable()
            .Length(64)
            ;

          customerAddress.Map(x => x.Region)
            .Column("address_region")
            .CustomType("string")
            .Access.Property()
            .Generated.Never()
            .CustomSqlType("varchar")
            .Not.Nullable()
            .Length(64)
            ;
        });


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

      References(x => x.Category)
        .Class<Category>()
        .Access.Property()
        .Cascade.SaveUpdate()
        .LazyLoad()
        .Columns("category_id");

      References(x => x.User)
        .Class<User>()
        .Access.Property()
        .Cascade.SaveUpdate()
        .Fetch.Join()
        //.LazyLoad()
        .Columns("user_id");
    }
  }
}
