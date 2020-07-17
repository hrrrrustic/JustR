using System;
using System.Collections.Generic;
using System.Linq;
using JustR.Core.Entity;
using Microsoft.EntityFrameworkCore;
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

        public User FindUserProfile(Guid userId)
        {
            return _context
                .Users
                .Find(userId);
        }

        public IReadOnlyList<User> FindUserProfiles(String userTag)
        {
            String lowerUserTag = userTag.ToLower();

            return _context
                .Users
                .Where(k => k
                    .UniqueTag
                    .ToLower()
                    .Contains(lowerUserTag))
                .ToList();
        }

        public User UpdateUserProfile(User newProfile)
        {
            User updatedUser = _context.Users.Update(newProfile).Entity;
            _context.SaveChanges();

            return updatedUser;
        }

        public User FakeLogIn(String userTag)
        {
            return _context
                .Users
                .Single(k => k.UniqueTag == userTag);
        }
    }
}