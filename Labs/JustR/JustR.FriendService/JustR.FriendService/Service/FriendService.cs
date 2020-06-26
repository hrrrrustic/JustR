using System;
using System.Collections.Generic;
using JustR.FriendService.Repository;
using JustR.Models.Entity;

namespace JustR.FriendService.Service
{
    public class FriendService : IFriendService
    {
        private readonly IFriendRepository _friendRepository;

        public FriendService(IFriendRepository friendRepository)
        {
            _friendRepository = friendRepository;
        }

        public IReadOnlyList<Guid> GetFriends(Guid userId)
        {
            return _friendRepository.ReadUserFriends(userId);
        }

        public Relationship CreateFriendRequest(Relationship request)
        {
            return _friendRepository.CreateFriendRequest(request);
        }

        public Relationship UpdateFriendRequest(Relationship request)
        {
            return _friendRepository.UpdateFriendRequest(request);
        }

        public void DeleteFriend(Relationship relationship)
        {
            _friendRepository.DeleteFriend(relationship);
        }
    }
}