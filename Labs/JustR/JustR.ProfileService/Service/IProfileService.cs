using System;
using System.Collections.Generic;
using JustR.Models.Dto;

namespace JustR.ProfileService.Service
{
    public interface IProfileService
    {
        UserProfileDto GetUserProfile(Guid userId);
        UserPreviewDto GetUserPreview(Guid userId);
        IEnumerable<UserPreviewDto> SearchUser(String query);
    }
}