using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JustR.Core.Dto;
using JustR.Core.Entity;
using JustR.Core.Extensions;
using JustR.DialogService.InternalApi;
using JustR.MessageService.InternalApi;
using JustR.ProfileService.InternalApi;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;

namespace JustR.DesktopGateway.Controllers
{
    [Consumes("application/json")]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class MessageController : Controller
    {
        private readonly IMessageApiProvider _messageApiProvider = new HttpMessageApiProvider(ServiceConfigurations.MessageServiceUrl);
        private readonly IProfileApiProvider _profileApiProvider = new HttpProfileApiProvider(ServiceConfigurations.ProfileServiceUrl);
        private readonly IDialogApiProvider _dialogApiProvider = new HttpDialogApiProvider(ServiceConfigurations.DialogServiceUrl);

        #region HTTP GET

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<MessageDto>>> GetMessages(Guid userId, Guid dialogId, Int32? offset, Int32 count)
        {
            IReadOnlyList<Message> messages = await _messageApiProvider.GetMessages(dialogId, offset ?? 0, count);

            IReadOnlyList<User> users = await _profileApiProvider.GetUsersPreview(messages.Select(k => k.AuthorId));

            IReadOnlyList<MessageDto> dto =  messages
                .Zip(users, (message, user) => MessageDto.FromMessageAndUser(user, message))
                .ToList();

            return Ok(dto);
        }

        #endregion

        #region HTTP POST

        [HttpPost]
        public async Task<ActionResult<MessageDto>> SendMessage([FromQuery] Guid dialogId, Guid authorId, [FromBody] String text)
        {
            await _dialogApiProvider.SendMessage(dialogId, authorId, text);

            return Ok();
        }

        #endregion
    }
}