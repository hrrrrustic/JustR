using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using JustR.Core.Dto;
using JustR.Core.Entity;
using JustR.Desktop.Annotations;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.DependencyInjection;

namespace JustR.Desktop
{
    public class NotificationHandler
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

            _connection.On<Message>("ReceiveNewMessage",
                (newMessage) => NewMessageReceive?.Invoke(newMessage));
            
            await _connection.StartAsync();
        }

        // TODO : Обработка ошибок
        private async Task Reconnect(Exception ex)
        {
            if(ex is null)
                return;

            await _connection.StartAsync();
        }
    }
}