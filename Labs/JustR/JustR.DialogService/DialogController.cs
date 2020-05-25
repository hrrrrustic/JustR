using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using JustR.DialogService.Repository;
using JustR.DialogService.Service;
using JustR.Models.Dto;
using JustR.Models.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using SqlKata.Compilers;

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
                IEnumerable<Dialog> result = _dialogService.GetDialogsPreview(userId, offset, count);
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
                Dialog result = _dialogService.GetDialog(dialogId);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public ActionResult<DialogInfoDto> CreateDialog(Guid userId, Guid secondUserId)
        {
            try
            {
                Dialog result = _dialogService.CreateDialog(userId, secondUserId);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
