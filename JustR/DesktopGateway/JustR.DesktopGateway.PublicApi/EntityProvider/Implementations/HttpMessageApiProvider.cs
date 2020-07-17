using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JustR.ClientRelatedShare.Dto;
using JustR.Core.Extensions;
using JustR.DesktopGateway.PublicApi.EntityProvider.Abstractions;
using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;

namespace JustR.DesktopGateway.PublicApi.EntityProvider.Implementations
{
    public class HttpMessageApiProvider : IMessageApiProvider
    {
        private readonly IRestClient _restClient;

        internal HttpMessageApiProvider(String baseUrl)
        {
            _restClient = new RestClient(baseUrl).UseNewtonsoftJson();
        }

        public async Task<IReadOnlyList<MessageDto>> GetMessages(Guid userId, Guid dialogId, Int32? offset, Int32 count)
        {
            //TODO : Названия аргументов надо бы как-то засинкать с контроллерами
            RestRequest request = new RestRequest(DesktopGatewayHttpEndpoints.MessageEndpoints.GetMessages);
            request
                .AddQueryParameter("userId", userId)
                .AddQueryParameter("dialogId", dialogId)
                .AddQueryParameter("offset", 0)
                .AddQueryParameter("count", 100);

            List<MessageDto> res = await _restClient.GetAsync<List<MessageDto>>(request);

            return res;
        }

        public async Task<MessageDto> SendMessage(Guid dialogId, Guid authorId, String text)
        {
            IRestRequest request = new RestRequest(DesktopGatewayHttpEndpoints.MessageEndpoints.SendMessage)
                .AddQueryParameter("dialogId", dialogId)
                .AddQueryParameter("authorId", authorId)
                .AddJsonBody(text);

            return await _restClient.PostAsync<MessageDto>(request);
        }
    }
}