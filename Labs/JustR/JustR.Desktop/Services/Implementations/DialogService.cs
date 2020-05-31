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
        private readonly RestClient _restClient = new RestClient(GatewayConfiguration.ApiGatewaySource);

        public DialogService()
        {
            _restClient.UseNewtonsoftJson();
        }

        public async Task<List<DialogPreviewDto>> GetDialogsPreviewAsync(Guid userId)
        {
            var request = new RestRequest("Dialog/all");
            request
                .AddQueryParameter("userId", userId)
                .AddQueryParameter("offset", 0)
                .AddQueryParameter("count", 15);

            var response = await _restClient.GetAsync<List<DialogPreviewDto>>(request);

            return response;
        }

        public async Task<DialogInfoDto> GetDialogInfoAsync(Guid dialogId, Guid userId)
        {
            var request = new RestRequest("Dialog");
            request
                .AddQueryParameter("dialogId", dialogId)
                .AddQueryParameter("userId", userId);
            
            var info = await  _restClient.GetAsync<DialogInfoDto>(request);
            
            return info;
        }

        public async Task<Guid> GetDialogIdAsync(Guid firstUserId, Guid secondUserId)
        {
            var request = new RestRequest("Dialog/id");
            request
                .AddQueryParameter("firstUserId", firstUserId)
                .AddQueryParameter("secondUserId", secondUserId);

            var id = await _restClient.GetAsync<Guid>(request);

            return id;
        }

        public async Task<DialogInfoDto> CreateDialogAsync(DialogPreviewDto newDialog)
        {
            var request = new RestRequest("Dialog");
            request
                .AddQueryParameter("firstUserId", newDialog.InterlocutorPreview.UserId)
                .AddQueryParameter("secondUserId", UserInfo.CurrentUser.UserId);

            var response = await _restClient.PostAsync<DialogInfoDto>(request);

            return response;

        }
    }
}