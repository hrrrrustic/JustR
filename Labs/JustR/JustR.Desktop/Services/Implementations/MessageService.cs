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
        private readonly IRestClient _restClient =
            new RestClient(GatewayConfiguration.ApiGatewaySource)
                .UseNewtonsoftJson();

        public async Task<IReadOnlyList<MessageDto>> GetMessagesAsync(Guid dialogId, Guid userId)
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
            IRestRequest request = new RestRequest("Message")
                .AddQueryParameter("dialogId", message.DialogId)
                .AddQueryParameter("authorId", message.Sender.UserId)
                .AddJsonBody(message.MessageText);

            //TODO : Опять же просто await куда-то там не оч
            await _restClient.PostAsync<MessageDto>(request);
        }
    }
}