using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using JustR.ClientRelatedShare.Dto;
using JustR.Desktop.Commands;
using JustR.Desktop.Services.Abstractions;
using JustR.Desktop.Services.Implementations;
using JustR.Desktop.View;

namespace JustR.Desktop.ViewModel
{
    public class UserFriendsViewModel : BaseViewModel
    {
        public ObservableCollection<UserPreviewDto> Friends { get; } = new ObservableCollection<UserPreviewDto>();

        public ICommand GetFriendsCommand { get; }

        public ICommand OpedDialogCommand { get; } = new ActionCommand<Guid>(arg =>
        {
            UserDialogsPage page =
                new UserDialogsPage(new UserDialogsViewModel(new DialogService(), new ProfileService()));
            page
                .GetViewModel<UserDialogsViewModel>()
                .OpenDialogByInterlocutorId
                .Execute(arg);

            PageNavigator.NavigateTo(page);
        });

        public ICommand DeleteFriendCommand { get; }

        public UserFriendsViewModel(IFriendService friendService)
        {
            DeleteFriendCommand = new ActionCommand<Guid>(async arg =>
            {
                FriendRequestDto dto = FriendRequestDto.InputFriendRequest(UserInfo.CurrentUser.UserId, arg);

                await friendService
                    .DeleteFriend(dto);

                UserPreviewDto friend = Friends.Single(k => k.UserId == arg);

                if (friend is null)
                    return;

                Friends.Remove(friend);
            });


            GetFriendsCommand = new ActionCommand(async arg =>
            {
                IReadOnlyList<UserPreviewDto> friends = await friendService
                    .GetFriendsAsync(UserInfo.CurrentUser.UserId);

                if (friends is null)
                    return;

                foreach (UserPreviewDto friend in friends)
                    Friends.Add(friend);
            });
        }
    }
}