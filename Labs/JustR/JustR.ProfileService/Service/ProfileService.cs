using System;
using System.Collections.Generic;
using JustR.Models.Dto;

namespace JustR.ProfileService.Service
{
    public class ProfileService : IProfileService
    {
        public UserProfileDto GetUserProfile(Guid userId)
        {
            throw new NotImplementedException();
        }

        public UserPreviewDto GetUserPreview(Guid userId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserPreviewDto> SearchUser(String query)
        {
            throw new NotImplementedException();
        }
    }
}