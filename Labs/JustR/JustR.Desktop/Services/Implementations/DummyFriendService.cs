using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Threading.Tasks;
using JustR.Desktop.Services.Abstractions;
using JustR.Models.Dto;
using JustR.Models.Enum;

namespace JustR.Desktop.Services.Implementations
{
    public class DummyFriendService : IFriendService
    {
        private static readonly List<FriendRequestDto> _requests = new List<FriendRequestDto>();
        private static readonly List<FriendDto> _friends = new List<FriendDto>
        {
            new FriendDto
            {
                Avatar = SampleData.SampleData.Zeleniy.Avatar,
                FirstName = SampleData.SampleData.Zeleniy.FirstName,
                UserId = SampleData.SampleData.Zeleniy.UserId
            }
            ,
            new FriendDto
            {
                Avatar = SampleData.SampleData.Sergey.Avatar,
                FirstName = SampleData.SampleData.Sergey.FirstName,
                UserId = SampleData.SampleData.Sergey.UserId
            },
            new FriendDto
            {
                Avatar = SampleData.SampleData.Katya.Avatar,
                FirstName = SampleData.SampleData.Katya.FirstName,
                UserId = SampleData.SampleData.Katya.UserId
            },
            new FriendDto
            {
                Avatar = SampleData.SampleData.Maksim.Avatar,
                FirstName = SampleData.SampleData.Maksim.FirstName,
                UserId = SampleData.SampleData.Maksim.UserId
            }
        };
        
        public async Task<List<FriendDto>> GetFriendsAsync(Guid userId)
        {
            return _friends;
        }

        public Task DeleteFriend(FriendRequestDto dto)
        {
            throw new NotImplementedException();
        }

        public Task CreateFriendRequestAsync(FriendRequestDto dto)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteFriend(Guid friendId)
        {
            var friend = _friends.Find(k => k.UserId == friendId);

            if (friend is null)
                return;

            _friends.Remove(friend);
        }

        public async Task CreateFriendRequestAsync(Guid secondUserId)
        {
            SampleData.SampleData.Person currentUser = UserInfo.CurrentUser;
            if(_requests.Any(k =>
                k.FirstUserId == currentUser.UserId && k.SecondUserId == secondUserId &&
                k.State == RelationshipState.OutputFriendRequest))
                return;

            _requests.Add(new FriendRequestDto
            {
                FirstUserId = currentUser.UserId,
                SecondUserId = secondUserId,
                State = RelationshipState.OutputFriendRequest
            });
        }

        Task<List<UserPreviewDto>> IFriendService.GetFriendsAsync(Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}