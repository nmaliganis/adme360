using magic.button.collector.api.Configurations;
using magic.button.collector.api.Messaging.PortHandlers;
using magic.button.collector.api.Proxies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Serilog;

namespace magic.button.collector.api
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
      services.AddLogging(loggingBuilder =>
        loggingBuilder
          .AddSerilog(dispose: true));

      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", new OpenApiInfo()
        {
          Title = "magic-button-collector.api - HTTP API",
          Version = "v1",
          Description = "The Catalog Microservice HTTP API for magic-button-collector.api service",
          //TermsOfService = new Uri(""),
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

      services.AddApiVersioning(o =>
      {
        o.ReportApiVersions = true;
        o.AssumeDefaultVersionWhenUnspecified = true;
        o.DefaultApiVersion = new ApiVersion(1, 0);
      });

      services.AddControllersWithViews();
      services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();

      services.AddControllers();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseHttpsRedirection();
      app.UseRouting();
      app.UseAuthorization();

      app.UseApiVersioning();

      var serviceProvider = app.ApplicationServices;
      var serviceUPortHandler = (IPortHandlerFactory)serviceProvider.GetService(typeof(IPortHandlerFactory));
      serviceUPortHandler.CreatePortHandler().ToggleComPort(Configuration.GetSection("TTY:Port").Value);

      var serviceMqtt = (IRabbitMqttConfiguration) serviceProvider.GetService(typeof(IRabbitMqttConfiguration));
      serviceMqtt.EstablishConnection();

      app.UseSwagger()
        .UseSwaggerUI(c =>
        {
          c.SwaggerEndpoint("/swagger/v1/swagger.json", "magic-button-collector.api API V1");
        });
      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}
