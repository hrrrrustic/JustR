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
        private readonly IFriendService _friendService;
        public UserFriendsViewModel()
        {
            _friendService = new DummyFriendService();
            DeleteFriendCommand = new ActionCommand<Guid>(arg =>
            {
                var friend = Friends.FirstOrDefault(k => k.UserId == arg);
                if (friend is null)
                    return;

                Friends.Remove(friend);
            });

            GetFriendsCommand = new ActionCommand(async arg =>
            {
                List<FriendDto> friends = await _friendService.GetFriendsAsync(Guid.Empty);
                foreach (FriendDto friend in friends)
                {
                    Friends.Add(friend);
                }
            });
        }
        public ObservableCollection<FriendDto> Friends { get; set; } = new ObservableCollection<FriendDto>();

        public ICommand GetFriendsCommand { get; }
        public ICommand OpedDialogCommand { get; set; } = new ActionCommand(arg =>
        {
            var page = new UserDialogsPage();
            ((UserDialogsViewModel)page.DataContext).CurrentDialog = new DialogPage();
            PageNavigator.NavigateTo(page);
        });
        public ICommand DeleteFriendCommand { get; set; } 
    }
}