using System;
using System.Collections.Generic;
using JustR.Core.Entity;

namespace JustR.ProfileService.Service
{
    public interface IProfileService
    {
        User FindUserProfile(Guid userId);
        User GetUserPreview(Guid userId);
        IReadOnlyList<User> SearchUser(String query);
        User FakeLogIn(String userTag);
        User UpdateUserProfile(User user);
    }
}