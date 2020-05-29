using System;
using System.Collections.Generic;
using System.Linq;
using JustR.Models.Entity;
using JustR.Models.Enum;

namespace JustR.FriendService.Repository
{
    public class DummyFriendRepository : IFriendRepository
    {
        private static List<Relationship> _requests = new List<Relationship>()
        {
            new Relationship
            {
                FirstUserId = Guid.Parse("5B77A766-7B44-4E1B-BAF9-083713D1ABA3"),
                SecondUserId = Guid.Parse("8E924714-8E37-4AD4-81E1-80F691DEAD10"),
                State = RelationshipState.Friend
            }
        };

        public Relationship CreateFriendRequest(Relationship request)
        {
            _requests.Add(request);
            return request;
        }

        public List<Guid> ReadUserFriends(Guid userId)
        {
            return _requests
                .Where(k => k.FirstUserId == userId)
                .Where(k => k.State == RelationshipState.Friend)
                .Select(k => k.SecondUserId)
                .Union(_requests
                    .Where(k => k.SecondUserId == userId)
                    .Where(k => k.State == RelationshipState.Friend)
                    .Select(k => k.SecondUserId))
                .ToList();
        }

        public Relationship UpdateFriendRequest(Relationship request)
        {
            var res = _requests.Find(
                k => k.FirstUserId == request.FirstUserId && k.SecondUserId == request.SecondUserId);

            if (res is null)
                throw new Exception();

            res.State = request.State;

            return res;
        }

        public void DeleteFriend(Relationship request)
        {
            var res = _requests.Find(
                k => k.FirstUserId == request.FirstUserId && k.SecondUserId == request.SecondUserId);

            if (res is null)
                throw new Exception();

            _requests.Remove(res);
        }
    }
}