using System;
using System.Configuration;
using System.Reflection;
using System.Windows;
using System.Windows.Threading;

namespace JustR.Desktop
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            DispatcherUnhandledException += Application_DispatcherUnhandledException;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomainOnUnhandledException;

            GatewayConfiguration.ApiGatewaySource = ConfigurationManager.ConnectionStrings["GatewayUrl"].ConnectionString;
        }

        private void Application_DispatcherUnhandledException(Object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            e.Handled = true;
            Exception exception = e.Exception;
            HandleUnhandledException(exception);
        }

        private void CurrentDomainOnUnhandledException(Object sender, UnhandledExceptionEventArgs unhandledExceptionEventArgs)
        {
            HandleUnhandledException(unhandledExceptionEventArgs.ExceptionObject as Exception);

            if (unhandledExceptionEventArgs.IsTerminating)
            {
                MessageBox.Show("Application is terminating due to an unhandled exception in a secondary thread.");
            }
        }

        private void HandleUnhandledException(Exception exception)
        {
            string message = "Unhandled exception";
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
    }
}
