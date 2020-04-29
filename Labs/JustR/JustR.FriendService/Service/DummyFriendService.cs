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

        public FriendRequestDto CreateFriendRequest(FriendRequestDto requestDto)
        {
            var res = _friendRepository.CreateFriendRequest(new FriendRequest
            {
                FirstUserId = requestDto.FirstUserId, SecondUserId = requestDto.SecondUserId, State = requestDto.State
            });
            return new FriendRequestDto
            {
                FirstUserId = res.FirstUserId,
                SecondUserId = res.SecondUserId,
                State = res.State
            };
        }

        public FriendRequestDto UpdateFriendRequest(FriendRequestDto requestDto)
        {
            var res = _friendRepository.UpdateFriendRequest(new FriendRequest
            {
                FirstUserId = requestDto.FirstUserId,
                SecondUserId = requestDto.SecondUserId,
                State = requestDto.State
            });
            return new FriendRequestDto
            {
                FirstUserId = res.FirstUserId,
                SecondUserId = res.SecondUserId,
                State = res.State
            };
        }

        public void DeleteFriend(Guid userId, Guid friendId)
        {
            _friendRepository.DeleteFriend(new FriendRequest{FirstUserId = userId, SecondUserId = friendId, State = FriendRequestState.Something1});
        }
    }
}