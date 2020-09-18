using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using magic.button.collector.api.Helpers.Loggings;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Enrichers.AspnetcoreHttpcontext;
using Serilog.Events;
using Serilog.Formatting.Compact;

namespace magic.button.collector.api
{
  public class Program
  {
    public static void Main(string[] args)
    {
      CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
      Host.CreateDefaultBuilder(args)
        .ConfigureWebHostDefaults(webBuilder =>
        {
          webBuilder.UseStartup<Startup>();
          webBuilder.UseUrls("http://0.0.0.0:6300");
          webBuilder.UseSerilog((provider, context, loggerConfiguration) =>
          {
            var name = Assembly.GetExecutingAssembly().GetName();

            loggerConfiguration
              .MinimumLevel.Debug()
              .MinimumLevel.Override("magic-button-collector.api", LogEventLevel.Information)
              .Enrich.WithAspnetcoreHttpcontext(provider,
                customMethod: CustomEnricherLogic)
              .Enrich.FromLogContext()
              .Enrich.WithMachineName()
              .Enrich.WithProperty("Assembly", $"{name.Name}")
              .Enrich.WithProperty("Revision", $"{name.Version}")
              .WriteTo.RollingFile($@"./Logs/magic-button-collector.api.txt",
                LogEventLevel.Information, retainedFileCountLimit: 7)
              .WriteTo.File(new CompactJsonFormatter(),
                @"./Logs/magic-button-collector.api.json")
              .WriteTo.Debug(
                outputTemplate:
                "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj} {NewLine}{HttpContext} {NewLine}{Exception}");
          });
        });

    private static LoggingModel CustomEnricherLogic(IHttpContextAccessor ctx)
    {
      var context = ctx.HttpContext;
      if (context == null) return null;

      var loggingInfo = new LoggingModel
      {
        Path = context.Request.Path.ToString(),
        Host = context.Request.Host.ToString(),
        Method = context.Request.Method
      };

      var user = context.User;
      if (user?.Identity != null && user.Identity.IsAuthenticated)
      {
        loggingInfo.UserClaims =
          user.Claims.Select(a => new KeyValuePair<string, string>(a.Type, a.Value)).ToList();
      }
      return loggingInfo;
    }
  }
}
