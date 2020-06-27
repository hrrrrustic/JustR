using System;
using System.Collections.Generic;
using JustR.Models.Entity;

namespace JustR.FriendService.InternalApi
{
    public class HttpFriendApiProvider : IFriendApiProvider
    {
        public IReadOnlyList<Guid> GetUserFriends(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Relationship CreateFriendRequest(Relationship relationship)
        {
            throw new NotImplementedException();
        }

        public Relationship CreateFriendResponse(Relationship relationship)
        {
            throw new NotImplementedException();
        }

        public void DeleteFriend(Relationship relationship)
        {
            throw new NotImplementedException();
        }
    }
}
