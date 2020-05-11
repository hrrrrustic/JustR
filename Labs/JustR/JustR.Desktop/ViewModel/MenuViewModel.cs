﻿using System.Windows.Input;
using JustR.Desktop.Commands;
using JustR.Desktop.View;

namespace JustR.Desktop.ViewModel
{
    public class MenuViewModel : BaseViewModel
    {
        public ICommand ProfileCommand { get; set; } = new ActionCommand(() => PageNavigator.NavigateTo(new ProfilePage()));
        public ICommand MessageCommand { get; set; } = new ActionCommand(() => PageNavigator.NavigateTo(new UserDialogsPage()));
        public ICommand SearchCommand { get; set; } = new ActionCommand(() => PageNavigator.NavigateTo(new SearchPage()));
        public ICommand SettingCommand { get; set; } = new ActionCommand(() => PageNavigator.NavigateTo(new SettingsPage()));
        public ICommand FriendCommand { get; set; } = new ActionCommand(() => PageNavigator.NavigateTo(new UserFriendsPage()));

    }
}