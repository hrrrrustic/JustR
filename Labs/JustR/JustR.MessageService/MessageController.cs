using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JustR.MessageService.Service;
using JustR.Models.Dto;
using JustR.Models.Entity;
using Microsoft.AspNetCore.Mvc;

namespace JustR.MessageService
{
    [Route("api/[controller]")]
    [Consumes("application/json")]
    [Produces("application/json")]
    public class MessageController : Controller
    {
        private readonly IMessageService _messageService;

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }
        
        [HttpGet("all")]
        public ActionResult<IEnumerable<Message>> GetMessages([FromQuery] Guid userId, Guid dialogId, Int32? offset, Int32 count)
        {
            var res = _messageService.GetMessages(userId, dialogId, offset, count);
            return Ok(res);
        }

        [HttpPost]
        public ActionResult<Message> SendMessage([FromQuery] Guid userId, Guid dialogId, String text)
        {
            if (String.IsNullOrWhiteSpace(text))
                return BadRequest();
            
            var message = _messageService.SendMessage(userId, dialogId, text);
            return Ok(message);
        }
    }
}
