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

        public event NewMessageHandler NewMessageReceive;

        public static readonly Lazy<NotificationHandler> Instance =
            new Lazy<NotificationHandler>(() => new NotificationHandler());

        private HubConnection _connection;

        private NotificationHandler()
        {
        }

        public async Task StartHandling(Guid id)
        {
            _connection = new HubConnectionBuilder()
                .WithUrl("http://localhost:5010/Notifications?userid=" + id)
                .AddJsonProtocol(options => options.PayloadSerializerOptions.PropertyNamingPolicy = null)
                .Build();

            _connection.Closed += Reconnect;

            _connection.On<Message>(nameof(ReceiveNewMessage), ReceiveNewMessage);

            await _connection.StartAsync();
        }

        // TODO : Обработка ошибок
        private async Task Reconnect(Exception ex)
        {
            if(ex is null)
                return;

            await _connection.StartAsync();
        }

        public async Task ReceiveNewMessage(Message message)
        {
            if(NewMessageReceive is null)
                return;

            await NewMessageReceive.Invoke(message);
        }
    }
}