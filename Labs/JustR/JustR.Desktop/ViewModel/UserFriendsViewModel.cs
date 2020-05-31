using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using JustR.Core.Dto;
using JustR.Core.Enum;
using JustR.Desktop.Commands;
using JustR.Desktop.Services.Abstractions;
using JustR.Desktop.Services.Implementations;
using JustR.Desktop.View;

namespace JustR.Desktop.ViewModel
{
    public class UserFriendsViewModel : BaseViewModel
    {
        private readonly IFriendService _friendService = new FriendService();

        public UserFriendsViewModel()
        {
            DeleteFriendCommand = new ActionCommand<Guid>(async arg =>
            {
                FriendRequestDto dto = new FriendRequestDto
                {
                    FirstUserId = UserInfo.CurrentUser.UserId,
                    SecondUserId = arg,
                    State = RelationshipState.OutputFriendRequest
                };

                await _friendService
                    .DeleteFriend(dto)
                    .ContinueWith(task =>
                    {
                        var friend = Friends.Single(k => k.UserId == arg);
                        if (friend is null)
                            return;

                        Friends.Remove(friend);
                    }, TaskScheduler.FromCurrentSynchronizationContext());
            });

            GetFriendsCommand = new ActionCommand(async arg =>
            {
                await _friendService
                    .GetFriendsAsync(UserInfo.CurrentUser.UserId)
                    .ContinueWith(task =>
                    {
                        if (task.Result is null)
                            return;

                        foreach (UserPreviewDto friend in task.Result)
                        {
                            Friends.Add(friend);
                        }
                    }, TaskScheduler.FromCurrentSynchronizationContext());
            });
        }
        public ObservableCollection<UserPreviewDto> Friends { get; } = new ObservableCollection<UserPreviewDto>();

        public ICommand GetFriendsCommand { get; }
        public ICommand OpedDialogCommand { get; } = new ActionCommand<Guid>(arg =>
        {
            var page = new UserDialogsPage();
            page
                .GetViewModel<UserDialogsViewModel>()
                .OpenDialogByInterlocutorId
                .Execute(arg);
            PageNavigator.NavigateTo(page);
        });
        public ICommand DeleteFriendCommand { get; } 
    }
}