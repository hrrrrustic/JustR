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
        public User GetUserProfile(Guid userId)
        {
            User result = _profileRepository.ReadUserProfile(userId);

            return result;
        }

        public User GetUserPreview(Guid userId)
        {
            User result = _profileRepository.ReadUserProfile(userId);

            return result;
        }

        public IEnumerable<User> SearchUser(String query)
        {
            return _profileRepository.ReadUserProfiles(query);
            
        }
    }
}