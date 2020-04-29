using System;
using System.Collections.Generic;
using JustR.Models.Entity;
using SqlKata.Compilers;

namespace JustR.FriendService.Repository
{
    public class FriendRepository : IFriendRepository
    {
        private readonly Compiler _sqlCompiler;

        public FriendRepository(Compiler sqlCompiler)
        {
            _sqlCompiler = sqlCompiler;
        }

        public FriendRequest CreateFriendRequest(FriendRequest request)
        {
            throw new NotImplementedException();
        }

        public List<Guid> ReadUserFriends(Guid userId)
        {
            throw new NotImplementedException();
        }

        public FriendRequest UpdateFriendRequest(FriendRequest request)
        {
            throw new NotImplementedException();
        }

        public void DeleteFriend(FriendRequest request)
        {
            throw new NotImplementedException();
        }
    }
}