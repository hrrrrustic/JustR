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
using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;
using SqlKata.Compilers;

namespace JustR.DialogService
{
    [Consumes("application/json")]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class DialogController : Controller
    {
        private readonly RestClient _messageClient = new RestClient("http://localhost:5007/api/Message");
        private readonly IDialogService _dialogService;

        public DialogController(IDialogService dialogService)
        {
            _dialogService = dialogService;
            _messageClient.UseNewtonsoftJson();
        }

        [HttpGet("preview")]
        public ActionResult<List<DialogPreviewDto>> GetDialogsPreview([FromQuery] Guid userId, Int32 count, Int32 offset)
        {
            try
            {
                List<Dialog> result = _dialogService.GetDialogsPreview(userId, offset, count);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public ActionResult<DialogInfoDto> GetDialog([FromQuery] Guid dialogId)
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
        public ActionResult<Dialog> CreateDialog([FromQuery] Guid firstUserId, Guid secondUserId)
        {
            try
            {
                Dialog result = _dialogService.CreateDialog(firstUserId, secondUserId);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }

        [HttpGet("id")]
        public ActionResult<Guid> GetDialogId([FromQuery] Guid firstUserId, Guid secondUserId)
        {
            var id = _dialogService.GetUserId(firstUserId, secondUserId);

            return Ok(id);
        }

        [HttpPost("message")]
        public async Task<ActionResult> SendMessage([FromQuery] Guid dialogId, Guid authorId, String text)
        {
            _dialogService.UpdateLastMessage(authorId, dialogId, text);

            var request = new RestRequest();
            request
                .AddParameter("userId", authorId, ParameterType.QueryString)
                .AddParameter("dialogId", dialogId, ParameterType.QueryString)
                .AddParameter("text", text, ParameterType.QueryString);

            await _messageClient.PostAsync<Message>(request);

            return Ok();
        }
    }
}
