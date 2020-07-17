using System;
using System.Threading.Tasks;
using JustR.ClientRelatedShare.Dto;
using JustR.Core.Entity;
using JustR.Desktop.Annotations;

namespace JustR.Desktop.Services.Abstractions
{
    public interface IProfileService
    {
        Task<UserPreviewDto> GetProfilePreviewAsync(Guid userId);
        Task<UserProfileDto> GetProfileAsync(Guid userId);
        Task<User> UpdateProfile(ChangeProfileDto user);

        [ItemCanBeNull]
        Task<User> SimpleLogin(String userTag);
    }
}