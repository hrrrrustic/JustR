using System;
using System.Collections.Generic;
using JustR.Models.Dto;
using JustR.Models.Entity;

namespace JustR.ProfileService.Repository
{
    public interface IProfileRepository
    {
        User ReadUserProfile(Guid userId);
        IEnumerable<User> ReadUserProfiles(String userTag);
        User UpdateUserProfile(User newProfile);
    }
}