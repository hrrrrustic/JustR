using System;
using System.Threading.Tasks;
using JustR.ClientRelatedShare.Dto;
using JustR.Core.Entity;
using JustR.Core.Extensions;
using JustR.Desktop.Services.Abstractions;
using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;

namespace JustR.Desktop.Services.Implementations
{
    public class ProfileService : IProfileService
    {
        private readonly IRestClient _restClient = new RestClient(GatewayConfiguration.ApiGatewaySource).UseNewtonsoftJson();

        public async Task<UserPreviewDto> GetProfilePreviewAsync(Guid userId)
        {
            IRestRequest request = new RestRequest("Profile/preview")
                .AddQueryParameter("userId", userId);

            UserPreviewDto response = await _restClient.GetAsync<UserPreviewDto>(request);

            return response;
        }

        public Task<UserProfileDto> GetProfileAsync(Guid userId)
        {
            throw new NotImplementedException();
        }

        public async Task<User> UpdateProfile(User user)
        {
            IRestRequest request = new RestRequest("Profile")
                .AddJsonBody(user, "application/json");

            User response = await _restClient.PutAsync<User>(request);

            return response;
        }

        public async Task<UserPreviewDto> SimpleLogin(String userTag)
        {
            IRestRequest request = new RestRequest("Profile/login")
                .AddQueryParameter("userTag", userTag);

            UserPreviewDto profile = await _restClient.GetAsync<UserPreviewDto>(request);

            return profile;
        }
    }
}