using System;
using System.Windows;
using System.Windows.Controls;
using JustR.Desktop.ViewModel;

namespace JustR.Desktop.View
{
    /// <summary>
    ///     Interaction logic for UserFriendsPage.xaml
    /// </summary>
    public partial class UserFriendsPage : Page
    {
        public UserFriendsPage(UserFriendsViewModel viewModel)
        {
            DataContext = viewModel;
            InitializeComponent();
        }

        private void UserFriendsPage_OnLoaded(Object sender, RoutedEventArgs e)
        {
            this.GetViewModel<UserFriendsViewModel>().GetFriendsCommand.Execute(e);
        }
    }
}