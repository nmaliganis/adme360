using adme360.auth.api.Helpers.Models;
using FluentNHibernate.Mapping;

namespace adme360.auth.api.Helpers.Mappings
{
    public class UsersRoleMap : ClassMap<UserRole>
    {
        public UsersRoleMap()
        {
            Table(@"usersroles");

            Id(x => x.Id)
                .Column("id")
                .CustomType("Guid")
                .Access.Property()
                .CustomSqlType("uuid")
                .Not.Nullable()
                .GeneratedBy
                .GuidComb()
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


            Map(x => x.IsActive)
                .Column("active")
                .CustomType("Boolean")
                .Access.Property()
                .Generated.Never()
                .Default("true")
                .CustomSqlType("boolean")
                .Not.Nullable()
                ;

            References(x => x.Role)
                .Class<Role>()
                .Access.Property()
                .Cascade.SaveUpdate()
                .LazyLoad()
                .Columns("role_id");

            References(x => x.User)
                .Class<User>()
                .Access.Property()
                .Cascade.SaveUpdate()
                .LazyLoad()
                .Columns("user_id");
        }
    }
}
