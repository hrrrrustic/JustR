using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JustR.ClientRelatedShare.Dto;
using JustR.Core.Entity;
using JustR.DesktopGateway.PublicApi;
using JustR.DialogService.InternalApi;
using JustR.MessageService.InternalApi;
using JustR.ProfileService.InternalApi;
using Microsoft.AspNetCore.Mvc;

namespace JustR.DesktopGateway.Controllers
{
    [Consumes("application/json")]
    [Produces("application/json")]
    [Route("api/" + DesktopGatewayHttpEndpoints.MessageEndpoints.ControllerEndpoint)]
    public class MessageController : Controller
    {
        private readonly IDialogApiProvider _dialogApiProvider;
        private readonly IMessageApiProvider _messageApiProvider;
        private readonly IProfileApiProvider _profileApiProvider;

        public MessageController(IProfileApiProvider profileApiProvider, IDialogApiProvider dialogApiProvider,
            IMessageApiProvider messageApiProvider)
        {
            _profileApiProvider = profileApiProvider;
            _dialogApiProvider = dialogApiProvider;
            _messageApiProvider = messageApiProvider;
        }

        #region HTTP GET

        [HttpGet(DesktopGatewayHttpEndpoints.MessageEndpoints.GetMessages)]
        public async Task<ActionResult<IReadOnlyList<MessageDto>>> GetMessages(Guid userId, Guid dialogId,
            Int32? offset, Int32 count)
        {
            IReadOnlyList<Message> messages = await _messageApiProvider.GetMessages(dialogId, offset ?? 0, count);

            var messagesId = messages.Select(k => k.AuthorId);
            IReadOnlyList<User> users = await _profileApiProvider.GetUsersPreview(messagesId);

            IReadOnlyList<MessageDto> dto = messages
                .Zip(users, (message, user) => MessageDto.FromMessageAndUser(user, message))
                .ToList();

            return Ok(dto);
        }

        #endregion

        #region HTTP POST

        [HttpPost(DesktopGatewayHttpEndpoints.MessageEndpoints.SendMessage)]
        public async Task<ActionResult<MessageDto>> SendMessage([FromQuery] Guid dialogId, Guid authorId,
            [FromBody] String text)
        {
            await _dialogApiProvider.SendMessage(dialogId, authorId, text);

            return Ok();
        }

        #endregion
    }
}