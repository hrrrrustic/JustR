using System;
using System.Collections.Generic;
using JustR.Models.Entity;

namespace JustR.FriendService.Service
{
    public interface IFriendService
    {
        IReadOnlyList<Guid> GetFriends(Guid userId);
        Relationship CreateFriendRequest(Relationship request);
        Relationship UpdateFriendRequest(Relationship request);
        void DeleteFriend(Guid firstUserId, Guid secondUserId);
    }
}