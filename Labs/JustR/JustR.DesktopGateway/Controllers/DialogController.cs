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
    public class DialogController : Controller
    {
        [HttpGet]
        public ActionResult<IEnumerable<DialogPreviewDto>> GetDialogs(Guid userId, Int32? offset, Int32 count)
        {
            throw new NotImplementedException();
        }

        [HttpGet("{dialogId}")]
        public ActionResult<DialogInfoDto> GetDialog(Guid userId, Guid dialogId)
        {
            throw new NotImplementedException();
        }
    }
}
