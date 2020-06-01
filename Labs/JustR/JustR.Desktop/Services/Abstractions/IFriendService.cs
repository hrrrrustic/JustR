using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Documents;
using JustR.Core.Dto;

namespace JustR.Desktop.Services.Abstractions
{
    public interface IFriendService
    {
        Task<IReadOnlyList<UserPreviewDto>> GetFriendsAsync(Guid userId);
        Task DeleteFriend(FriendRequestDto dto);
        Task CreateFriendRequestAsync(FriendRequestDto dto);
    }
}