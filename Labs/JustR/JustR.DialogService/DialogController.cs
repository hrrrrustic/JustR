using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JustR.Models.Dto;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JustR.DialogService
{
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
