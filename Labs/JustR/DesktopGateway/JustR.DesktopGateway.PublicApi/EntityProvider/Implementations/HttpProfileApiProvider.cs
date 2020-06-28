using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JustR.ClientRelatedShare.Dto;
using JustR.Core.Entity;
using JustR.Core.Extensions;
using JustR.DesktopGateway.PublicApi.EntityProvider.Abstractions;
using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;

namespace JustR.DesktopGateway.PublicApi.EntityProvider.Implementations
{
    public class HttpProfileApiProvider : IProfileApiProvider
    {
        private readonly IRestClient _restClient;

        internal HttpProfileApiProvider(String baseUrl)
        {
            _restClient = new RestClient(baseUrl).UseNewtonsoftJson();
        }
        public Task<UserProfileDto> GetUserProfile(Guid userId)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<UserPreviewDto>> SearchUser(String query)
        {
            IRestRequest request = new RestRequest("Profile/search")
                .AddQueryParameter("query", query);

            IReadOnlyList<UserPreviewDto> response = await _restClient.GetAsync<List<UserPreviewDto>>(request);

            return response;
        }

        public async Task<UserPreviewDto> GetUserPreview(Guid userId)
        {
            IRestRequest request = new RestRequest("Profile/preview")
                .AddQueryParameter("userId", userId);

            UserPreviewDto response = await _restClient.GetAsync<UserPreviewDto>(request);

            return response;
        }

        public async Task<UserPreviewDto> SimpleAuth(String userTag)
        {
            IRestRequest request = new RestRequest("Profile/login")
                .AddQueryParameter("userTag", userTag);

            UserPreviewDto profile = await _restClient.GetAsync<UserPreviewDto>(request);

            return profile;
        }

        public async Task<User> UpdateUserProfile(User newUserProfile)
        {
            IRestRequest request = new RestRequest("Profile")
                .AddJsonBody(newUserProfile);

            User response = await _restClient.PutAsync<User>(request);

            return response;
        }
    }
}