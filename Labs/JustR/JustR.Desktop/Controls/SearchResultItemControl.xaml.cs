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
using JustR.Models.Dto;

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
    }
}
