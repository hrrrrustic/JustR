using System;
using System.Collections.Generic;
using System.Diagnostics;
using JustR.Core.Entity;

namespace JustR.ProfileService.InternalApi
{
    public interface IProfileApiProvider
    {
        User GetUserProfile(Guid userId);
        User GetUserPreview(Guid userId);
        IReadOnlyList<User> GetUsersPreview(IEnumerable<Guid> usersId);
        IReadOnlyList<User> SearchUser(String query);
        User UpdateUserProfile(User user);

        // TODO : Выпилить после реализации аутент. и автор.
        User SimpleLogIn(String userTag);
    }
}