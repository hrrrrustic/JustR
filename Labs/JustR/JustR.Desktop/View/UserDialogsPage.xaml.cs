using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using JustR.Desktop.Services.Abstractions;
using JustR.Desktop.ViewModel;

namespace JustR.Desktop.View
{
    /// <summary>
    /// Interaction logic for UserDialogsPage.xaml
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
