using System.Windows.Controls;
using JustR.Desktop.ViewModel;

namespace JustR.Desktop.View
{
    /// <summary>
    ///     Interaction logic for DialogPage.xaml
    /// </summary>
    public partial class DialogPage : Page
    {
        public DialogPage(DialogViewModel viewModel)
        {
            DataContext = viewModel;
            InitializeComponent();
        }
    }
}