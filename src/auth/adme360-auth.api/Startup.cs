using System;
using System.Text;
using adme360.auth.api.Configurations;
using adme360.auth.api.Configurations.AutoMappingProfiles;
using AspNetCoreRateLimit;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Serialization;
using Serilog;

namespace adme360.auth.api
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    private const string CorsPolicyName = "AllowSpecificOrigins";

    public IConfiguration Configuration { get; }

    public IContainer ApplicationContainer { get; private set; }

    public IServiceProvider ConfigureServices(IServiceCollection services)
    {

      services.AddCors(options =>
      {
        options.AddPolicy(CorsPolicyName,
          builderCors => { builderCors.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin(); });
      });

      services.Configure<CookiePolicyOptions>(options =>
      {
        options.CheckConsentNeeded = context => true;
        options.MinimumSameSitePolicy = SameSiteMode.None;
      });

      services.AddLogging(loggingBuilder =>
        loggingBuilder
          .AddSerilog(dispose: true));


      var key = Encoding.ASCII.GetBytes(Configuration.GetSection("TokenAuthentication:SecretKey").Value);
      services.AddAuthentication(x =>
        {
          x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
          x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(x =>
        {
          x.RequireHttpsMetadata = false;
          x.SaveToken = true;
          x.TokenValidationParameters = new TokenValidationParameters
          {
            ValidateIssuerSigningKey = true,
            ValidateLifetime = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience = false,
            ClockSkew = TimeSpan.Zero,
            ValidIssuer = Configuration.GetSection("TokenAuthentication:Issuer").Value,
            ValidAudience = Configuration.GetSection("TokenAuthentication:Audience").Value,
          };
        });


      services.AddMvc(
          options =>
          {
            options.EnableEndpointRouting = false;
            options.RespectBrowserAcceptHeader = true;
            options.ReturnHttpNotAcceptable = true;
          })
        .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
        .AddNewtonsoftJson(options =>
        {
          options.SerializerSettings.ContractResolver =
            new DefaultContractResolver();
        })
        .AddFluentValidation();
      ;

      services.AddControllersWithViews()
        .AddNewtonsoftJson();
      services.AddRazorPages();

      services.AddResponseCaching();

      services.AddHttpCacheHeaders(
        (expirationModelOptions)
          =>
        {
          expirationModelOptions.MaxAge = 600;
          expirationModelOptions.SharedMaxAge = 300;
        },
        (validationModelOptions)
          =>
        {
          validationModelOptions.MustRevalidate = true;
          validationModelOptions.ProxyRevalidate = true;
        });

      services.AddMemoryCache();

      services.Configure<IpRateLimitOptions>((options) =>
      {
        options.GeneralRules = new System.Collections.Generic.List<RateLimitRule>()
        {
          new RateLimitRule()
          {
            Endpoint = "*",
            Limit = 1000,
            Period = "5m"
          },
          new RateLimitRule()
          {
            Endpoint = "*",
            Limit = 200,
            Period = "10s"
          }
        };
      });

      services.AddApiVersioning(o => o.ApiVersionReader = 
        new HeaderApiVersionReader("api-version"));

      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", new OpenApiInfo()
        {
          Title = "adme360-auth.api - HTTP API",
          Version = "v1",
          Description = "The Catalog Microservice HTTP API for adme360-auth.api service",
        });
        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
        {
          Description =
            "Authorization: Bearer {token}",
          Name = "Authorization",
          In = ParameterLocation.Header,
          Type = SecuritySchemeType.ApiKey
        });
        c.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
          {
            new OpenApiSecurityScheme
            {
              Reference = new OpenApiReference
              {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer"
              }
            },
            new string[] { }
          }
        });
      });

      Config.ConfigureRepositories(services);
      Config.ConfigureAutoMapper(services);
      Config.ConfigureNHibernate(services, Configuration["ConnectionString"]);

      var builder = new ContainerBuilder();

      builder.Populate(services);
      ApplicationContainer = builder.Build();
      return new AutofacServiceProvider(ApplicationContainer);
    }

    public void Configure(IApplicationBuilder app, IHostingEnvironment env, IApplicationLifetime lifetime)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }
      else
      {
        app.UseHsts();
      }

      app.UseSwagger()
        .UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", 
          "adme360-auth.api - API V1"); });

      app.UseCors(CorsPolicyName);
      app.UseResponseCaching();
      app.UseHttpCacheHeaders();
      app.UseCookiePolicy();
      app.UseHttpsRedirection();

      app.UseRouting();

      app.UseAuthentication();
      app.UseAuthorization();

      AutoMapper.Mapper.Initialize(cfg =>
      {
        cfg.AddProfile<RoleEntityToRoleCreationUiAutoMapperProfile>();
        cfg.AddProfile<RoleEntityToRoleUiAutoMapperProfile>();
        cfg.AddProfile<UserEntityToUserUiAutoMapperProfile>();
        cfg.AddProfile<UserEntityToUserForRetrievalUiAutoMapperProfile>();
        cfg.AddProfile<UserEntityToUserActivationUiAutoMapperProfile>();
        cfg.AddProfile<UserEntityToUserForAllRetrievalUiAutoMapperProfile>();
      });

      app.UseApiVersioning();
      app.UseEndpoints(endpoints => {
        endpoints.MapControllerRoute(
          name: "default",
          pattern: "{controller=Home}/{action=Index}/{id?}");
        endpoints.MapRazorPages();
      });
    }
  }
}
