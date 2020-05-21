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
using JustR.Desktop.ViewModel;
using JustR.Models.Dto;

namespace JustR.Desktop.View
{
    /// <summary>
    /// Interaction logic for UserFriendsPage.xaml
    /// </summary>
    public partial class UserFriendsPage : Page
    {
        public UserFriendsPage()
        {
            InitializeComponent();
        }

        private void UserFriendsPage_OnLoaded(Object sender, RoutedEventArgs e)
        {
            this.GetViewModel<UserFriendsViewModel>().GetFriendsCommand.Execute(e);
        }
    }
}
