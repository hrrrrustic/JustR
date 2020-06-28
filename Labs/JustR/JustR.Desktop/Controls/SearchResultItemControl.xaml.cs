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
using JustR.ClientRelatedShare.Dto;

namespace JustR.Desktop.Controls
{
    /// <summary>
    /// Interaction logic for SearchResultItemControl.xaml
    /// </summary>
    public partial class SearchResultItemControl : UserControl
    {
        public SearchResultItemControl()
        {
            InitializeComponent();
        }

        public static DependencyProperty UserPreviewProperty = DependencyProperty.Register("UserPreview",
            typeof(UserPreviewDto),
            typeof(SearchResultItemControl), new PropertyMetadata(null));
        public UserPreviewDto UserPreview
        {
            get => (UserPreviewDto)GetValue(UserPreviewProperty);
            set => SetValue(UserPreviewProperty, value);
        }

        public static DependencyProperty SendFriendRequestProperty = DependencyProperty.Register("SendFriendRequest",
            typeof(ICommand),
            typeof(SearchResultItemControl), new PropertyMetadata(null));

        public ICommand SendFriendRequest
        {
            get => (ICommand)GetValue(SendFriendRequestProperty);
            set => SetValue(SendFriendRequestProperty, value);
        }

        public static DependencyProperty OpenDialogProperty = DependencyProperty.Register("OpenDialog",
            typeof(ICommand),
            typeof(SearchResultItemControl), new PropertyMetadata(null));

        public ICommand OpenDialog
        {
            get => (ICommand)GetValue(OpenDialogProperty);
            set => SetValue(OpenDialogProperty, value);
        }
    }
}
