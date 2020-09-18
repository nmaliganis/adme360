using magic.button.collector.api.Helpers.Serializers;
using magic.button.collector.api.Messaging.PortHandlers;
using magic.button.collector.api.Proxies;
using Microsoft.Extensions.DependencyInjection;

namespace magic.button.collector.api.Configurations
{
  public static class Config
  {
    public static void ConfigureRepositories(IServiceCollection services)
    {
      services.AddTransient<IJsonSerializer, JSONSerializer>();
      services.AddSingleton<IRabbitMqttConfiguration, RabbitMqttConfiguration>();

      services.AddSingleton<IPortHandlerFactory, PortHandlerFactory>();
    }
  }
}
