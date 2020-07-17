using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JustR.Core.Entity;
using JustR.DialogService.InternalApi;
using JustR.DialogService.Service;
using JustR.MessageService.InternalApi;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JustR.DialogService
{
    [Consumes("application/json")]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class DialogController : Controller
    {
        private readonly IDialogService _dialogService;
        private readonly IMessageApiProvider _messageApiProvider;

        public DialogController(IDialogService dialogService, IMessageApiProvider messageApiProvider)
        {
            _dialogService = dialogService;
            _messageApiProvider = messageApiProvider;
        }

        #region HTTP GET

        [HttpGet(DialogServiceHttpEndpoints.GetDialogId)]
        public ActionResult<Guid> GetDialogId([FromQuery] Guid firstUserId, Guid secondUserId)
        {
            Guid id = _dialogService.FindDialogId(firstUserId, secondUserId);

            return Ok(id);
        }

        [HttpGet(DialogServiceHttpEndpoints.GetDialogsPreview)]
        public ActionResult<IReadOnlyList<Dialog>> GetDialogsPreview([FromQuery] Guid userId, Int32 count, Int32 offset)
        {
            IReadOnlyList<Dialog> dialogs = _dialogService.FindDialogsPreview(userId, offset, count);

            return Ok(dialogs);
        }

        [HttpGet(DialogServiceHttpEndpoints.GetDialog)]
        public ActionResult<Dialog> GetDialog([FromQuery] Guid dialogId)
        {
            Response.StatusCode = 200;
            Dialog dialog = _dialogService.FindDialog(dialogId);

            return Ok(dialog);
        }

        #endregion

        #region HTTP POST

        [HttpPost(DialogServiceHttpEndpoints.CreateDialog)]
        public ActionResult<Dialog> CreateDialog([FromQuery] Guid firstUserId, Guid secondUserId)
        {
            Dialog createdDialog = _dialogService.CreateDialog(firstUserId, secondUserId);

            return Ok(createdDialog);
        }

        [HttpPost(DialogServiceHttpEndpoints.SendMessage)]
        public async Task<ActionResult> SendMessage([FromQuery] Guid dialogId, Guid authorId, [FromBody] String text)
        {
            Dialog dialog;
            try
            {
                dialog = _dialogService.UpdateLastMessage(authorId, dialogId, text);
            }
            catch (ArgumentException)
            {
                return BadRequest();
            }

            await _messageApiProvider.SendMessage(authorId, dialogId, dialog.GetInterlocutorId(authorId), text);

            return Ok();
        }

        #endregion
    }
}