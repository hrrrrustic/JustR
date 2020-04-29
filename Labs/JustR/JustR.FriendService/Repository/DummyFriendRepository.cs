using System;
using System.Collections.Generic;
using System.Linq;
using JustR.Models.Entity;
using JustR.Models.Enum;

namespace JustR.FriendService.Repository
{
    public class DummyFriendRepository : IFriendRepository
    {
        private static List<FriendRequest> _requests = new List<FriendRequest>();

        public FriendRequest CreateFriendRequest(FriendRequest request)
        {
            _requests.Add(request);
            return request;
        }

        public List<Guid> ReadUserFriends(Guid userId)
        {
            return _requests
                .Where(k => k.FirstUserId == userId)
                .Where(k => k.State == FriendRequestState.Accepted)
                .Select(k => k.SecondUserId)
                .Union(_requests
                    .Where(k => k.SecondUserId == userId)
                    .Where(k => k.State == FriendRequestState.Accepted)
                    .Select(k => k.FirstUserId))
                .ToList();
        }

        public FriendRequest UpdateFriendRequest(FriendRequest request)
        {
            var res = _requests.Find(
                k => k.FirstUserId == request.FirstUserId && k.SecondUserId == request.SecondUserId);

            if (res is null)
                throw new Exception();

            res.State = request.State;

            return res;
        }

        public void DeleteFriend(FriendRequest request)
        {
            var res = _requests.Find(
                k => k.FirstUserId == request.FirstUserId && k.SecondUserId == request.SecondUserId);

            if (res is null)
                throw new Exception();

            _requests.Remove(res);
        }
    }
}