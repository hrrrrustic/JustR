using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JustR.Models.Dto;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JustR.MessageService
{
    public class MessageController : Controller
    {
        [HttpGet]
        public ActionResult<IEnumerable<MessageDto>> GetMessages(Guid userId, Guid dialogId, Int32? offset, Int32 count)
        {
            throw new NotImplementedException();
        }

        [HttpPost("{dialogId}")]
        public ActionResult<MessageDto> SendMessage(Guid userId, Guid dialogId, String text)
        {
            throw new NotImplementedException();
        }
    }
}
