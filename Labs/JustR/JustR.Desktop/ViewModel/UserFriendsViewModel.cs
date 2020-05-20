using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows.Input;
using JustR.Desktop.Commands;
using JustR.Desktop.Services.Implementations;
using JustR.Desktop.View;
using JustR.Models.Dto;

namespace JustR.Desktop.ViewModel
{
    public class UserFriendsViewModel : BaseViewModel
    {
        public UserFriendsViewModel()
        {
            DeleteFriendCommand = new ActionCommand<Guid>(arg =>
            {
                var friend = Friends.FirstOrDefault(k => k.UserId == arg);
                if (friend is null)
                    return;

                Friends.Remove(friend);
            });
        }
        public ObservableCollection<FriendDto> Friends { get; set; } = new ObservableCollection<FriendDto>()
        {
            new FriendDto
            {
                UserId = Guid.NewGuid(),
                Name = "Friend 1",
                Avatar = File.ReadAllBytes("C:\\Users\\hrrrrustic\\OneDrive\\Desktop\\Кисик.jpg")
            },
            new FriendDto
            {
                UserId = Guid.NewGuid(),
                Name = "Friend 2",
                Avatar = File.ReadAllBytes("C:\\Users\\hrrrrustic\\OneDrive\\Desktop\\Кисик.jpg")
            }
        };

        public ICommand OpedDialogCommand { get; set; } = new ActionCommand(arg =>
        {
            var page = new UserDialogsPage();
            ((UserDialogsViewModel)page.DataContext).CurrentDialog = new DialogPage();
            PageNavigator.NavigateTo(page);
        });
        public ICommand DeleteFriendCommand { get; set; } 
    }
}