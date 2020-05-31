using System;
using System.Collections.Generic;
using JustR.Models.Entity;

namespace JustR.FriendService.Repository
{
    public interface IFriendRepository
    {
        Relationship CreateFriendRequest(Relationship request);
        IReadOnlyList<Guid> ReadUserFriends(Guid userId);
        Relationship UpdateFriendRequest(Relationship request);
        void DeleteFriend(Relationship request);
    }
}