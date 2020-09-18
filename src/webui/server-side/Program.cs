using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace adme360.webui
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
                    webBuilder.UseSetting(WebHostDefaults.DetailedErrorsKey, "true"); // detailed server errors from circuits
                    webBuilder.UseStartup<Startup>();
                });
    }
}
