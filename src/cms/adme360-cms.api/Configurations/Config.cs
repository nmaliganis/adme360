using System;
using System.Reflection;
using adme360.cms.api.Helpers;
using adme360.cms.contracts.Categories;
using adme360.cms.contracts.Customers;
using adme360.cms.contracts.Stores;
using adme360.cms.contracts.Users;
using adme360.cms.contracts.V1;
using adme360.cms.repository.ContractRepositories;
using adme360.cms.repository.Mappings.Customers;
using adme360.cms.repository.NhUnitOfWork;
using adme360.cms.repository.Repositories;
using adme360.cms.services.Categories;
using adme360.cms.services.Customers;
using adme360.cms.services.Stores;
using adme360.cms.services.Users;
using adme360.cms.services.V1;
using adme360.common.infrastructure.Exceptions.Repositories;
using adme360.common.infrastructure.Helpers.Serializers;
using adme360.common.infrastructure.PropertyMappings;
using adme360.common.infrastructure.PropertyMappings.TypeHelpers;
using adme360.common.infrastructure.TypeMappings;
using adme360.common.infrastructure.UnitOfWorks;
using AspNetCoreRateLimit;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.DependencyInjection;
using NHibernate;
using NHibernate.Driver;
using NHibernate.Spatial.Dialect;
using NHibernate.Spatial.Mapping;
using NHibernate.Spatial.Metadata;

namespace adme360.cms.api.Configurations
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

      services.AddSingleton<IPropertyMappingService, PropertyMappingService>();
      services.AddSingleton<ITypeHelperService, TypeHelperService>();

      services.AddTransient<IJsonSerializer, JSONSerializer>();

      services.AddScoped<IInquiryUserProcessor, InquiryUserProcessor>();
      services.AddScoped<IUserRepository, UserRepository>();
      services.AddScoped<IUsersControllerDependencyBlock, UsersControllerDependencyBlock>();

      services.AddScoped<IRoleRepository, RoleRepository>();

      services.AddScoped<IInquiryCustomerProcessor, InquiryCustomerProcessor>();
      services.AddScoped<IInquiryAllCustomersProcessor, InquiryAllCustomersProcessor>();
      services.AddScoped<ICreateCustomerProcessor, CreateCustomerProcessor>();
      services.AddScoped<ICustomerRepository, CustomerRepository>();
      services.AddScoped<ICustomersControllerDependencyBlock, CustomersControllerDependencyBlock>();

      services.AddScoped<IInquiryCategoryProcessor, InquiryCategoryProcessor>();
      services.AddScoped<IInquiryAllCategoriesProcessor, InquiryAllCategoriesProcessor>();
      services.AddScoped<ICreateCategoryProcessor, CreateCategoryProcessor>();
      services.AddScoped<IUpdateCategoryProcessor, UpdateCategoryProcessor>();
      services.AddScoped<IDeleteCategoryProcessor, DeleteCategoryProcessor>();
      services.AddScoped<ICategoryRepository, CategoryRepository>();
      services.AddScoped<ICategoriesControllerDependencyBlock, CategoriesControllerDependencyBlock>();

      services.AddScoped<IInquiryStoreProcessor, InquiryStoreProcessor>();
      services.AddScoped<IInquiryAllStoresProcessor, InquiryAllStoresProcessor>();
      services.AddScoped<ICreateStoreProcessor, CreateStoreProcessor>();
      services.AddScoped<IUpdateStoreProcessor, UpdateStoreProcessor>();
      services.AddScoped<IDeleteStoreProcessor, DeleteStoreProcessor>();
      services.AddScoped<IStoreRepository, StoreRepository>();
      services.AddScoped<IStoresControllerDependencyBlock, StoresControllerDependencyBlock>();
    }

    public static void ConfigureAutoMapper(IServiceCollection services)
    {
      services.AddSingleton<IAutoMapper, AutoMapperAdapter>();
    }

    public static void ConfigureNHibernate(IServiceCollection services, string connectionString)
    {
      HibernatingRhinos.Profiler.Appender.NHibernate.NHibernateProfiler.Initialize();

      try
      {
        var cfg = Fluently.Configure()
          .Database(PostgreSQLConfiguration.PostgreSQL82
            .ConnectionString(connectionString)
            .Driver<NpgsqlDriver>()
            .Dialect<PostGis20Dialect>()
            .ShowSql()
            .MaxFetchDepth(5)
            .FormatSql()
            .Raw("transaction.use_connection_on_system_prepare", "true")
            .AdoNetBatchSize(100)
          )
          .Mappings(x => x.FluentMappings.AddFromAssemblyOf<CustomerMap>())
          .Cache(c => c.UseSecondLevelCache().UseQueryCache()
            .ProviderClass(typeof(NHibernate.Caches.RtMemoryCache.RtMemoryCacheProvider)
              .AssemblyQualifiedName)
          )
          .CurrentSessionContext("web")
          .BuildConfiguration();

        cfg.AddAssembly(Assembly.GetExecutingAssembly());
        cfg.AddAuxiliaryDatabaseObject(new SpatialAuxiliaryDatabaseObject(cfg));
        Metadata.AddMapping(cfg, MetadataClass.GeometryColumn);
        Metadata.AddMapping(cfg, MetadataClass.SpatialReferenceSystem);

        var sessionFactory = cfg.BuildSessionFactory();

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
        throw new NHibernateInitializationException(ex.Message, ex.InnerException?.Message);
      }
    }
  }
}
