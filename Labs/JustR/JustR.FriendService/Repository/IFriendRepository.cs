namespace JustR.FriendService.Repository
{
    public interface IFriendRepository
    {
        void CreateFriendRequest();
        void ReadUserFriends();
        void UpdateFriendRequest();
        void DeleteFriend();
    }
}