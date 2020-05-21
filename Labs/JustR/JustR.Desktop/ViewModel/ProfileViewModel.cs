using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using JustR.Desktop.Commands;
using Microsoft.Win32;

namespace JustR.Desktop.ViewModel
{
    public class ProfileViewModel : BaseViewModel
    {
        public ProfileViewModel()
        {
            ChangeAvatarCommand = new ActionCommand(arg =>
            {
                OpenFileDialog fd = new OpenFileDialog();
                fd.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.png) | *.jpg; *.jpeg; *.jpe; *.png";
                if (fd.ShowDialog() == true)
                {
                    try
                    {
                        Avatar = File.ReadAllBytes(fd.FileName);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Invalid picture");
                    }
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

        public String UserName
        {
            get => UserInfo.CurrentUser.Name;
            set
            {
                UserInfo.CurrentUser.Name = value;
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