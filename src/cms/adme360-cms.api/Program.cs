using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using adme360.cms.api.Helpers.Loggings;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Serilog;
using Serilog.Enrichers.AspnetcoreHttpcontext;
using Serilog.Events;
using Serilog.Formatting.Compact;

namespace adme360.cms.api
{
  public class Program
  {
    public static void Main(string[] args)
    {
      CreateWebHostBuilder(args).Build().Run();
    }

    public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
        WebHost.CreateDefaultBuilder(args)
            .UseStartup<Startup>()
            .UseUrls(urls: "http://0.0.0.0:7200")
            .UseSerilog((provider, context, loggerConfiguration) =>
            {
              var name = Assembly.GetExecutingAssembly().GetName();

              loggerConfiguration
                      .MinimumLevel.Debug()
                      .MinimumLevel.Override("adme360-crm.api", LogEventLevel.Information)
                      .Enrich.WithAspnetcoreHttpcontext(provider,
                          customMethod: CustomEnricherLogic)
                      .Enrich.FromLogContext()
                      .Enrich.WithMachineName()
                      .Enrich.WithProperty("Assembly", $"{name.Name}")
                      .Enrich.WithProperty("Revision", $"{name.Version}")
                      .WriteTo.RollingFile($@"Logs{Path.DirectorySeparatorChar}log-{DateTime.Now:yyyyMMdd}.txt",
                      LogEventLevel.Information, retainedFileCountLimit: 7)
                      .WriteTo.File(new CompactJsonFormatter(),
                          @"./Logs/adme360-crm.api.json")
                      .WriteTo.Debug(
                          outputTemplate:
                          "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj} " +
                          "{NewLine}{HttpContext} " +
                          "{NewLine}{Exception}")
                      ;
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
