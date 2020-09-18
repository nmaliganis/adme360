using adme360.auth.api.Helpers.Models;
using FluentNHibernate.Mapping;

namespace adme360.auth.api.Helpers.Mappings
{
  public class UserTokenMap : ClassMap<UserToken>
  {
    public UserTokenMap()
    {
      Table(@"refreshtokens");
      LazyLoad();
      Id(x => x.Id)
        .Column("id")
        .CustomType("Guid")
        .Access.Property()
        .CustomSqlType("uuid")
        .Not.Nullable()
        .GeneratedBy
        .GuidComb();

      Map(x => x.RefreshToken)
        .Column("token")
        .CustomType("Guid")
        .Access.Property()
        .Unique()
        .Generated.Never()
        .CustomSqlType("UUID")
        .Not.Nullable()
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

      Map(x => x.Expired)
        .Column("expired")
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

      References(x => x.User)
        .Class<User>()
        .Access.Property()
        .Cascade.SaveUpdate()
        .LazyLoad()
        .Columns("user_id");
    }
  }
}


