using System;
using System.Threading.Tasks;
using JustR.ClientRelatedShare;
using JustR.Core.Entity;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.DependencyInjection;

namespace JustR.Desktop.Notifications
{
    public class NotificationHandler : INotificationClient
    {
        public delegate Task NewMessageHandler(Message newMessage);

        public static readonly Lazy<NotificationHandler> Instance =
            new Lazy<NotificationHandler>(() => new NotificationHandler());

        private HubConnection _connection;

        private NotificationHandler()
        {
        }

        public async Task ReceiveNewMessage(Message message)
        {
            NewMessageHandler handler = NewMessageReceive;

            if (handler != null)
                await handler(message);
        }

        public event NewMessageHandler NewMessageReceive;

        public async Task StartHandling(Guid id)
        {
            //TODO : Убрать хардкор урла
            _connection = new HubConnectionBuilder()
                .WithUrl("http://localhost:5010/Notifications?userid=" + id)
                .AddJsonProtocol(options => options.PayloadSerializerOptions.PropertyNamingPolicy = null)
                .WithAutomaticReconnect()
                .Build();

            _connection.On<Message>(nameof(ReceiveNewMessage), ReceiveNewMessage);

            await _connection.StartAsync();
        }
    }
}