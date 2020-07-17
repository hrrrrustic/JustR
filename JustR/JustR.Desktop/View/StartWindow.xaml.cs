using System.Windows;
using JustR.Desktop.ViewModel;

namespace JustR.Desktop.View
{
    /// <summary>
    ///     Interaction logic for StartWindow.xaml
    /// </summary>
    public partial class StartWindow : Window
    {
        public StartWindow(StartWindowViewModel viewModel)
        {
            DataContext = viewModel;
            InitializeComponent();
        }
    }
}