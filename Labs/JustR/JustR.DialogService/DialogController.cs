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
        private readonly IRestClient _messageClient =
            new RestClient(ServiceConfiguration.MessageServiceUrl)
                .UseNewtonsoftJson();

        private readonly IDialogService _dialogService;
         
        public DialogController(IDialogService dialogService)
        {
            _dialogService = dialogService;
        }

        #region HTTP GET

        [HttpGet("id")]
        public ActionResult<Guid> GetDialogId([FromQuery] Guid firstUserId, Guid secondUserId)
        {
            Guid id = _dialogService.GetDialogId(firstUserId, secondUserId);

            return Ok(id);
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

        #endregion

        #region HTTP POST

        [HttpPost]
        public ActionResult<Dialog> CreateDialog([FromQuery] Guid firstUserId, Guid secondUserId)
        {
            Dialog createdDialog = _dialogService.CreateDialog(firstUserId, secondUserId);

            return Ok(createdDialog);
        }
       
        [HttpPost("message")]
        public async Task<ActionResult> SendMessage([FromQuery] Guid dialogId, Guid authorId, [FromBody] String text)
        {
            Dialog dialog = _dialogService.UpdateLastMessage(authorId, dialogId, text);

            if (dialog is null)
                return BadRequest();

            IRestRequest request = new RestRequest()
                .AddQueryParameter("userId", authorId)
                .AddQueryParameter("dialogId", dialogId)
                .AddJsonBody(text);

            await _messageClient.PostAsync<Message>(request);

            return Ok();
        }

        #endregion
    }
}
