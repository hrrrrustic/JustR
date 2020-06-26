using System;
using System.Threading.Tasks;
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
        private readonly IHubContext<NotificationHub> _context;

        private readonly ConnectionManager _connectionManager = new ConnectionManager();
        public NotificationController(IHubContext<NotificationHub> context)
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
                    .SendAsync("ReceiveNewMessage", newMessage);
            }

            return Ok();
        }
    }
}