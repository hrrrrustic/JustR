using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using JustR.Core.Entity;
using Microsoft.AspNetCore.WebUtilities;

namespace JustR.MessageService.InternalApi
{
    public class HttpMessageApiProvider : IMessageApiProvider
    {
        private readonly HttpClient _client;

        public HttpMessageApiProvider(HttpClient client)
        {
            _client = client;
        }       

        public async Task<IReadOnlyList<Message>> GetMessages(Guid dialogId, Int32 offset, Int32 count)
        {
            String query = QueryHelpers.AddQueryString(MessageServiceHttpEndpoints.GetMessages, "dialogId",
                dialogId.ToString());
            query = QueryHelpers.AddQueryString(query, "offset", offset.ToString());
            query = QueryHelpers.AddQueryString(query, "count", count.ToString());

            HttpResponseMessage response = await _client.GetAsync(query);

            IReadOnlyList<Message> messages = await response.Content.ReadAsAsync<List<Message>>();

            return messages;
        }

        public async Task<Message> SendMessage(Guid userId, Guid dialogId, Guid receiverId, String text)
        {
            String query =
                QueryHelpers.AddQueryString(MessageServiceHttpEndpoints.SendMessage, "userId", userId.ToString());
            query = QueryHelpers.AddQueryString(query, "dialogId", dialogId.ToString());
            query = QueryHelpers.AddQueryString(query, "receiverId", receiverId.ToString());

            HttpResponseMessage response = await _client.PostAsJsonAsync(query, text);

            Message message = await response.Content.ReadAsAsync<Message>();

            return message;
        }
    }
}