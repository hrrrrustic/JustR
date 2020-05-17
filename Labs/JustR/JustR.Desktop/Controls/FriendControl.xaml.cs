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

        public static DependencyProperty FriendNameProperty = DependencyProperty.Register("FriendName", typeof(String),
            typeof(FriendControl), new PropertyMetadata(null));
        public String FriendName
        {
            get => (String)GetValue(FriendNameProperty);
            set => SetValue(FriendNameProperty, value);
        }

        public static DependencyProperty OpenDialogProperty = DependencyProperty.Register("OpenDialog", typeof(ICommand),
            typeof(FriendControl), new PropertyMetadata(null));

        public ICommand OpenDialog
        {
            get => (ICommand)GetValue(OpenDialogProperty);
            set => SetValue(OpenDialogProperty, value);
        }
    }
}
