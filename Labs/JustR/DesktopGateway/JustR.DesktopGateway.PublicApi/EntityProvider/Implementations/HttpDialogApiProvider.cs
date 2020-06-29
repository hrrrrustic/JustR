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
    public class HttpDialogApiProvider : IDialogApiProvider
    {
        private readonly IRestClient _restClient;

        internal HttpDialogApiProvider(String baseUrl)
        {
            _restClient = new RestClient(baseUrl).UseNewtonsoftJson();
        }
        public async Task<Guid> GetDialogId(Guid firstUserId, Guid secondUserId)
        {
            IRestRequest request = new RestRequest(DesktopGatewayHttpEndpoints.DialogEndpoints.GetDialogId)
                .AddQueryParameter("firstUserId", firstUserId)
                .AddQueryParameter("secondUserId", secondUserId);

            Guid dialogId = await _restClient.GetAsync<Guid>(request);

            return dialogId;
        }

        public async Task<IReadOnlyList<DialogPreviewDto>> GetDialogs(Guid userId, Int32? offset, Int32 count)
        {
            IRestRequest request = new RestRequest(DesktopGatewayHttpEndpoints.DialogEndpoints.GetDialogs)
                .AddQueryParameter("userId", userId)
                .AddQueryParameter("offset", 0)
                .AddQueryParameter("count", 15);

            IReadOnlyList<DialogPreviewDto> response = await _restClient.GetAsync<List<DialogPreviewDto>>(request);

            return response;
        }

        public async Task<DialogInfoDto> GetDialog(Guid dialogId, Guid userId)
        {
            IRestRequest request = new RestRequest(DesktopGatewayHttpEndpoints.DialogEndpoints.GetDialog)
                .AddQueryParameter("dialogId", dialogId)
                .AddQueryParameter("userId", userId);

            DialogInfoDto info = await _restClient.GetAsync<DialogInfoDto>(request);

            return info;
        }

        public async Task<DialogInfoDto> CreateDialog(Guid firstUserId, Guid secondUserId)
        {
            IRestRequest request = new RestRequest(DesktopGatewayHttpEndpoints.DialogEndpoints.CreateDialog)
                .AddQueryParameter("firstUserId", firstUserId)
                .AddQueryParameter("secondUserId", secondUserId);

            DialogInfoDto dialogInfo = await _restClient.PostAsync<DialogInfoDto>(request);

            return dialogInfo;
        }
    }
}