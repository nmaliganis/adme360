using System;
using adme360.auth.api.Helpers.Mappings;
using adme360.auth.api.Helpers.Repositories;
using adme360.auth.api.Helpers.Repositories.Customers;
using adme360.auth.api.Helpers.Repositories.Roles;
using adme360.auth.api.Helpers.Repositories.Users;
using adme360.auth.api.Helpers.Services;
using adme360.auth.api.Helpers.Services.Persons;
using adme360.auth.api.Helpers.Services.Roles.Contracts;
using adme360.auth.api.Helpers.Services.Roles.Contracts.V1;
using adme360.auth.api.Helpers.Services.Roles.Impls;
using adme360.auth.api.Helpers.Services.Roles.Impls.V1;
using adme360.auth.api.Helpers.Services.Users.Contracts;
using adme360.auth.api.Helpers.Services.Users.Contracts.V1;
using adme360.auth.api.Helpers.Services.Users.Impls;
using adme360.auth.api.Helpers.Services.Users.Impls.V1;
using adme360.auth.api.Validators;
using adme360.common.dtos.Vms.Accounts;
using adme360.common.infrastructure.Exceptions.Repositories;
using adme360.common.infrastructure.PropertyMappings;
using adme360.common.infrastructure.PropertyMappings.TypeHelpers;
using adme360.common.infrastructure.TypeMappings;
using adme360.common.infrastructure.UnitOfWorks;
using AspNetCoreRateLimit;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.DependencyInjection;
using NHibernate;

namespace adme360.auth.api.Configurations
{ 
    public static class Config
    {
        public static void ConfigureRepositories(IServiceCollection services)
        {
          services.AddSingleton<IRateLimitCounterStore, MemoryCacheRateLimitCounterStore>();
          services.AddSingleton<IIpPolicyStore, MemoryCacheIpPolicyStore>();
          services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
          services.AddScoped<IUrlHelper>(implementationFactory =>
          {
            var actionContext = implementationFactory.GetService<IActionContextAccessor>()
              .ActionContext;
            return new UrlHelper(actionContext);
          });

          services.AddScoped<IUrlHelper>(x =>
          {
            var actionContext = x.GetRequiredService<IActionContextAccessor>().ActionContext;
            var factory = x.GetRequiredService<IUrlHelperFactory>();
            return factory.GetUrlHelper(actionContext);
          });

          services.AddTransient<IValidator<UserForRegistrationUiModel>, UserForRegistrationValidator>();

            services.AddSingleton<IPropertyMappingService, PropertyMappingService>();
            services.AddSingleton<ITypeHelperService, TypeHelperService>();

            services.AddScoped<IInquiryUserProcessor, InquiryUserProcessor>();
            services.AddScoped<IInquiryAllUsersProcessor, InquiryAllUsersProcessor>();
            services.AddScoped<ICreateUserProcessor, CreateUserProcessor>();
            services.AddScoped<IUpdateUserProcessor, UpdateUserProcessor>();
            services.AddScoped<IActivateUserProcessor, ActivateUserProcessor>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUsersControllerDependencyBlock, UsersControllerDependencyBlock>();

            services.AddScoped<IInquiryPersonProcessor, InquiryPersonProcessor>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();

            services.AddScoped<IInquiryRoleProcessor, InquiryRoleProcessor>();
            services.AddScoped<IInquiryAllRolesProcessor, InquiryAllRolesProcessor>();
            services.AddScoped<ICreateRoleProcessor, CreateRoleProcessor>();
            services.AddScoped<IUpdateRoleProcessor, UpdateRoleProcessor>();
            services.AddScoped<IDeleteRoleProcessor, DeleteRoleProcessor>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IRolesControllerDependencyBlock, RolesControllerDependencyBlock>();
        }

        public static void ConfigureAutoMapper(IServiceCollection services)
        {
            services.AddSingleton<IAutoMapper, AutoMapperAdapter>();
        }

        public static void ConfigureNHibernate(IServiceCollection services, string connectionString)
        {
            //HibernatingRhinos.Profiler.Appender.NHibernate.NHibernateProfiler.Initialize();

            try
            {
                var cfg =
                    PostgreSQLConfiguration.Standard.ConnectionString(connectionString)
                        .ShowSql()
                        .MaxFetchDepth(5)
                        .FormatSql()
                        .AdoNetBatchSize(100);

                var sessionFactory =
                    Fluently.Configure().Database(cfg)
                        .Mappings(
                            m => m.FluentMappings.AddFromAssemblyOf<UserMap>())
                        .Cache(c => c.UseSecondLevelCache().UseQueryCache()
                            .ProviderClass(typeof(NHibernate.Caches.RtMemoryCache.RtMemoryCacheProvider)
                                .AssemblyQualifiedName)
                        )
                        .CurrentSessionContext("web")
                        .BuildSessionFactory();

                services.AddSingleton<ISessionFactory>(sessionFactory);

                services.AddScoped<ISession>((ctx) =>
                {
                    var sf = ctx.GetRequiredService<ISessionFactory>();
                    return sf.OpenSession();
                });

                services.AddScoped<IUnitOfWork, NhUnitOfWork>();
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                    throw new NHibernateInitializationException(ex.Message, ex.InnerException.Message);
            }
        }
    }
}
