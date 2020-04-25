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

        public void GetUserProfile()
        {
            throw new System.NotImplementedException();
        }

        public void GetUserPreview()
        {
            throw new System.NotImplementedException();
        }

        public void UpdateUserProfile()
        {
            throw new System.NotImplementedException();
        }
    }
}