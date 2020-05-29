using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Documents;
using JustR.Models.Dto;

namespace JustR.Desktop.Services.Abstractions
{
    public interface IFriendService
    {
        Task<List<UserPreviewDto>> GetFriendsAsync(Guid userId);
        Task DeleteFriend(FriendRequestDto dto);
        Task CreateFriendRequestAsync(FriendRequestDto dto);
    }
}