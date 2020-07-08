using System;
using System.IO;
using System.Windows.Input;
using JustR.Core.Entity;
using JustR.Desktop.Commands;
using JustR.Desktop.Services.Abstractions;
using Microsoft.Win32;

namespace JustR.Desktop.ViewModel
{
    public class ProfileViewModel : BaseViewModel
    {
        private const String Filters = "Image files (*.jpg, *.jpeg, *.jpe, *.png) | *.jpg; *.jpeg; *.jpe; *.png";

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

        public ProfileViewModel(IProfileService profileService)
        {
            ChangeAvatarCommand = new ActionCommand(async arg =>
            {
                OpenFileDialog fd = new OpenFileDialog();
                fd.Filter = Filters;

                if (fd.ShowDialog() != true)
                    return;

                Boolean result = TryUploadImage(fd.FileName, out Byte[] avatar);

                if (!result)
                    return;


                User user = new User
                {
                    Avatar = avatar,
                    FirstName = FirstName,
                    LastName = LastName,
                    UniqueTag = UserTag,
                    UserId = UserInfo.CurrentUser.UserId
                };

                User updatedUser = await profileService.UpdateProfile(user);

                Avatar = updatedUser.Avatar;
            });
        }

        private Boolean TryUploadImage(String source, out Byte[] image)
        {
            image = default;

            try
            {
                image = File.ReadAllBytes(source);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}