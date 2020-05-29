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
        private readonly ProfileDbContext _context;
        public ProfileRepository(Compiler sqlCompiler, ProfileDbContext context)
        {
            _context = context;
            _queryFactory = new QueryFactory(new SqlConnection(DbConfiguration.ConnectionString), sqlCompiler);
        }

        public User ReadUserProfile(Guid userId)
        {
            return _context.Users.Find(userId);
        }

        public IEnumerable<User> ReadUserProfiles(String userTag)
        {
            return _context
                .Users
                .Where(k => k
                    .UniqueTag
                    .ToLower()
                    .Contains(userTag.ToLower()))
                .ToList();



            return _queryFactory
                .Query(_baseTableName)
                .WhereLike("UniqueTag", userTag)
                .Get<User>();
        }

        public User UpdateUserProfile(User newProfile)
        {
            var res = _context.Users.Update(newProfile);
            _context.SaveChanges();
            return res.Entity;


            Int32 res2 = _queryFactory
                .Query(_baseTableName)
                .Where("userId", newProfile.UserId)
                .Update(newProfile);

            return newProfile;
        }

        public User FakeLogIn(String userTag)
        {

            return _context.Users.Single(k => k.UniqueTag == userTag);


            return _queryFactory
                .Query(_baseTableName)
                .Where("UniqueTag", userTag)
                .Get<User>()
                .Single();
        }
    }
}