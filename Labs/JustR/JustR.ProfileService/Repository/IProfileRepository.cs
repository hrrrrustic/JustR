namespace JustR.ProfileService.Repository
{
    public interface IProfileRepository
    {
        void GetUserProfile();
        void GetUserPreview();
        void UpdateUserProfile();
    }
}