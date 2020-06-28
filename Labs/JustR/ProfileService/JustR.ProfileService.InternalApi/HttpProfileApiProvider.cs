using JustR.Core.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JustR.Core.Extensions;
using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;
using static JustR.ProfileService.InternalApi.ProfileServiceHttpEndpoints;

namespace JustR.ProfileService.InternalApi
{
    public class HttpProfileApiProvider : IProfileApiProvider
    {
        public const String Root = "Login";
        private readonly IRestClient _restClient;

        public HttpProfileApiProvider(String baseUrl)
        {
            _restClient = new RestClient(baseUrl).UseNewtonsoftJson();
        }
        public async Task<User> GetUserProfile(Guid userId)
        {
            IRestRequest request = new RestRequest(ProfileServiceHttpEndpoints.GetUserProfile)
                .AddQueryParameter("userId", userId);

            User user = await _restClient.GetAsync<User>(request);

            return user;
        }

        public async Task<User> GetUserPreview(Guid userId)
        {
            IRestRequest request = new RestRequest(ProfileServiceHttpEndpoints.GetUserPreview)
                .AddQueryParameter("userId", userId);

            User userPreview = await _restClient.GetAsync<User>(request);

            return userPreview;
        }

        public async Task<IReadOnlyList<User>> GetUsersPreview(IEnumerable<Guid> usersId)
        {
            IRestRequest request = new RestRequest(ProfileServiceHttpEndpoints.GetUsersPreview);

            foreach (Guid id in usersId)
                request.AddQueryParameter("usersId", id);

            IReadOnlyList<User> users = await _restClient.GetAsync<List<User>>(request);

            return users;
        }

        public async Task<IReadOnlyList<User>> SearchUser(String query)
        {
            IRestRequest request = new RestRequest(ProfileServiceHttpEndpoints.SearchUser)
                .AddQueryParameter("query", query);

            List<User> response = await _restClient.GetAsync<List<User>>(request);

            return response;
        }

        public async Task<User> UpdateUserProfile(User user)
        {
            IRestRequest request = new RestRequest()
                .AddJsonBody(user);

            User updatedProfile = await _restClient.PutAsync<User>(request);

            return updatedProfile;
        }

        public async Task<User> SimpleLogIn(String userTag)
        {
            IRestRequest request = new RestRequest(SimpleLogin)
                .AddQueryParameter("userTag", userTag);

            User response = await _restClient.GetAsync<User>(request);
            return response;
        }
    }
}
