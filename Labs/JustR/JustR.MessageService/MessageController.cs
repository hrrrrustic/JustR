using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JustR.MessageService.Service;
using JustR.Models.Dto;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JustR.MessageService
{
    public class MessageController : Controller
    {

        private readonly IMessageService _messageService;

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpGet("t/t")]
        public ActionResult<IEnumerable<MessageDto>> GetMessages(Guid userId, Guid dialogId, Int32? offset, Int32 count)
        {
            return Ok(_messageService.GetMessages(userId, dialogId, offset, count));
        }

        [HttpPost("t/{dialogId}")]
        public ActionResult<MessageDto> SendMessage(Guid userId, Guid dialogId, String text)
        {
            if (String.IsNullOrWhiteSpace(text))
                return BadRequest();

            return Ok(_messageService.SendMessage(userId, dialogId, text));
        }
    }
}
