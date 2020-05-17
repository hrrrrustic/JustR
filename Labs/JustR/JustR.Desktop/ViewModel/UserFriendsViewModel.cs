using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows.Input;
using JustR.Desktop.Commands;
using JustR.Desktop.View;
using JustR.Models.Dto;

namespace JustR.Desktop.ViewModel
{
    public class UserFriendsViewModel : BaseViewModel
    {
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

        public ICommand OpedDialogCommand { get; set; } = new ActionCommand(() =>
        {
            var page = new UserDialogsPage();
            ((UserDialogsViewModel)page.DataContext).CurrentDialog = new DialogPage();
            PageNavigator.NavigateTo(page);
        });
    }
}