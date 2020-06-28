using System;
using System.Threading.Tasks;
using JustR.ClientRelatedShare;
using JustR.Core.Entity;
using JustR.NotificationService.Hubs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace JustR.NotificationService
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class NotificationController : Controller
    {
        private readonly IHubContext<NotificationHub, INotificationClient> _context;

        private readonly ConnectionManager _connectionManager = new ConnectionManager();
        public NotificationController(IHubContext<NotificationHub, INotificationClient> context)
        {
            _context = context;
        }
        
        [HttpPost("message")]
        public async Task<IActionResult> NewMessage([FromBody] Message newMessage, [FromQuery] Guid firstReceiverId,
            Guid secondReceiverId)
        {
            var connections = _connectionManager.GetUserConnections(firstReceiverId);
            connections.UnionWith(_connectionManager.GetUserConnections(secondReceiverId));

            foreach (String connection in connections)
            {
                await _context
                    .Clients
                    .Client(connection)
                    .ReceiveNewMessage(newMessage);
            }

            return Ok();
        }
    }
}