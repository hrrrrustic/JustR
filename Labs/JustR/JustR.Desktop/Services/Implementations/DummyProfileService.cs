using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Documents;
using JustR.Desktop.Services.Abstractions;
using JustR.Models.Dto;

namespace JustR.Desktop.Services.Implementations
{
    public class DummyProfileService : IProfileService
    {
        private static readonly List<UserProfileDto> Profiles = new List<UserProfileDto>
        {
            new UserProfileDto
            {
                Avatar = SampleData.SampleData.Katya.Avatar,
                UniqueTag = SampleData.SampleData.Katya.UniqueTag,
                UserName = SampleData.SampleData.Katya.Name,
                UserId = SampleData.SampleData.Katya.UserId
            },
            new UserProfileDto
            {
                Avatar = SampleData.SampleData.Maksim.Avatar,
                UniqueTag = SampleData.SampleData.Maksim.UniqueTag,
                UserName = SampleData.SampleData.Maksim.Name,
                UserId = SampleData.SampleData.Maksim.UserId
            },
            new UserProfileDto
            {
                Avatar = SampleData.SampleData.Zeleniy.Avatar,
                UniqueTag = SampleData.SampleData.Zeleniy.UniqueTag,
                UserName = SampleData.SampleData.Zeleniy.Name,
                UserId = SampleData.SampleData.Zeleniy.UserId
            },
            new UserProfileDto
            {
                Avatar = SampleData.SampleData.Sergey.Avatar,
                UniqueTag = SampleData.SampleData.Sergey.UniqueTag,
                UserName = SampleData.SampleData.Sergey.Name,
                UserId = SampleData.SampleData.Sergey.UserId
            },

        };

        public async Task<UserPreviewDto> GetProfilePreviewAsync(Guid userId)
        {
            var profile = Profiles.Single(k => k.UserId == userId);
            return new UserPreviewDto
            {
                Avatar = profile.Avatar,
                UniqueTag = profile.UniqueTag,
                UserName = profile.UserName,
                UserId = profile.UserId
            };
        }

        public async Task<UserProfileDto> GetProfileAsync(Guid userId)
        {
            return Profiles.Single(k => k.UserId == userId);
        }
    }
}