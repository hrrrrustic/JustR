using System;
using System.Linq;
using System.Threading.Tasks;
using JustR.ClientRelatedShare;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Primitives;

namespace JustR.NotificationService.Hubs
{
    public class NotificationHub : Hub<INotificationClient>
    {
        private readonly ConnectionManager _connectionManager = new ConnectionManager();
        public override Task OnConnectedAsync()
        {
            var context = Context.GetHttpContext();
            String id = context.Request.Query["userId"].FirstOrDefault();

            // TODO : Какой-то человеческий эксепшн кидать
            if (id is null || !Guid.TryParse(id, out Guid userId))
                throw new Exception();

            _connectionManager.AddConnection(userId, Context.ConnectionId);

            return Task.CompletedTask;
        }
        public override Task OnDisconnectedAsync(Exception exception)
        {
            var context = Context.GetHttpContext();
            String id = context.Request.Query["userId"].FirstOrDefault();
            // TODO : Тут что-то не так, но я пока не нашел как это адекватно делать
            if (id is null || !Guid.TryParse(id, out Guid userId))
                throw new Exception();

            _connectionManager.RemoveConnection(userId, Context.ConnectionId);
            return Task.CompletedTask;
        }
    }
}