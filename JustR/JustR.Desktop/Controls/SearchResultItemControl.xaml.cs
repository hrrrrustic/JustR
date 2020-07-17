using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using JustR.ClientRelatedShare.Dto;

namespace JustR.Desktop.Controls
{
    /// <summary>
    ///     Interaction logic for SearchResultItemControl.xaml
    /// </summary>
    public partial class SearchResultItemControl : UserControl
    {
        public static DependencyProperty UserPreviewProperty = DependencyProperty.Register("UserPreview",
            typeof(UserPreviewDto),
            typeof(SearchResultItemControl), new PropertyMetadata(null));

        public static DependencyProperty SendFriendRequestProperty = DependencyProperty.Register("SendFriendRequest",
            typeof(ICommand),
            typeof(SearchResultItemControl), new PropertyMetadata(null));

        public static DependencyProperty OpenDialogProperty = DependencyProperty.Register("OpenDialog",
            typeof(ICommand),
            typeof(SearchResultItemControl), new PropertyMetadata(null));

        public UserPreviewDto UserPreview
        {
            get => (UserPreviewDto) GetValue(UserPreviewProperty);
            set => SetValue(UserPreviewProperty, value);
        }

        public ICommand SendFriendRequest
        {
            get => (ICommand) GetValue(SendFriendRequestProperty);
            set => SetValue(SendFriendRequestProperty, value);
        }

        public ICommand OpenDialog
        {
            get => (ICommand) GetValue(OpenDialogProperty);
            set => SetValue(OpenDialogProperty, value);
        }

        public SearchResultItemControl()
        {
            InitializeComponent();
        }
    }
}