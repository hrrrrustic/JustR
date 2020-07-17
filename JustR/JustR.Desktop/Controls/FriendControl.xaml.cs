using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using JustR.ClientRelatedShare.Dto;

namespace JustR.Desktop.Controls
{
    /// <summary>
    ///     Interaction logic for FriendControl.xaml
    /// </summary>
    public partial class FriendControl : UserControl
    {
        public static DependencyProperty FriendProperty = DependencyProperty.Register("Friend", typeof(UserPreviewDto),
            typeof(FriendControl), new PropertyMetadata(null));

        public static DependencyProperty OpenDialogProperty = DependencyProperty.Register("OpenDialog",
            typeof(ICommand),
            typeof(FriendControl), new PropertyMetadata(null));

        public static DependencyProperty DeleteFriendProperty = DependencyProperty.Register("DeleteFriend",
            typeof(ICommand),
            typeof(FriendControl), new PropertyMetadata(null));

        public UserPreviewDto Friend
        {
            get => (UserPreviewDto) GetValue(FriendProperty);
            set => SetValue(FriendProperty, value);
        }

        public ICommand OpenDialog
        {
            get => (ICommand) GetValue(OpenDialogProperty);
            set => SetValue(OpenDialogProperty, value);
        }

        public ICommand DeleteFriend
        {
            get => (ICommand) GetValue(DeleteFriendProperty);
            set => SetValue(DeleteFriendProperty, value);
        }

        public FriendControl()
        {
            InitializeComponent();
        }
    }
}