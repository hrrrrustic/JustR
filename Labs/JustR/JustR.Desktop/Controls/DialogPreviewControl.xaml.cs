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
using JustR.Desktop.View;
using JustR.Models.Dto;

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
            typeof(DialogPreviewDto),
            typeof(DialogPreviewControl), new PropertyMetadata(null));
        public DialogPreviewDto DialogPreview
        {
            get => (DialogPreviewDto)GetValue(DialogPreviewProperty);
            set => SetValue(DialogPreviewProperty, value);
        }
    }
}
