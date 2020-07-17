using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using JustR.Models.Entity;
using Microsoft.AspNetCore.WebUtilities;

namespace JustR.FriendService.InternalApi
{
    public class HttpFriendApiProvider : IFriendApiProvider
    {
        private readonly HttpClient _client;

        public HttpFriendApiProvider(HttpClient client)
        {
            _client = client;
        }

        public async Task<IReadOnlyList<Guid>> GetUserFriends(Guid userId)
        {
            String query =
                QueryHelpers.AddQueryString(FriendSerivceHttpEndpoints.GetUserFriends, "userId", userId.ToString());

            HttpResponseMessage response = await _client.GetAsync(query);

            IReadOnlyList<Guid> friendsId = await response.Content.ReadAsAsync<List<Guid>>();

            return friendsId;
        }

        public async Task<Relationship> CreateFriendRequest(Relationship relationship)
        {
            String query = FriendSerivceHttpEndpoints.CreateFriendRequest;

            HttpResponseMessage response = await _client.PostAsJsonAsync(query, relationship);

            relationship = await response.Content.ReadAsAsync<Relationship>();

            return relationship;
        }

        public async Task<Relationship> CreateFriendResponse(Relationship relationship)
        {
            String query = FriendSerivceHttpEndpoints.CreateFriendResponse;

            HttpResponseMessage response = await _client.PutAsJsonAsync(query, relationship);

            relationship = await response.Content.ReadAsAsync<Relationship>();

            return relationship;
        }

        //TODO : Надо заимплементить. Update : Проверить, что работает
        public async Task DeleteFriend(Guid firstUserId, Guid secondUserId)
        {
            String query = QueryHelpers.AddQueryString(FriendSerivceHttpEndpoints.DeleteFriend, "firstUserId",
                firstUserId.ToString());
            query = QueryHelpers.AddQueryString(query, "secondUserId", secondUserId.ToString());

            await _client.DeleteAsync(query);
        }
    }
}