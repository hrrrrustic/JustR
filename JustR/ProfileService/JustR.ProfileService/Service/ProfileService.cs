using System;
using System.Collections.Generic;
using JustR.Core.Entity;
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

        public User FindUserProfile(Guid userId)
        {
            return _profileRepository.FindUserProfile(userId);
        }

        public User GetUserPreview(Guid userId)
        {
            return _profileRepository.FindUserProfile(userId);
        }

        public IReadOnlyList<User> SearchUser(String query)
        {
            return _profileRepository.FindUserProfiles(query);
        }

        public User FakeLogIn(String userTag)
        {
            return _profileRepository.FakeLogIn(userTag);
        }

        public User UpdateUserProfile(User user)
        {
            var t = _profileRepository.FindUserProfile(user.UserId);

                t.Avatar = user.Avatar;


            return _profileRepository.UpdateUserProfile(t);
        }
    }
}