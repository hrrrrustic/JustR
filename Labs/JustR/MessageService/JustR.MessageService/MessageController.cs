using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JustR.Core.Entity;
using JustR.Core.Extensions;
using JustR.MessageService.InternalApi;
using JustR.MessageService.Service;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;

namespace JustR.MessageService
{
    [Route("api/[controller]")]
    [Consumes("application/json")]
    [Produces("application/json")]
    public class MessageController : Controller
    {
        private readonly IMessageService _messageService;

        private readonly IRestClient _notificationClient = new RestClient(ServiceConfiguration.NotificationServiceUrl).UseNewtonsoftJson();
        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        #region HTTP GET

        [HttpGet(MessageServiceHttpEndpoints.GetMessages)]
        public ActionResult<IReadOnlyList<Message>> GetMessages([FromQuery] Guid dialogId, Int32 offset, Int32 count)
        {
            IReadOnlyList<Message> messages = _messageService.GetMessages(dialogId, offset, count);

            return Ok(messages);
        }

        #endregion

        #region HTTP POST

        [HttpPost(MessageServiceHttpEndpoints.SendMessage)]
        public async Task<ActionResult<Message>> SendMessage([FromQuery] Guid userId, Guid dialogId, Guid receiverId, [FromBody] String text)
        {
            if (String.IsNullOrWhiteSpace(text))
                return BadRequest();

            Message sentMessage = _messageService.SendMessage(userId, dialogId, text);
            // TODO : Сделать у сервиса уведомлений тоже интернал апишку
            var request = new RestRequest("message")
                .AddQueryParameter("firstReceiverId", receiverId)
                .AddQueryParameter("secondReceiverId", userId)
                .AddJsonBody(sentMessage);
            
            // TODO : Object?
            await _notificationClient.PostAsync<Object>(request);

            return Ok(sentMessage);
        }

        #endregion
    }
}
