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
            SampleData.SampleData.Katya.ToUserProfileDto(),
            SampleData.SampleData.Sergey.ToUserProfileDto(),
            SampleData.SampleData.Zeleniy.ToUserProfileDto(),
            SampleData.SampleData.Vova.ToUserProfileDto(),
            SampleData.SampleData.Maksim.ToUserProfileDto(),
            SampleData.SampleData.Ilya.ToUserProfileDto()
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

        public Task<UserPreviewDto> SimpleLogin(String userTag)
        {
            throw new NotImplementedException();
        }
    }
}