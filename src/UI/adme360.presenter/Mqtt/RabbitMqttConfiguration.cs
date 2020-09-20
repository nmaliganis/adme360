using System;
using dl.wm.presenter.Commanding;
using dl.wm.presenter.Commanding.Commands;
using dl.wm.presenter.Commanding.Servers;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace dl.wm.presenter.Mqtt
{
    public class RabbitMqttConfiguration : IRabbitMqttConfiguration
    {
        private MqttClient _client;

        public void EstablishConnection()
        {
            _client = new MqttClient(RabbitMqConfiguration.Api);

            _client.Subscribe(new[]
                {
                    CommandingTopicsRepository.GetTopicRepository.ContainerPost
                },
                new[] {MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE});

            _client.Subscribe(new[]
                {
                    CommandingTopicsRepository.GetTopicRepository.ContainerPut
                },
                new[] {MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE});

            _client.Subscribe(new[]
                {
                    CommandingTopicsRepository.GetTopicRepository.ContainerDelete
                },
                new[] {MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE});

            _client.MqttMsgPublishReceived += ClientMqttMsgPublishReceived;
            _client.ConnectionClosed += ClientConnectionClosed;
            _client.MqttMsgPublished += ClientMqttMsgPublished;
            _client.MqttMsgSubscribed += ClientMqttMsgSubscribed;
            _client.MqttMsgUnsubscribed += ClientMqttMsgUnsubscribed;

            _client.Connect($"UI-{Guid.NewGuid().ToString()}",
                RabbitMqConfiguration.Username
                , RabbitMqConfiguration.Password
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
            InboundCommandBuilderRepository.GetCommandBuilderRepository
                    [e.Topic].Build(e.Message).RaiseEvent(CommandingInboundServer.GetCommandingInboundServer);
        }
    }
}