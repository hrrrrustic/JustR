using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JustR.Core.Dto;
using JustR.Core.Extensions;
using JustR.Core.Entity;
using JustR.DialogService.Service;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;

namespace JustR.DialogService
{
    [Consumes("application/json")]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class DialogController : Controller
    {
        // TODO : Убрать куда-нибудь хардкор урла
        private readonly RestClient _messageClient = new RestClient("http://localhost:5007/api/Message");
        private readonly IDialogService _dialogService;

        public DialogController(IDialogService dialogService)
        {
            _dialogService = dialogService;
            _messageClient.UseNewtonsoftJson();
        }

        [HttpGet("preview")]
        public ActionResult<IReadOnlyList<DialogPreviewDto>> GetDialogsPreview([FromQuery] Guid userId, Int32 count, Int32 offset)
        {
            IReadOnlyList<Dialog> dialogs = _dialogService.GetDialogsPreview(userId, offset, count);

            return Ok(dialogs);
        }

        [HttpGet]
        public ActionResult<DialogInfoDto> GetDialog([FromQuery] Guid dialogId)
        {
            Dialog dialog = _dialogService.GetDialog(dialogId);

            return Ok(dialog);
        }

        [HttpPost]
        public ActionResult<Dialog> CreateDialog([FromQuery] Guid firstUserId, Guid secondUserId)
        {
            Dialog createdDialog = _dialogService.CreateDialog(firstUserId, secondUserId);

            return Ok(createdDialog);
        }

        [HttpGet("id")]
        public ActionResult<Guid> GetDialogId([FromQuery] Guid firstUserId, Guid secondUserId)
        {
            Guid id = _dialogService.GetDialogId(firstUserId, secondUserId);

            return Ok(id);
        }


        // TODO : Убрать текст в тело запроса
        [HttpPost("message")]
        public async Task<ActionResult> SendMessage([FromQuery] Guid dialogId, Guid authorId, String text)
        {
            Dialog dialog = _dialogService.UpdateLastMessage(authorId, dialogId, text);

            if (dialog is null)
                return BadRequest();

            IRestRequest request = new RestRequest()
                .AddQueryParameter("userId", authorId)
                .AddQueryParameter("dialogId", dialogId)
                .AddQueryParameter("text", text);

            await _messageClient.PostAsync<Message>(request);

            return Ok();
        }
    }
}
