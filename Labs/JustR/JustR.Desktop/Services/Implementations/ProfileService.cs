using System;
using System.Threading.Tasks;
using JustR.ClientRelatedShare.Dto;
using JustR.Core.Entity;
using JustR.Core.Extensions;
using JustR.Desktop.Services.Abstractions;
using JustR.DesktopGateway.PublicApi;
using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;

namespace JustR.Desktop.Services.Implementations
{
    //TODO : Пофиксить названия в плане суффиксов Async и тд
    //TODO : Пофиксить в целом названия на слоях. Сейчас там 50 оттенков синонимов
    public class ProfileService : IProfileService
    {
        private readonly IDesktopGatewayApiProvider _desktopGatewayApiProvider =
            new HttpDesktopGatewayApiProvider(GatewayConfiguration.ApiGatewaySource);

        public async Task<UserPreviewDto> GetProfilePreviewAsync(Guid userId)
        {
            return await _desktopGatewayApiProvider.ProfileEntityApiProvider.GetUserPreview(userId);
        }

        public async Task<UserProfileDto> GetProfileAsync(Guid userId)
        {
            return await _desktopGatewayApiProvider.ProfileEntityApiProvider.GetUserProfile(userId);
        }

        public async Task<User> UpdateProfile(User user)
        {
            return await _desktopGatewayApiProvider.ProfileEntityApiProvider.UpdateUserProfile(user);
        }

        public async Task<User> SimpleLogin(String userTag)
        {
            return await _desktopGatewayApiProvider.ProfileEntityApiProvider.SimpleAuth(userTag);
        }
    }
}