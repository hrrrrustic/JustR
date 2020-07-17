using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using JustR.Core.Entity;
using JustR.Desktop.Commands;
using JustR.Desktop.Model;
using JustR.Desktop.Services.Abstractions;
using JustR.Desktop.View;

namespace JustR.Desktop.ViewModel
{
    public class StartWindowViewModel : BaseViewModel
    {
        private readonly AuthenticationModel _authenticationModel = new AuthenticationModel();
        private readonly IProfileService _profileService;

        public ICommand LoginCommand => new ActionCommand(async arg => await Authenticate());

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

        public StartWindowViewModel(IProfileService profileService)
        {
            _profileService = profileService;
            Login = "@s4xack";
        }

        public async Task Authenticate()
        {
            User profile = await _profileService.SimpleLogin(Login);

            if (profile is null)
            {
                MessageBox.Show("Nope");
                return;
            }

            UserInfo.CurrentUser = profile;

            MainWindow start = new MainWindow();
            start.Show();

            Application.Current?.MainWindow?.Close();
        }
    }
}