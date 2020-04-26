using System;
using JustR.Models.Dto;

namespace JustR.ProfileService.Service
{
    public interface IProfileService
    {
        UserProfileDto GetUserProfile(Guid userId);
        UserPreviewDto GetUserPreview(Guid userId);
        UserPreviewDto SearchUser(String query);
    }
}