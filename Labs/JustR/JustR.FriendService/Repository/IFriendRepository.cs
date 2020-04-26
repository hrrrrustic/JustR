using System;
using System.Collections.Generic;
using JustR.Models.Entity;

namespace JustR.FriendService.Repository
{
    public interface IFriendRepository
    {
        FriendRequest CreateFriendRequest(FriendRequest request);
        List<User> ReadUserFriends(Guid userId);
        FriendRequest UpdateFriendRequest(FriendRequest request);
        void DeleteFriend(FriendRequest request);
    }
}