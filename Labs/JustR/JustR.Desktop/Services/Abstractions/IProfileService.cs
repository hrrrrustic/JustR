using System;
using System.Threading.Tasks;
using JustR.ClientRelatedShare.Dto;
using JustR.Core.Entity;
using JustR.Desktop.Annotations;
using JustR.Models.Entity;

namespace JustR.Desktop.Services.Abstractions
{
    public interface IProfileService
    {
        Task<UserPreviewDto> GetProfilePreviewAsync(Guid userId);
        Task<UserProfileDto> GetProfileAsync(Guid userId);
        Task<User> UpdateProfile(User user);
        [ItemCanBeNull] Task<UserPreviewDto> SimpleLogin(String userTag);
    }
}