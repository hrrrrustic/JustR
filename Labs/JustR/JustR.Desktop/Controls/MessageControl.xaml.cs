using System.Windows;
using System.Windows.Controls;
using JustR.ClientRelatedShare.Dto;

namespace JustR.Desktop.Controls
{
    /// <summary>
    ///     Interaction logic for MessageControl.xaml
    /// </summary>
    public partial class MessageControl : UserControl
    {
        public static DependencyProperty MessageProperty = DependencyProperty.Register("Message", typeof(MessageDto),
            typeof(MessageControl), new PropertyMetadata(null));

        public MessageDto Message
        {
            get => (MessageDto) GetValue(MessageProperty);
            set => SetValue(MessageProperty, value);
        }

        public MessageControl()
        {
            InitializeComponent();
        }
    }
}