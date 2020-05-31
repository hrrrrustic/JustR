using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using JustR.Core.Entity;
using JustR.Desktop.Commands;
using JustR.Desktop.Services.Abstractions;
using JustR.Desktop.Services.Implementations;
using JustR.Models.Entity;
using Microsoft.Win32;

namespace JustR.Desktop.ViewModel
{
    public class ProfileViewModel : BaseViewModel
    {
        private readonly IProfileService _profileService = new ProfileService();
        public ProfileViewModel()
        {
            ChangeAvatarCommand = new ActionCommand(async arg =>
            {
                OpenFileDialog fd = new OpenFileDialog();
                fd.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.png) | *.jpg; *.jpeg; *.jpe; *.png";
                if (fd.ShowDialog() == true)
                {
                    Byte[] newAvatar;
                    try
                    {
                        newAvatar = File.ReadAllBytes(fd.FileName);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Invalid picture");
                        return;
                    }

                    User user = new User
                    {
                        Avatar = newAvatar,
                        FirstName = FirstName,
                        LastName = LastName,
                        UniqueTag = UserTag,
                        UserId = UserInfo.CurrentUser.UserId
                    };

                    User result = await _profileService.UpdateProfile(user);

                    if (result == null)
                        return;

                    Avatar = result.Avatar;

                }
            });
        }
        public ICommand ChangeAvatarCommand { get; }
        public Byte[] Avatar
        {
            get => UserInfo.CurrentUser.Avatar;
            set
            {
                UserInfo.CurrentUser.Avatar = value;
                OnPropertyChanged();
            }
        }

        public String FirstName
        {
            get => UserInfo.CurrentUser.FirstName;
            set
            {
                UserInfo.CurrentUser.FirstName = value;
                OnPropertyChanged();
            }
        }
        public String LastName
        {
            get => UserInfo.CurrentUser.LastName;
            set
            {
                UserInfo.CurrentUser.LastName = value;
                OnPropertyChanged();
            }
        }
        public String UserTag
        {
            get => UserInfo.CurrentUser.UniqueTag;
            set
            {
                UserInfo.CurrentUser.UniqueTag = value;
                OnPropertyChanged();
            }
        }
    }
}