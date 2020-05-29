using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JustR.Models.Dto;
using JustR.Models.Entity;
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
        private readonly RestClient _messageClient = new RestClient(ServiceConfigurations.MessageServiceUri);

        private readonly RestClient _profileClient = new RestClient(ServiceConfigurations.ProfileServiceUri);

        private readonly RestClient _dialogClient = new RestClient(ServiceConfigurations.DialogServiceUri);

        public MessageController()
        {
            _messageClient.UseNewtonsoftJson();
            _profileClient.UseNewtonsoftJson();
            _dialogClient.UseNewtonsoftJson();
        }

        [HttpGet]
        public async Task<ActionResult<List<MessageDto>>> GetMessages(Guid userId, Guid dialogId, Int32? offset, Int32 count)
        {
            var request = new RestRequest("all");
            request
                .AddParameter("userId", userId, ParameterType.QueryString)
                .AddParameter("dialogId", dialogId, ParameterType.QueryString)
                .AddParameter("offset", offset ?? 0, ParameterType.QueryString)
                .AddParameter("count", count, ParameterType.QueryString);

            var messages = await _messageClient.GetAsync<List<Message>>(request);
            request = new RestRequest("preview");

            List<MessageDto> result = new List<MessageDto>(messages.Count);
            foreach (Message message in messages)
            {
                request.AddParameter("userId", message.AuthorId, ParameterType.QueryString);
                var user = await _profileClient.GetAsync<User>(request);

                MessageDto dto = new MessageDto
                {
                    DialogId = message.DialogId,
                    MessageText = message.MessageText,
                    SendDate = message.SendDate,
                    Sender = UserPreviewDto.FromUser(user)
                };
                result.Add(dto);
            }

            return Ok(result);
        }
        
        [HttpPost]
        public async Task<ActionResult<MessageDto>> SendMessage([FromQuery] Guid dialogId, Guid authorId, String text)
        {
            var request = new RestRequest("message");
            request
                .AddParameter("dialogId", dialogId, ParameterType.QueryString)
                .AddParameter("authorId", authorId, ParameterType.QueryString)
                .AddParameter("text", text, ParameterType.QueryString);

            await _dialogClient.PostAsync<OkResult>(request);

            return Ok();

        }
    }
}