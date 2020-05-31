using System;
using System.Collections.Generic;
using JustR.Core.Entity;
using JustR.Models.Entity;

namespace JustR.ProfileService.Service
{
    public interface IProfileService
    {
        User GetUserProfile(Guid userId);
        User GetUserPreview(Guid userId);
        IEnumerable<User> SearchUser(String query);
        User FakeLogIn(String userTag);
        User UpdateUserProfile(User user);
    }
}