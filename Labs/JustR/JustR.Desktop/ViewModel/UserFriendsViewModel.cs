using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using JustR.ClientRelatedShare.Dto;
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
                FriendRequestDto dto = FriendRequestDto.InputFriendRequest(UserInfo.CurrentUser.UserId, arg);

                // TODO : Проверять чего там вообще произошло на сервере
                await _friendService
                    .DeleteFriend(dto);

                UserPreviewDto friend = Friends.Single(k => k.UserId == arg);

                if (friend is null)
                    return;

                Friends.Remove(friend);
            });


            GetFriendsCommand = new ActionCommand(async arg =>
            {
                IReadOnlyList<UserPreviewDto> friends = await _friendService
                    .GetFriendsAsync(UserInfo.CurrentUser.UserId);

                if (friends is null)
                    return;

                foreach (UserPreviewDto friend in friends)
                    Friends.Add(friend);
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