using System;
using System.Collections.Generic;
using JustR.Core.Entity;
using JustR.MessageService.Service;
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

        #region HTTP GET

        [HttpGet("all")]
        public ActionResult<IReadOnlyList<Message>> GetMessages([FromQuery] Guid dialogId, Int32 offset, Int32 count)
        {
            IReadOnlyList<Message> messages = _messageService.GetMessages(dialogId, offset, count);

            return Ok(messages);
        }

        #endregion

        #region HTTP POST

        [HttpPost]
        public ActionResult<Message> SendMessage([FromQuery] Guid userId, Guid dialogId, [FromBody] String text)
        {
            if (String.IsNullOrWhiteSpace(text))
                return BadRequest();
            
            Message sentMessage = _messageService.SendMessage(userId, dialogId, text);

            return Ok(sentMessage);
        }

        #endregion
    }
}
