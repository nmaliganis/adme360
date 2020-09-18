using adme360.cms.model.Customers;
using adme360.cms.model.Users;
using FluentNHibernate.Mapping;

namespace adme360.cms.repository.Mappings.Users
{
    public class UserMap : ClassMap<User>
    {
      public UserMap()
      {
        Table(@"users");

        Id(x => x.Id)
          .Column("id")
          .CustomType("Guid")
          .Access.Property()
          .CustomSqlType("uuid")
          .Not.Nullable()
          .Precision(11)
          .GeneratedBy
          .GuidComb()
          ;

        Map(x => x.Login)
          .Column("login")
          .CustomType("String")
          .Index("users_login_index")
          .Unique()
          .Access.Property()
          .Generated.Never()
          .CustomSqlType("varchar(512)")
          .Not.Nullable()
          .Length(512)
          ;

        Map(x => x.PasswordHash)
          .Column("password_hash")
          .Index("users_password_hash_index")
          .CustomType("String")
          .Access.Property()
          .Generated.Never()
          .CustomSqlType("varchar(512)")
          .Not.Nullable()
          .Length(512)
          ;

        Map(x => x.IsActivated)
          .Column("is_activated")
          .CustomType("Boolean")
          .Access.Property()
          .Generated.Never()
          .Default("false")
          .CustomSqlType("boolean")
          .Not.Nullable()
          ;

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

        Map(x => x.ResetKey)
          .Column("reset_key")
          .CustomType("Guid")
          .Unique()
          .Access.Property()
          .Generated.Never()
          .CustomSqlType("UUID")
          .Not.Nullable()
          ;

        Map(x => x.ActivationKey)
          .Column("activation_key")
          .CustomType("Guid")
          .Unique()
          .Access.Property()
          .Generated.Never()
          .CustomSqlType("UUID")
          .Not.Nullable()
          ;

        Map(x => x.ResetDate)
          .Column("reset_date")
          .CustomType("DateTime")
          .Access.Property()
          .Generated.Never()
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

        HasOne(x => x.Customer)
          .Class<Customer>()
          .Access.Property()
          .Cascade.SaveUpdate()
          .LazyLoad()
          .PropertyRef(p => p.User)
          ;

        HasMany<UserRole>(x => x.UsersRoles)
          .Access.Property()
          .AsSet()
          .Cascade.All()
          .LazyLoad()
          .Inverse()
          .Generic()
          .KeyColumns.Add("user_id", mapping => mapping.Name("user_id")
            .SqlType("uuid")
            .Not.Nullable());
      }
    }
}
