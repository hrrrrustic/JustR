using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JustR.Core.Dto;
using JustR.Core.Entity;
using JustR.Core.Extensions;
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
        private readonly IRestClient _messageClient =
            new RestClient(ServiceConfigurations.MessageServiceUri)
                .UseNewtonsoftJson();

        private readonly IRestClient _profileClient =
            new RestClient(ServiceConfigurations.ProfileServiceUri)
                .UseNewtonsoftJson();

        private readonly IRestClient _dialogClient =
            new RestClient(ServiceConfigurations.DialogServiceUri)
                .UseNewtonsoftJson();

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<MessageDto>>> GetMessages(Guid userId, Guid dialogId, Int32? offset, Int32 count)
        {
            IRestRequest request = new RestRequest("all")
                .AddQueryParameter("userId", userId)
                .AddQueryParameter("dialogId", dialogId)
                .AddQueryParameter("offset", offset ?? 0)
                .AddQueryParameter("count", count);

            IReadOnlyList<Message> messages = await _messageClient.GetAsync<IReadOnlyList<Message>>(request);

            request = new RestRequest("previews");

            foreach (Message message in messages)
                request.AddQueryParameter("usersId", message.AuthorId);

            IReadOnlyList<User> users = await _profileClient.GetAsync<List<User>>(request);

            IReadOnlyList<MessageDto> dto =  messages
                .Zip(users, (message, user) => MessageDto.FromMessageAndUser(user, message))
                .ToList();

            return Ok(dto);
        }
        
        [HttpPost]
        public async Task<ActionResult<MessageDto>> SendMessage([FromQuery] Guid dialogId, Guid authorId, String text)
        {
            IRestRequest request = new RestRequest("message")
                .AddQueryParameter("dialogId", dialogId)
                .AddQueryParameter("authorId", authorId)
                .AddQueryParameter("text", text);

            await _dialogClient.PostAsync<OkResult>(request);

            return Ok();
        }
    }
}