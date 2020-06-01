using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JustR.Core.Dto;
using JustR.Desktop.Services.Abstractions;
using JustR.Core.Extensions;
using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;

namespace JustR.Desktop.Services.Implementations
{
    public class DialogService : IDialogService
    {
        private readonly IRestClient _restClient =
            new RestClient(GatewayConfiguration.ApiGatewaySource)
                .UseNewtonsoftJson();

        public async Task<IReadOnlyList<DialogPreviewDto>> GetDialogsPreviewAsync(Guid userId)
        {
            IRestRequest request = new RestRequest("Dialog/all")
                .AddQueryParameter("userId", userId)
                .AddQueryParameter("offset", 0)
                .AddQueryParameter("count", 15);

            IReadOnlyList<DialogPreviewDto> response = await _restClient.GetAsync<List<DialogPreviewDto>>(request);

            return response;
        }

        public async Task<DialogInfoDto> GetDialogInfoAsync(Guid dialogId, Guid userId)
        {
            IRestRequest request = new RestRequest("Dialog")
                .AddQueryParameter("dialogId", dialogId)
                .AddQueryParameter("userId", userId);
            
            DialogInfoDto info = await  _restClient.GetAsync<DialogInfoDto>(request);
            
            return info;
        }

        public async Task<Guid> GetDialogIdAsync(Guid firstUserId, Guid secondUserId)
        {
            IRestRequest request = new RestRequest("Dialog/id")
                .AddQueryParameter("firstUserId", firstUserId)
                .AddQueryParameter("secondUserId", secondUserId);

            Guid dialogId = await _restClient.GetAsync<Guid>(request);

            return dialogId;
        }

        public async Task<DialogInfoDto> CreateDialogAsync(DialogPreviewDto newDialog)
        {
            IRestRequest request = new RestRequest("Dialog")
                .AddQueryParameter("firstUserId", UserInfo.CurrentUser.UserId)
                .AddQueryParameter("secondUserId", newDialog.InterlocutorPreview.UserId);

            DialogInfoDto dialogInfo = await _restClient.PostAsync<DialogInfoDto>(request);

            return dialogInfo;

        }
    }
}