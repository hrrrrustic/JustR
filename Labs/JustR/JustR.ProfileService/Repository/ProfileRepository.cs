using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using JustR.Models.Dto;
using JustR.Models.Entity;
using SqlKata;
using SqlKata.Compilers;
using SqlKata.Execution;

namespace JustR.ProfileService.Repository
{
    public class ProfileRepository : IProfileRepository
    {
        private readonly QueryFactory _queryFactory;

        public ProfileRepository(Compiler sqlCompiler)
        {
            _queryFactory = new QueryFactory(new SqlConnection(DbConfiguration.ConnectionString), sqlCompiler);
        }

        public User ReadUserProfile(Guid userId)
        {
            return _queryFactory
                .Query("Users")
                .Where("UserId", userId)
                .First<User>();
        }

        public IEnumerable<User> ReadUserProfiles(String userTag)
        {
            return _queryFactory
                .Query("Users")
                .WhereLike("UniqueTag", userTag)
                .Get<User>();
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