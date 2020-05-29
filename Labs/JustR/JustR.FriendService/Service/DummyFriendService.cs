using System;
using System.Collections.Generic;
using System.Linq;
using JustR.FriendService.Repository;
using JustR.Models.Dto;
using JustR.Models.Entity;
using JustR.Models.Enum;

namespace JustR.FriendService.Service
{
    public class DummyFriendService : IFriendService
    {
        private readonly IFriendRepository _friendRepository;
        public DummyFriendService(IFriendRepository friendRepository)
        {
            _friendRepository = friendRepository;
        }
        public List<Guid> GetFriends(Guid userId)
        {
            return _friendRepository.ReadUserFriends(userId);
        }

        public Relationship CreateFriendRequest(Relationship request)
        {
            var res = _friendRepository.CreateFriendRequest(new Relationship
            {
                FirstUserId = request.FirstUserId, SecondUserId = request.SecondUserId, State = request.State
            });
            return new Relationship
            {
                FirstUserId = res.FirstUserId,
                SecondUserId = res.SecondUserId,
                State = res.State
            };
        }

        public Relationship UpdateFriendRequest(Relationship request)
        {
            var res = _friendRepository.UpdateFriendRequest(new Relationship
            {
                FirstUserId = request.FirstUserId,
                SecondUserId = request.SecondUserId,
                State = request.State
            });
            return new Relationship
            {
                FirstUserId = res.FirstUserId,
                SecondUserId = res.SecondUserId,
                State = res.State
            };
        }

        public void DeleteFriend(Relationship relationship)
        {
            _friendRepository.DeleteFriend(new Relationship{FirstUserId = relationship.FirstUserId, SecondUserId = relationship.SecondUserId, State = RelationshipState.None});
        }
    }
}