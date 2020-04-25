using SqlKata.Compilers;

namespace JustR.FriendService.Repository
{
    public class FriendRepository : IFriendRepository
    {
        private readonly Compiler _sqlCompiler;

        public FriendRepository(Compiler sqlCompiler)
        {
            _sqlCompiler = sqlCompiler;
        }

        public void ReadUserFriends()
        {
            throw new System.NotImplementedException();
        }

        public void CreateFriendRequest()
        {
            throw new System.NotImplementedException();
        }

        public void UpdateFriendRequest()
        {
            throw new System.NotImplementedException();
        }

        public void DeleteFriend()
        {
            throw new System.NotImplementedException();
        }
    }
}