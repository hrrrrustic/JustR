using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Primitives;

namespace JustR.NotificationService.Hubs
{
    // TODO : Есть типизированный хаб, там должно быть не так больно с вызовом методов
    public class NotificationHub : Hub
    {
        private readonly ConnectionManager _connectionManager = new ConnectionManager();
        public override Task OnConnectedAsync()
        {
            var context = Context.GetHttpContext();
            String id = context.Request.Query["userId"].FirstOrDefault();
            var userId = Guid.Parse(id);

            _connectionManager.AddConnection(userId, Context.ConnectionId);

            return Task.CompletedTask;
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            var context = Context.GetHttpContext();
            String id = context.Request.Query["userId"].FirstOrDefault();
            var userId = Guid.Parse(id);
            
            _connectionManager.RemoveConnection(userId, Context.ConnectionId);
            return Task.CompletedTask;
        }
    }
}