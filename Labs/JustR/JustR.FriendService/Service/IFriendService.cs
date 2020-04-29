using System;
using System.Collections.Generic;
using JustR.Models.Dto;
using JustR.Models.Entity;

namespace JustR.FriendService.Service
{
    public interface IFriendService
    {
        List<Guid> GetFriends(Guid userId);
        FriendRequestDto CreateFriendRequest(FriendRequestDto requestDto);
        FriendRequestDto UpdateFriendRequest(FriendRequestDto requestDto);
        void DeleteFriend(Guid userId, Guid friendId);
    }
}