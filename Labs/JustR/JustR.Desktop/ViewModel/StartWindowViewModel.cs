using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using JustR.Core.Dto;
using JustR.Desktop.Commands;
using JustR.Desktop.Model;
using JustR.Desktop.Services.Abstractions;
using JustR.Desktop.Services.Implementations;
using JustR.Desktop.View;

namespace JustR.Desktop.ViewModel
{
    public class StartWindowViewModel : BaseViewModel
    {
        private readonly IProfileService _profileService = new ProfileService();
        private readonly AuthenticationModel _authenticationModel = new AuthenticationModel();

        public ICommand LoginCommand => new ActionCommand(async arg => await Authenticate());

        public StartWindowViewModel()
        {
            Login = "@s4xack";
        }
        public async Task Authenticate()
        {
            UserPreviewDto profile = await _profileService.SimpleLogin(Login);

            if (profile is null)
            {
                MessageBox.Show("Nope");
                return;
            }

            UserInfo.CurrentUser.FirstName = profile.FirstName;
            UserInfo.CurrentUser.LastName = profile.LastName;
            UserInfo.CurrentUser.Avatar = profile.Avatar;
            UserInfo.CurrentUser.UserId = profile.UserId;
            UserInfo.CurrentUser.UniqueTag = profile.UniqueTag;

            MainWindow start = new MainWindow();
            start.Show();

            Application.Current?.MainWindow?.Close();
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