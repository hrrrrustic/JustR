using System;
using System.Threading.Tasks;
using JustR.Desktop.Annotations;
using JustR.Desktop.Services.Abstractions;
using JustR.Models.Dto;
using JustR.Models.Entity;
using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;

namespace JustR.Desktop.Services.Implementations
{
    public class ProfileService : IProfileService
    {
        private readonly RestClient _restClient = new RestClient(GatewayConfiguration.ApiGatewaySource);

        public ProfileService()
        {
            _restClient.UseNewtonsoftJson();
        }
        public async Task<UserPreviewDto> GetProfilePreviewAsync(Guid userId)
        {
            var request = new RestRequest("Profile/preview", Method.GET, DataFormat.Json).AddParameter("userId", userId);
            var response = await _restClient.GetAsync<UserPreviewDto>(request);
            return response;
        }

        public Task<UserProfileDto> GetProfileAsync(Guid userId)
        {
            
            throw new NotImplementedException();
        }

        public async Task<UserPreviewDto> SimpleLogin(String userTag)
        {
            var request = new RestRequest("Profile/login", Method.GET, DataFormat.Json)
                .AddParameter("userTag", userTag, ParameterType.QueryString);

            var profile = await _restClient.GetAsync<UserPreviewDto>(request);

            return profile;
        }
    }
}