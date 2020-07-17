using System;
using System.Collections.Generic;
using JustR.Core.Entity;

namespace JustR.ProfileService.Repository
{
    public interface IProfileRepository
    {
        User FindUserProfile(Guid userId);
        IReadOnlyList<User> FindUserProfiles(String userTag);
        User UpdateUserProfile(User newProfile);
        User FakeLogIn(String userTag);
    }
}