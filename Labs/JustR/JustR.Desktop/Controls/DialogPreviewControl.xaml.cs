using System.Windows;
using System.Windows.Controls;
using JustR.Desktop.Model;

namespace JustR.Desktop.Controls
{
    /// <summary>
    ///     Interaction logic for DialogPreviewControl.xaml
    /// </summary>
    public partial class DialogPreviewControl : UserControl
    {
        public static DependencyProperty DialogPreviewProperty = DependencyProperty.Register("DialogPreview",
            typeof(DialogModel),
            typeof(DialogPreviewControl), new PropertyMetadata(null));

        public DialogModel DialogPreview
        {
            get => (DialogModel) GetValue(DialogPreviewProperty);
            set => SetValue(DialogPreviewProperty, value);
        }

        public DialogPreviewControl()
        {
            InitializeComponent();
        }
    }
}