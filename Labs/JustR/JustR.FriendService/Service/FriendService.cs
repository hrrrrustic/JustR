using System;
using System.Collections.Generic;
using JustR.Models.Dto;

namespace JustR.FriendService.Service
{
    public class FriendService : IFriendService
    {
        public List<FriendRequestDto> GetFriends(Guid userId)
        {
            throw new NotImplementedException();
        }

        public FriendRequestDto CreateFriendRequest(FriendRequestDto requestDto)
        {
            throw new NotImplementedException();
        }

        public FriendRequestDto UpdateFriendRequest(FriendRequestDto requestDto)
        {
            throw new NotImplementedException();
        }

        public void DeleteFriend(Guid userId, Guid friendId)
        {
            throw new NotImplementedException();
        }
    }
}