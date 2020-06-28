using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JustR.Core.Entity;
using JustR.Core.Extensions;
using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;

namespace JustR.MessageService.InternalApi
{
    public class HttpMessageApiProvider : IMessageApiProvider
    {
        private readonly IRestClient _restClient;

        public HttpMessageApiProvider(String baseUrl)
        {
            _restClient = new RestClient(baseUrl).UseNewtonsoftJson();
        }

        public async Task<IReadOnlyList<Message>> GetMessages(Guid dialogId, Int32 offset, Int32 count)
        {
            IRestRequest request = new RestRequest(MessageServiceHttpEndpoints.GetMessages)
                .AddQueryParameter("dialogId", dialogId)
                .AddQueryParameter("offset", offset)
                .AddQueryParameter("count", count);

            IReadOnlyList<Message> messages = await _restClient.GetAsync<IReadOnlyList<Message>>(request);

            return messages;
        }

        public async Task<Message> SendMessage(Guid userId, Guid dialogId, Guid receiverId, String text)
        {
            IRestRequest request = new RestRequest(MessageServiceHttpEndpoints.SendMessage)
                .AddQueryParameter("userId", userId)
                .AddQueryParameter("dialogId", dialogId)
                .AddQueryParameter("receiverId", receiverId)
                .AddJsonBody(text);

            Message message = await _restClient.PostAsync<Message>(request);

            return message;
        }
    }
}
