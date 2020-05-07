using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;
using JustR.Desktop.Annotations;
using JustR.Desktop.Commands;
using JustR.Desktop.Model;
using JustR.Desktop.View;

namespace JustR.Desktop.ViewModel
{ 
    public class MainWindowViewModel : BaseViewModel
    {

        public MainWindowViewModel()
        {
        }

        private readonly AuthenticationModel _authenticationModel = new AuthenticationModel();
        public ICommand LoginCommand => new ActionCommand(Authenticate);

        public void Authenticate()
        {
            if (_authenticationModel.Login == _authenticationModel.Password)
            {
                MessageBox.Show("Yes");
                new StartWindow().Show();
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