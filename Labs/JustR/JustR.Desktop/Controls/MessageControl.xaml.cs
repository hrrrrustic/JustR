using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for MessageControl.xaml
    /// </summary>
    public partial class MessageControl : UserControl
    {
        public MessageControl()
        {
            InitializeComponent();
        }

        public static DependencyProperty MessageProperty = DependencyProperty.Register("Message", typeof(MessageDto),
            typeof(MessageControl), new PropertyMetadata(null));
        public MessageDto Message
        {
            get => (MessageDto)GetValue(MessageProperty);
            set => SetValue(MessageProperty, value);
        }
    }
}
