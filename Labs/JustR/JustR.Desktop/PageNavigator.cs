using System.Windows.Controls;
using JustR.Desktop.ViewModel;

namespace JustR.Desktop
{
    public static class PageNavigator
    {
        private static MainWindowViewModel _mainViewModel;
        public static void Register(MainWindowViewModel mainWindowViewModel)
        {
            _mainViewModel ??= mainWindowViewModel;
        }

        public static void NavigateTo(Page page)
        {
            _mainViewModel.CurrentDialog = page;
        }
    }
}