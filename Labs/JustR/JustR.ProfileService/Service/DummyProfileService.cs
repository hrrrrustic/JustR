using System;
using System.Collections.Generic;
using System.Linq;
using JustR.Models.Dto;
using JustR.Models.Entity;
using JustR.ProfileService.Repository;

namespace JustR.ProfileService.Service
{
    public class DummyProfileService : IProfileService
    {
        private readonly IProfileRepository _profileRepository;
        public DummyProfileService(IProfileRepository profileRepository)
        {
            _profileRepository = profileRepository;
        }
        public UserProfileDto GetUserProfile(Guid userId)
        {
            User result = _profileRepository.ReadUserProfile(userId);

            return new UserProfileDto
            {
                UserName = result.FirstName 
            };
        }

        public UserPreviewDto GetUserPreview(Guid userId)
        {
            User result = _profileRepository.ReadUserProfile(userId);

            return new UserPreviewDto
            {
                UserName = result.FirstName
            };
        }

        public IEnumerable<UserPreviewDto> SearchUser(String query)
        {
            return _profileRepository.ReadUserProfiles(query).Select(k => new UserPreviewDto{UserName = k.FirstName});
            
        }
    }
}