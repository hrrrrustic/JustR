using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using JustR.Models.Dto;
using JustR.Models.Entity;

namespace JustR.ProfileService.Repository
{
    public class DummyProfileRepository : IProfileRepository
    {
        private List<User> _dummyDb = new List<User>
        {
             new User
            {
                FirstName = "Yana", 
                LastName = "Tsittel", 
                UniqueTag = "_Kronda00_", 
                UserId = Guid.Parse("5B77A766-7B44-4E1B-BAF9-083713D1ABA3")
            },
             new User
            {
                FirstName = "Fredi",
                LastName = "Kats",
                UniqueTag = "InRedikaWb",
                UserId = Guid.Parse("8E924714-8E37-4AD4-81E1-80F691DEAD10")
            }
        };

        public User ReadUserProfile(Guid userId)
        {
            return _dummyDb.FirstOrDefault(k => k.UserId == userId) ?? new User();
        }

        public IEnumerable<User> ReadUserProfiles(String userTag)
        {
            return _dummyDb.Where(k => k.UniqueTag?.Contains(userTag) ?? false);
        }

        public User UpdateUserProfile(User newProfile)
        {
            var res = _dummyDb.FirstOrDefault(k => k.UserId == newProfile.UserId);
            if(res is null)
                throw new Exception();

            res = newProfile;

            return res;
        }

        public User FakeLogIn(String userTag)
        {
            throw new NotImplementedException();
        }
    }
}