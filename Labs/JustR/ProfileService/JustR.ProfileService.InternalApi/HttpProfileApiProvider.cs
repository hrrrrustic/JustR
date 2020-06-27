using JustR.Core.Entity;
using System;
using System.Collections.Generic;

namespace JustR.ProfileService.InternalApi
{
    public class HttpProfileApiProvider : IProfileApiProvider
    {
        public User GetUserProfile(Guid userId)
        {
            throw new NotImplementedException();
        }

        public User GetUserPreview(Guid userId)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyList<User> GetUsersPreview(IEnumerable<Guid> usersId)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyList<User> SearchUser(String query)
        {
            throw new NotImplementedException();
        }

        public User UpdateUserProfile(User user)
        {
            throw new NotImplementedException();
        }

        public User SimpleLogIn(String userTag)
        {
            throw new NotImplementedException();
        }
    }
}
