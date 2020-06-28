using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JustR.ClientRelatedShare.Dto;

namespace JustR.DesktopGateway.PublicApi.EntityProvider
{
    public interface IFriendApiProvider
    {
        Task<IReadOnlyList<UserPreviewDto>> GetUserFriends(Guid userId);
        Task<FriendRequestDto> CreateFriendRequest(FriendRequestDto dto);
        Task<FriendRequestDto> CreateFriendResponse(FriendRequestDto dto);
        void DeleteFriend(Guid userId, Guid secondUserId);
    }
}