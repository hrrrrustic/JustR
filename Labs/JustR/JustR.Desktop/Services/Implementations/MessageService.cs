using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JustR.Core.Dto;
using JustR.Core.Extensions;
using JustR.Desktop.Services.Abstractions;
using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;

namespace JustR.Desktop.Services.Implementations
{
    public class MessageService : IMessageService
    {
        private readonly RestClient _restClient = new RestClient(GatewayConfiguration.ApiGatewaySource);

        public MessageService()
        {
            _restClient.UseNewtonsoftJson();
        }
        public async Task<List<MessageDto>> GetMessagesAsync(Guid dialogId, Guid userId)
        {
            var request = new RestRequest("Message");
            request
                .AddQueryParameter("userId", userId)
                .AddQueryParameter("dialogId", dialogId)
                .AddQueryParameter("offset", 0)
                .AddQueryParameter("count", 100);

            var res = await _restClient.GetAsync<List<MessageDto>>(request);

            return res;
        }

        public async Task SendMessage(MessageDto message)
        {
            var request = new RestRequest("Message");
            request
                .AddQueryParameter("dialogId", message.DialogId)
                .AddQueryParameter("authorId", message.Sender.UserId)
                .AddQueryParameter("text", message.MessageText);

            await _restClient.PostAsync<MessageDto>(request);
        }
    }
}