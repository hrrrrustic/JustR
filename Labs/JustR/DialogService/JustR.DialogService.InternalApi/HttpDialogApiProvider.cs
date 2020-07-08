using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using JustR.Core.Entity;
using Microsoft.AspNetCore.WebUtilities;

namespace JustR.DialogService.InternalApi
{
    public class HttpDialogApiProvider : IDialogApiProvider
    {
        private readonly HttpClient _client;

        public HttpDialogApiProvider(HttpClient client)
        {
            _client = client;
        }

        public async Task<Guid> GetDialogId(Guid firstUserId, Guid secondUserId)
        {
            String query = QueryHelpers.AddQueryString(DialogServiceHttpEndpoints.GetDialogId, "firstUserId",
                firstUserId.ToString());
            query = QueryHelpers.AddQueryString(query, "secondUserId", secondUserId.ToString());

            HttpResponseMessage response = await _client.GetAsync(query);

            Guid id = await response.Content.ReadAsAsync<Guid>();

            return id;
        }

        public async Task<IReadOnlyList<Dialog>> GetDialogsPreview(Guid userId, Int32 count, Int32 offset)
        {
            String query = QueryHelpers.AddQueryString(DialogServiceHttpEndpoints.GetDialogsPreview, "userId",
                userId.ToString());
            query = QueryHelpers.AddQueryString(query, "count", count.ToString());
            query = QueryHelpers.AddQueryString(query, "offset", offset.ToString());

            HttpResponseMessage response = await _client.GetAsync(query);

            IReadOnlyList<Dialog> dialogs = await response.Content.ReadAsAsync<List<Dialog>>();

            return dialogs;
        }

        public async Task<Dialog> GetDialog(Guid dialogId)
        {
            String query =
                QueryHelpers.AddQueryString(DialogServiceHttpEndpoints.GetDialog, "dialogId", dialogId.ToString());

            HttpResponseMessage response = await _client.GetAsync(query);

            Dialog dialog = await response.Content.ReadAsAsync<Dialog>();

            return dialog;
        }

        public async Task<Dialog> CreateDialog(Guid firstUserId, Guid secondUserId)
        {
            String query = QueryHelpers.AddQueryString(DialogServiceHttpEndpoints.CreateDialog, "firstUserId",
                firstUserId.ToString());
            query = QueryHelpers.AddQueryString(query, "secondUserId", secondUserId.ToString());

            HttpResponseMessage response = await _client.GetAsync(query);

            Dialog newDialog = await response.Content.ReadAsAsync<Dialog>();

            return newDialog;
        }

        public async Task SendMessage(Guid dialogId, Guid authorId, String text)
        {
            String query = QueryHelpers.AddQueryString(DialogServiceHttpEndpoints.SendMessage, "dialogId",
                dialogId.ToString());
            query = QueryHelpers.AddQueryString(query, "authorId", authorId.ToString());

            // TODO : Хендлить ответ нормально
            HttpResponseMessage response = await _client.PostAsJsonAsync(query, text);
        }
    }
}