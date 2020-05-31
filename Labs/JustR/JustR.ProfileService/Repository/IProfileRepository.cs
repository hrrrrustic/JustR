using System;
using System.Collections.Generic;
using JustR.Core.Entity;

namespace JustR.ProfileService.Repository
{
    public interface IProfileRepository
    {
        User ReadUserProfile(Guid userId);
        IReadOnlyList<User> ReadUserProfiles(String userTag);
        User UpdateUserProfile(User newProfile);
        User FakeLogIn(String userTag);
    }
}