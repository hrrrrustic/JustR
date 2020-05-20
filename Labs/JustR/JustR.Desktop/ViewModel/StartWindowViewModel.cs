using System;
using System.Windows;
using System.Windows.Input;
using JustR.Desktop.Commands;
using JustR.Desktop.Controls;
using JustR.Desktop.Model;
using JustR.Desktop.View;
using JustR.Models.Entity;

namespace JustR.Desktop.ViewModel
{
    public class StartWindowViewModel : BaseViewModel
    { 
        private readonly AuthenticationModel _authenticationModel = new AuthenticationModel();

        public ICommand LoginCommand => new ActionCommand(arg => Authenticate());
        public void Authenticate()
        {
            if (_authenticationModel.Login == _authenticationModel.Password)
            {
                var start = new View.MainWindow();
                start.Show();
                Application.Current?.MainWindow?.Close();
                return;
            }

            MessageBox.Show("Nope");

        }

        public String Login
        {
            get => _authenticationModel.Login;
            set => _authenticationModel.Login = value;
        }

        public String Password
        {
            get => _authenticationModel.Password;
            set => _authenticationModel.Password = value;
        }
    }
}