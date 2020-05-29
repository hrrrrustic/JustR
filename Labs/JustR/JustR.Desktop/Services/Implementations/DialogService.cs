using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JustR.Desktop.Services.Abstractions;
using JustR.Models.Dto;
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
                .AddParameter("userId", userId, ParameterType.QueryString)
                .AddParameter("offset", 0, ParameterType.QueryString)
                .AddParameter("count", 15, ParameterType.QueryString);

            var response = await _restClient.GetAsync<List<DialogPreviewDto>>(request);

            return response;
        }

        public async Task<DialogInfoDto> GetDialogInfoAsync(Guid dialogId, Guid userId)
        {
            var request = new RestRequest("Dialog");
            request
                .AddParameter("dialogId", dialogId, ParameterType.QueryString)
                .AddParameter("userId", userId, ParameterType.QueryString);
            
            var info = await  _restClient.GetAsync<DialogInfoDto>(request);

            return info;
        }

        public async Task<Guid> GetDialogIdAsync(Guid firstUserId, Guid secondUserId)
        {
            var request = new RestRequest("Dialog/id");
            request
                .AddParameter("firstUserId", firstUserId, ParameterType.QueryString)
                .AddParameter("secondUserId", secondUserId, ParameterType.QueryString);

            var id = await _restClient.GetAsync<Guid>(request);

            return id;
        }

        public async Task<DialogInfoDto> CreateDialogAsync(DialogPreviewDto newDialog)
        {
            var request = new RestRequest("Dialog");
            request
                .AddParameter("firstUserId", newDialog.InterlocutorPreview.UserId, ParameterType.QueryString)
                .AddParameter("secondUserId", UserInfo.CurrentUser.UserId, ParameterType.QueryString);


            var response = await _restClient.PostAsync<DialogInfoDto>(request);

            return response;

        }

        public async Task UpdateDialogLastMessageInfo(Guid dialogId, String message, DateTime time)
        {
            throw new NotImplementedException();
        }
    }
}