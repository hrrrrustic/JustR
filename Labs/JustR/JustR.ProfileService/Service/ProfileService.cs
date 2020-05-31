using System;
using System.Collections.Generic;
using JustR.Core.Entity;
using JustR.Models.Entity;
using JustR.ProfileService.Repository;

namespace JustR.ProfileService.Service
{
    public class ProfileService : IProfileService
    {
        private readonly IProfileRepository _profileRepository;
        
        public ProfileService(IProfileRepository profileRepository)
        {
            
            _profileRepository = profileRepository;
        }


        public User GetUserProfile(Guid userId)
        {
            return _profileRepository.ReadUserProfile(userId);
        }

        public User GetUserPreview(Guid userId)
        {
            return _profileRepository.ReadUserProfile(userId);
        }

        public IEnumerable<User> SearchUser(String query)
        {
            return _profileRepository.ReadUserProfiles(query);
        }

        public User FakeLogIn(String userTag)
        {
            return _profileRepository.FakeLogIn(userTag);
        }

        public User UpdateUserProfile(User user)
        {
            return _profileRepository.UpdateUserProfile(user);
        }
    }
}