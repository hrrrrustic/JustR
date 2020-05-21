using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using JustR.Desktop.Commands;
using JustR.Desktop.Services.Abstractions;
using JustR.Desktop.Services.Implementations;
using JustR.Desktop.View;
using JustR.Models.Dto;

namespace JustR.Desktop.ViewModel
{
    public class UserFriendsViewModel : BaseViewModel
    {
        private readonly IFriendService _friendService = new DummyFriendService();

        public UserFriendsViewModel()
        {
            DeleteFriendCommand = new ActionCommand<Guid>(async arg =>
            {
                await _friendService
                    .DeleteFriend(arg)
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
                        foreach (FriendDto friend in task.Result)
                        {
                            Friends.Add(friend);
                        }
                    }, TaskScheduler.FromCurrentSynchronizationContext());
            });
        }
        public ObservableCollection<FriendDto> Friends { get; set; } = new ObservableCollection<FriendDto>();

        public ICommand GetFriendsCommand { get; }
        public ICommand OpedDialogCommand { get; set; } = new ActionCommand<Guid>(arg =>
        {
            var page = new UserDialogsPage();
            page
                .GetViewModel<UserDialogsViewModel>()
                .OpenDialogByInterlocutorId
                .Execute(arg);
            PageNavigator.NavigateTo(page);
        });
        public ICommand DeleteFriendCommand { get; set; } 
    }
}