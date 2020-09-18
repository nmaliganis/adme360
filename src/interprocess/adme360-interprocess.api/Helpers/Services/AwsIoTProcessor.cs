using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using magic.button.collector.api.Helpers.Contracts;
using Microsoft.Extensions.Configuration;
using Serilog;
using uPLibrary.Networking.M2Mqtt;

namespace magic.button.collector.api.Helpers.Services
{
  public class AwsIoTProcessor : IAwsIoTProcessor
  {
    public IConfiguration Configuration { get; }

    private MqttClient _client;

    public AwsIoTProcessor(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public Task<bool> OnDemandMessageAsync(string certPath, string message)
    {
      Log.Information($"Path:{certPath}\n");
      Log.Information($"Message:{message}\n");

      string iotEndpoint = "a2qlh561li3gd6-ats.iot.eu-west-1.amazonaws.com";
      int brokerPort = 8883;
      Log.Information("1\n");
      string topic = "vessel/server";

      var caCert = X509Certificate.CreateFromCertFile(Path.Join(certPath, "AmazonRootCA1.crt"));
      var clientCert = new X509Certificate2(Path.Join(certPath, "certificate.cert.pfx"), "123456q!");
      Log.Information("2\n");

      _client = new MqttClient(iotEndpoint, brokerPort, true, caCert, clientCert, MqttSslProtocols.TLSv1_2);
      Log.Information("3\n");

      string clientId = Guid.NewGuid().ToString();
      _client.Connect(clientId);
      Log.Information("4\n");

      var result = _client.Publish(topic, Encoding.UTF8.GetBytes(message));
      Log.Information("5\n");

      return result == 1 ? Task.Run(() => true) : Task.Run(() => false);
    }
  }
}