using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using JustR.Core.Extensions;
using JustR.Models.Entity;
using Microsoft.AspNetCore.WebUtilities;
using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;

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
            String query = QueryHelpers.AddQueryString(FriendSerivceHttpEndpoints.GetUserFriends, "userId", userId.ToString());

            var response = await _client.GetAsync(query);

            IReadOnlyList<Guid> friendsId = await response.Content.ReadAsAsync<List<Guid>>();

            return friendsId;
        }

        public async Task<Relationship> CreateFriendRequest(Relationship relationship)
        {
            String query = FriendSerivceHttpEndpoints.CreateFriendRequest;

            var response = await _client.PostAsJsonAsync(query, relationship);

            relationship = await response.Content.ReadAsAsync<Relationship>();

            return relationship;
        }

        public async Task<Relationship> CreateFriendResponse(Relationship relationship)
        {
            String query = (FriendSerivceHttpEndpoints.CreateFriendResponse);

            var response = await _client.PutAsJsonAsync(query, relationship);

            relationship = await response.Content.ReadAsAsync<Relationship>();

            return relationship;
        }

        //TODO : Надо заимплементить
        public void DeleteFriend(Relationship relationship)
        {
            throw new NotImplementedException();
        }
    }
}
