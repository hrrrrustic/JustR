using System.Windows.Input;
using JustR.Desktop.Commands;
using JustR.Desktop.View;

namespace JustR.Desktop.ViewModel
{
    // TODO : Перестать насиловать GC
    public class MenuViewModel : BaseViewModel
    {
        public ICommand ProfileCommand { get; set; } =
            new ActionCommand(arg => PageNavigator.NavigateTo(typeof(ProfilePage)));

        public ICommand MessageCommand { get; set; } =
            new ActionCommand(arg => PageNavigator.NavigateTo(typeof(UserDialogsPage)));

        public ICommand SearchCommand { get; set; } =
            new ActionCommand(arg => PageNavigator.NavigateTo(typeof(SearchPage)));

        public ICommand SettingCommand { get; set; } =
            new ActionCommand(arg => PageNavigator.NavigateTo(typeof(SettingsPage)));

        public ICommand FriendCommand { get; set; } =
            new ActionCommand(arg => PageNavigator.NavigateTo(typeof(UserFriendsPage)));
    }
}