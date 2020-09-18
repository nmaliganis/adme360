using System;
using System.Text;
using magic.button.collector.api.Messaging.Commands.Inbounds.Events.Args;
using magic.button.collector.api.Messaging.Commands.Inbounds.Events.Listeners;
using magic.button.collector.api.Messaging.Commands.Servers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace magic.button.collector.api.Proxies
{
  public class RabbitMqttConfiguration : IRabbitMqttConfiguration, ITelemetryDetectionActionListener
  {
    public IConfiguration Configuration { get; }
    private readonly IServiceScopeFactory _scopeFactory;
    private readonly IServiceProvider _service;

    private MqttClient _client;

    public RabbitMqttConfiguration(IConfiguration configuration, 
      IServiceScopeFactory scopeFactory, IServiceProvider service)
    {
      Configuration = configuration;
      _scopeFactory = scopeFactory;
      _service = service;

      InboundServer.GetInboundServer.Attach((ITelemetryDetectionActionListener) this);
    }

    public void EstablishConnection()
    {
      _client = new MqttClient(Configuration.GetSection("RabbitMq:Api").Value);

      _client.Subscribe(new[]
        {
          "mb/ack"
        },
        new[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });  
      
      _client.Subscribe(new[]
        {
          "mb/nack"
        },
        new[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });  

      _client.Subscribe(new[]
        {
          "mb/telemetry/message"
        },
        new[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });
      
      _client.MqttMsgPublishReceived += ClientMqttMsgPublishReceived;
      _client.ConnectionClosed += ClientConnectionClosed;
      _client.MqttMsgPublished += ClientMqttMsgPublished;
      _client.MqttMsgSubscribed += ClientMqttMsgSubscribed;
      _client.MqttMsgUnsubscribed += ClientMqttMsgUnsubscribed;

      _client.Connect($"COLLECTOR-MB-{Guid.NewGuid().ToString()}",
        Configuration.GetSection("RabbitMq:Username").Value
        ,Configuration.GetSection("RabbitMq:Password").Value
      );
    }

    private void ClientMqttMsgUnsubscribed(object sender, MqttMsgUnsubscribedEventArgs e)
    {
    }

    private void ClientMqttMsgSubscribed(object sender, MqttMsgSubscribedEventArgs e)
    {
    }

    private void ClientMqttMsgPublished(object sender, MqttMsgPublishedEventArgs e)
    {
    }

    private void ClientConnectionClosed(object sender, EventArgs e)
    {
    }

    private void ClientMqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
    {

    }


    public void Update(object sender, TelemetryDetectionEventArgs e)
    {
      if (_client.IsConnected)
      {
        //Todo: Log for Mqtt
        var result = _client
          .Publish(Configuration.GetSection("MqttTopics:Telemetry").Value, Encoding.UTF8.GetBytes(e.Payload));
      }
    }
  }
}