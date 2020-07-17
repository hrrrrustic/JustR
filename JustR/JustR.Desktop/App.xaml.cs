using System;
using System.Configuration;
using System.Reflection;
using System.Windows;
using System.Windows.Threading;
using JustR.Desktop.Services.Abstractions;
using JustR.Desktop.Services.Implementations;
using JustR.Desktop.View;
using JustR.Desktop.ViewModel;
using Microsoft.Extensions.DependencyInjection;

namespace JustR.Desktop
{
    /// <summary>
    ///     Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            DispatcherUnhandledException += Application_DispatcherUnhandledException;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomainOnUnhandledException;

            GatewayConfiguration.ApiGatewaySource =
                ConfigurationManager.ConnectionStrings["GatewayUrl"].ConnectionString;
        }

        private void ConfigureServices(ServiceCollection services)
        {
            services.AddScoped<IProfileService, ProfileService>();
            services.AddScoped<IMessageService, MessageService>();
            services.AddScoped<IDialogService, DialogService>();
            services.AddScoped<ISearchService, SearchService>();
            services.AddScoped<IFriendService, FriendService>();

            services.AddTransient<DialogViewModel>();
            services.AddTransient<UserFriendsViewModel>();
            services.AddTransient<UserDialogsViewModel>();
            services.AddTransient<SearchViewModel>();

            services.AddSingleton<StartWindowViewModel>();
            services.AddSingleton<ProfileViewModel>();

            services.AddTransient<UserFriendsPage>();
            services.AddTransient<UserDialogsPage>();
            services.AddTransient<DialogPage>();
            services.AddTransient<SearchPage>();

            services.AddSingleton<StartWindow>();
            services.AddSingleton<ProfilePage>();

            services.AddScoped<SettingsPage>();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            ServiceCollection services = new ServiceCollection();
            ConfigureServices(services);
            PageNavigator.RegisterServiceProvider(services.BuildServiceProvider());

            base.OnStartup(e);
        }

        private void Application_DispatcherUnhandledException(Object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            e.Handled = true;
            Exception exception = e.Exception;
            HandleUnhandledException(exception);
        }

        private void CurrentDomainOnUnhandledException(Object sender,
            UnhandledExceptionEventArgs unhandledExceptionEventArgs)
        {
            HandleUnhandledException(unhandledExceptionEventArgs.ExceptionObject as Exception);

            if (unhandledExceptionEventArgs.IsTerminating)
                MessageBox.Show("Application is terminating due to an unhandled exception in a secondary thread.");
        }

        private void HandleUnhandledException(Exception exception)
        {
            String message = "Unhandled exception";
            try
            {
                AssemblyName assemblyName = Assembly
                    .GetExecutingAssembly()
                    .GetName();

                message = $"Unhandled exception in {assemblyName.Name} v{assemblyName.Version}";
            }
            catch (Exception exc)
            {
                MessageBox.Show("Exception in unhandled exception handler: " + exc.Message);
            }
            finally
            {
                MessageBox.Show(message + ": " + exception.Message);
            }
        }

        private void OnStartup(Object sender, StartupEventArgs e)
        {
            new StartWindow(new StartWindowViewModel(new ProfileService())).Show();
        }
    }
}