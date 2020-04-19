using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JustR.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace JustR.DesktopGateway.Controllers
{
    [Consumes("application/json")]
    [Produces("application/json")]
    [Route("api/[controller]")]
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