using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Documents;
using JustR.Desktop.Services.Abstractions;
using JustR.Models.Dto;
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
                .AddParameter("userId", userId, ParameterType.QueryString)
                .AddParameter("dialogId", dialogId, ParameterType.QueryString)
                .AddParameter("offset", 0, ParameterType.QueryString)
                .AddParameter("count", 100, ParameterType.QueryString);

            var res = await _restClient.GetAsync<List<MessageDto>>(request);

            return res;
        }

        public async Task SendMessage(MessageDto message)
        {
            var request = new RestRequest("Message");
            request
                .AddParameter("dialogId", message.DialogId, ParameterType.QueryString)
                .AddParameter("authorId", message.Sender.UserId, ParameterType.QueryString)
                .AddParameter("text", message.MessageText, ParameterType.QueryString);

            await _restClient.PostAsync<MessageDto>(request);

        }
    }
}