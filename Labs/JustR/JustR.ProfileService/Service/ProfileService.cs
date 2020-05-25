using System;
using System.Collections.Generic;
using JustR.Models.Dto;
using JustR.Models.Entity;

namespace JustR.ProfileService.Service
{
    public class ProfileService : IProfileService
    {
        private readonly IProfileService _profileService;

        public ProfileService(IProfileService profileService)
        {
            _profileService = profileService;
        }

        public User GetUserProfile(Guid userId)
        {
            return _profileService.GetUserProfile(userId);
        }

        public User GetUserPreview(Guid userId)
        {
            return _profileService.GetUserPreview(userId);
        }

        public IEnumerable<User> SearchUser(String query)
        {
            return _profileService.SearchUser(query);
        }
    }
}