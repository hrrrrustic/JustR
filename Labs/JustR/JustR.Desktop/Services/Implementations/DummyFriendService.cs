using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JustR.Desktop.Services.Abstractions;
using JustR.Models.Dto;

namespace JustR.Desktop.Services.Implementations
{
    public class DummyFriendService : IFriendService
    {
        private static readonly List<FriendDto> _friends = new List<FriendDto>
        {
            new FriendDto
            {
                Avatar = SampleData.SampleData.Zeleniy.Avatar,
                Name = SampleData.SampleData.Zeleniy.Name,
                UserId = SampleData.SampleData.Zeleniy.UserId
            }
            ,
            new FriendDto
            {
                Avatar = SampleData.SampleData.Sergey.Avatar,
                Name = SampleData.SampleData.Sergey.Name,
                UserId = SampleData.SampleData.Sergey.UserId
            },
            new FriendDto
            {
                Avatar = SampleData.SampleData.Katya.Avatar,
                Name = SampleData.SampleData.Katya.Name,
                UserId = SampleData.SampleData.Katya.UserId
            },
            new FriendDto
            {
                Avatar = SampleData.SampleData.Maksim.Avatar,
                Name = SampleData.SampleData.Maksim.Name,
                UserId = SampleData.SampleData.Maksim.UserId
            }
        };
        public async Task<List<FriendDto>> GetFriendsAsync(Guid userId)
        {
            return _friends;
        }
    }
}