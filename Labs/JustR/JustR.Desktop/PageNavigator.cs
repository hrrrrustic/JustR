using System;
using System.Windows.Controls;
using JustR.Desktop.ViewModel;
using Microsoft.Extensions.DependencyInjection;

namespace JustR.Desktop
{
    public static class PageNavigator
    {
        private static MainWindowViewModel _mainViewModel;

        private static IServiceProvider _serviceProvider;
        public static void Register(MainWindowViewModel mainWindowViewModel)
        {
            _mainViewModel ??= mainWindowViewModel;
        }

        public static void RegisterServiceProvider(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public static void NavigateTo(Type pageType)
        {
            _mainViewModel.CurrentPage = (Page)_serviceProvider.GetRequiredService(pageType);
        }

        //TODO : Билды страниц в коде все еще используют этот метод, нужно перевести их на di. Также в местах вызова идет ручное прокидывание аргументов в конструкторы
        public static void NavigateTo(Page page)
        {
            _mainViewModel.CurrentPage = page;
        }
    }
}