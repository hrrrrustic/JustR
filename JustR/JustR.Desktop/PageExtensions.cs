using System.Windows.Controls;
using JustR.Desktop.ViewModel;

namespace JustR.Desktop
{
    public static class PageExtensions
    {
        public static T GetViewModel<T>(this Page page) where T : BaseViewModel
        {
            return (T) page.DataContext;
        }
    }
}