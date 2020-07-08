using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JustR.ClientRelatedShare.Dto;

namespace JustR.Desktop.Services.Abstractions
{
    public interface IFriendService
    {
        Task<IReadOnlyList<UserPreviewDto>> GetFriendsAsync(Guid userId);
        Task DeleteFriend(FriendRequestDto dto);
        Task CreateFriendRequestAsync(FriendRequestDto dto);
    }
}