using System;
using System.Collections.Generic;
using System.Linq;
using JustR.Core.Entity;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace JustR.ProfileService.Repository
{
    public class ProfileRepository : IProfileRepository
    {
        private readonly ProfileDbContext _context;
        public ProfileRepository(ProfileDbContext context)
        {
            _context = context;
        }

        public User ReadUserProfile(Guid userId)
        {
            return _context
                .Users
                .Find(userId);
        }

        public IReadOnlyList<User> ReadUserProfiles(String userTag)
        {
            String lowerUserTag = userTag.ToLowerInvariant();

            return _context
                .Users
                .Where(k => k
                    .UniqueTag
                    .ToLowerInvariant()
                    .Contains(lowerUserTag))
                .ToList();
        }

        public User UpdateUserProfile(User newProfile)
        {
            EntityEntry<User> updatedUser = _context.Users.Update(newProfile);
            _context.SaveChanges();

            return updatedUser.Entity;
        }

        public User FakeLogIn(String userTag)
        {
            return _context
                .Users
                .Single(k => k.UniqueTag == userTag);
        }
    }
}