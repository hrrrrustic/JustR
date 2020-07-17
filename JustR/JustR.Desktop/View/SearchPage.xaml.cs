using System.Windows.Controls;
using JustR.Desktop.ViewModel;

namespace JustR.Desktop.View
{
    /// <summary>
    ///     Interaction logic for SearchPage.xaml
    /// </summary>
    public partial class SearchPage : Page
    {
        public SearchPage(SearchViewModel viewModel)
        {
            DataContext = viewModel;
            InitializeComponent();
        }
    }
}