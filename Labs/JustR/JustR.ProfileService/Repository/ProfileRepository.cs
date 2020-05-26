using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
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
        private readonly String _baseTableName = "Users";
        public ProfileRepository(Compiler sqlCompiler)
        {
            _queryFactory = new QueryFactory(new SqlConnection(DbConfiguration.ConnectionString), sqlCompiler);
        }

        public User ReadUserProfile(Guid userId)
        {
            return _queryFactory
                .Query(_baseTableName)
                .Where("UserId", userId)
                .First<User>();
        }

        public IEnumerable<User> ReadUserProfiles(String userTag)
        {
            return _queryFactory
                .Query(_baseTableName)
                .WhereLike("UniqueTag", userTag)
                .Get<User>();
        }

        public User UpdateUserProfile(User newProfile)
        {
            Int32 res = _queryFactory
                .Query(_baseTableName)
                .Where("userId", newProfile.UserId)
                .Update(newProfile);

            return newProfile;
        }

        public User FakeLogIn(String userTag)
        {
            return _queryFactory
                .Query(_baseTableName)
                .Where("UniqueTag", userTag)
                .Get<User>()
                .Single();
        }
    }
}