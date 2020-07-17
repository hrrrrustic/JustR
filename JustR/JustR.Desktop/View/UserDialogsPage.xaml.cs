using System;
using System.Windows;
using System.Windows.Controls;
using JustR.Desktop.ViewModel;

namespace JustR.Desktop.View
{
    /// <summary>
    ///     Interaction logic for UserDialogsPage.xaml
    /// </summary>
    public partial class UserDialogsPage : Page
    {
        public UserDialogsPage(UserDialogsViewModel viewModel)
        {
            DataContext = viewModel;
            InitializeComponent();
        }

        private void UserDialogsPage_OnLoaded(Object sender, RoutedEventArgs e)
        {
            this.GetViewModel<UserDialogsViewModel>().GetDialogsCommand.Execute(UserInfo.CurrentUser.UserId);
        }
    }
}