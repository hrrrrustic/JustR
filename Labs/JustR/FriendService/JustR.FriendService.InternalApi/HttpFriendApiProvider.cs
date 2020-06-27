using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JustR.Core.Extensions;
using JustR.Models.Entity;
using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;

namespace JustR.FriendService.InternalApi
{
    public class HttpFriendApiProvider : IFriendApiProvider
    {
        private readonly IRestClient _restClient;

        public HttpFriendApiProvider(String baseUrl)
        {
            _restClient = new RestClient(baseUrl).UseNewtonsoftJson();
        }

        public async Task<IReadOnlyList<Guid>> GetUserFriends(Guid userId)
        {
            IRestRequest request = new RestRequest()
                .AddQueryParameter("userId", userId);

            IReadOnlyList<Guid> friendsId = await _restClient.GetAsync<List<Guid>>(request);

            return friendsId;
        }

        public async Task<Relationship> CreateFriendRequest(Relationship relationship)
        {
            IRestRequest request = new RestRequest()
                .AddJsonBody(relationship);

            relationship = await _restClient.PostAsync<Relationship>(request);

            return relationship;
        }

        public async Task<Relationship> CreateFriendResponse(Relationship relationship)
        {
            IRestRequest request = new RestRequest()
                .AddJsonBody(relationship);

            relationship = await _restClient.PutAsync<Relationship>(request);

            return relationship;
        }

        public void DeleteFriend(Relationship relationship)
        {
            throw new NotImplementedException();
        }
    }
}
