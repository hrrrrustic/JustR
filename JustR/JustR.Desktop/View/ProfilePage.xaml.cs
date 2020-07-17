using System.Windows.Controls;
using JustR.Desktop.ViewModel;

namespace JustR.Desktop.View
{
    /// <summary>
    ///     Interaction logic for ProfilePage.xaml
    /// </summary>
    public partial class ProfilePage : Page
    {
        public ProfilePage(ProfileViewModel viewModel)
        {
            DataContext = viewModel;
            InitializeComponent();
        }
    }
}