using JustR.Models.Entity;
using System;
using System.Collections.Generic;

namespace JustR.FriendService.InternalApi
{
    public interface IFriendApiProvider
    {
        IReadOnlyList<Guid> GetUserFriends(Guid userId);
        Relationship CreateFriendRequest(Relationship relationship);
        // TODO : Кажется, я даже не использую это
        Relationship CreateFriendResponse(Relationship relationship);
        void DeleteFriend(Relationship relationship);
    }
}