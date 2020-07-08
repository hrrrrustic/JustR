using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JustR.ClientRelatedShare.Dto;
using JustR.Desktop.Services.Abstractions;
using JustR.DesktopGateway.PublicApi;

namespace JustR.Desktop.Services.Implementations
{
    public class FriendService : IFriendService
    {
        private readonly IDesktopGatewayApiProvider _desktopGatewayApiProvider =
            new HttpDesktopGatewayApiProvider(GatewayConfiguration.ApiGatewaySource);

        public async Task<IReadOnlyList<UserPreviewDto>> GetFriendsAsync(Guid userId)
        {
            return await _desktopGatewayApiProvider.FriendEntityApiProvider.GetUserFriends(userId);
        }

        public async Task DeleteFriend(FriendRequestDto dto)
        {
            await _desktopGatewayApiProvider.FriendEntityApiProvider.DeleteFriend(dto.FirstUserId, dto.SecondUserId);
        }

        public async Task CreateFriendRequestAsync(FriendRequestDto dto)
        {
            await _desktopGatewayApiProvider.FriendEntityApiProvider.CreateFriendRequest(dto);
        }
    }
}