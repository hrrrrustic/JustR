using JustR.Models.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JustR.FriendService.InternalApi
{
    public interface IFriendApiProvider
    {
        Task<IReadOnlyList<Guid>> GetUserFriends(Guid userId);
        Task<Relationship> CreateFriendRequest(Relationship relationship);
        // TODO : Кажется, я даже не использую это
        Task<Relationship> CreateFriendResponse(Relationship relationship);
        void DeleteFriend(Relationship relationship);
    }
}