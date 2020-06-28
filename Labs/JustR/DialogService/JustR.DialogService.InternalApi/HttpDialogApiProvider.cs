using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JustR.Core.Entity;
using JustR.Core.Extensions;
using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;

namespace JustR.DialogService.InternalApi
{
    public class HttpDialogApiProvider : IDialogApiProvider
    {
        private readonly IRestClient _restClient;

        public HttpDialogApiProvider(String baseUrl)
        {
            _restClient = new RestClient(baseUrl).UseNewtonsoftJson();
        }

        public async Task<Guid> GetDialogId(Guid firstUserId, Guid secondUserId)
        {
            IRestRequest request = new RestRequest("id")
                .AddQueryParameter("firstUserId", firstUserId)
                .AddQueryParameter("secondUserId", secondUserId);

            Guid id = await _restClient.GetAsync<Guid>(request);

            return id;
        }

        public async Task<IReadOnlyList<Dialog>> GetDialogsPreview(Guid userId, Int32 count, Int32 offset)
        {
            IRestRequest request = new RestRequest("preview")
                .AddQueryParameter("userId", userId)
                .AddQueryParameter("count", count)
                .AddQueryParameter("offset", offset);

            IReadOnlyList<Dialog> dialogs = await _restClient.GetAsync<List<Dialog>>(request);

            return dialogs;
        }

        public async Task<Dialog> GetDialog(Guid dialogId)
        {
            IRestRequest request = new RestRequest()
                .AddQueryParameter("dialogId", dialogId);

            Dialog dialog = await _restClient.GetAsync<Dialog>(request);

            return dialog;
        }

        public async Task<Dialog> CreateDialog(Guid firstUserId, Guid secondUserId)
        {
            IRestRequest request = new RestRequest()
                .AddQueryParameter("firstUserId", firstUserId)
                .AddQueryParameter("secondUserId", secondUserId);

            Dialog newDialog = await _restClient.PostAsync<Dialog>(request);

            return newDialog;
        }

        public async Task SendMessage(Guid dialogId, Guid authorId, String text)
        {
            IRestRequest request = new RestRequest("message")
                .AddQueryParameter("dialogId", dialogId)
                .AddQueryParameter("authorId", authorId)
                .AddJsonBody(text);

            // TODO : Хендлить ответ нормально
            await _restClient.PostAsync<Object>(request);
        }
    }
}
