using System;
using System.Collections.Generic;
using JustR.Models.Dto;
using JustR.Models.Entity;
using SqlKata;
using SqlKata.Compilers;

namespace JustR.ProfileService.Repository
{
    public class ProfileRepository : IProfileRepository
    {
        private readonly Compiler _sqlCompiler;

        public ProfileRepository(Compiler sqlCompiler)
        {
            _sqlCompiler = sqlCompiler;
        }

        public User ReadUserProfile(Guid userId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> ReadUserProfiles(String userTag)
        {
            throw new NotImplementedException();
        }

        public User UpdateUserProfile(User newProfile)
        {
            throw new NotImplementedException();
        }

        public ChangeProfileDto UpdateUserProfile(ChangeProfileDto dto)
        {
            throw new NotImplementedException();
        }
    }
}