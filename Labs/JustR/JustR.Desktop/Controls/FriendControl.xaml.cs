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
using JustR.Desktop.Commands;
using JustR.Desktop.View;
using JustR.Models.Dto;
using JustR.Models.Entity;

namespace JustR.Desktop.Controls
{
    /// <summary>
    /// Interaction logic for FriendControl.xaml
    /// </summary>
    public partial class FriendControl : UserControl
    {
        public FriendControl()
        {
            InitializeComponent();
        }

        public static DependencyProperty FriendProperty = DependencyProperty.Register("Friend", typeof(UserPreviewDto),
            typeof(FriendControl), new PropertyMetadata(null));
        public UserPreviewDto Friend
        {
            get => (UserPreviewDto)GetValue(FriendProperty);
            set => SetValue(FriendProperty, value);
        }

        public static DependencyProperty OpenDialogProperty = DependencyProperty.Register("OpenDialog", typeof(ICommand),
            typeof(FriendControl), new PropertyMetadata(null));

        public ICommand OpenDialog
        {
            get => (ICommand)GetValue(OpenDialogProperty);
            set => SetValue(OpenDialogProperty, value);
        }

        public static DependencyProperty DeleteFriendProperty = DependencyProperty.Register("DeleteFriend", typeof(ICommand),
            typeof(FriendControl), new PropertyMetadata(null));

        public ICommand DeleteFriend
        {
            get => (ICommand)GetValue(DeleteFriendProperty);
            set => SetValue(DeleteFriendProperty, value);
        }
    }
}
