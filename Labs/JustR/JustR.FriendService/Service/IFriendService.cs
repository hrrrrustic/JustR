using System;
using System.Collections.Generic;
using JustR.Models.Dto;
using JustR.Models.Entity;

namespace JustR.FriendService.Service
{
    public interface IFriendService
    {
        List<Guid> GetFriends(Guid userId);
        Relationship CreateFriendRequest(Relationship request);
        Relationship UpdateFriendRequest(Relationship request);
        void DeleteFriend(Relationship relationship);
    }
}