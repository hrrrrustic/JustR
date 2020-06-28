using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using JustR.Desktop.Model;
using JustR.Desktop.View;

namespace JustR.Desktop.Controls
{
    /// <summary>
    /// Interaction logic for DialogPreviewControl.xaml
    /// </summary>
    public partial class DialogPreviewControl : UserControl
    {
        public DialogPreviewControl()
        {
            InitializeComponent();
        }

        public static DependencyProperty DialogPreviewProperty = DependencyProperty.Register("DialogPreview",
            typeof(DialogModel),
            typeof(DialogPreviewControl), new PropertyMetadata(null));

        public DialogModel DialogPreview
        {
            get => (DialogModel)GetValue(DialogPreviewProperty);
            set => SetValue(DialogPreviewProperty, value);
        }
    }
}
