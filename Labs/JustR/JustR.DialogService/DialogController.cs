using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using JustR.DialogService.Service;
using JustR.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace JustR.DialogService
{
    [Route("api/[controller]")]
    public class DialogController : Controller
    {
        private readonly IDialogService _dialogService;

        public DialogController(IDialogService dialogService)
        {
            _dialogService = dialogService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<DialogPreviewDto>> GetDialogsPreview(Guid userId, Int32? offset, Int32 count)
        {
            try
            {
                IEnumerable<DialogPreviewDto> result = _dialogService.GetDialogsPreview(userId, offset, count);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{dialogId}")]
        public ActionResult<DialogInfoDto> GetDialog(Guid userId, Guid dialogId)
        {
            try
            {
                DialogInfoDto result = _dialogService.GetDialog(dialogId);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
