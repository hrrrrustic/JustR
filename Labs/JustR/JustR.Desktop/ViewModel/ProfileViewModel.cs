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
                    var test = File.ReadAllBytes(fd.FileName);
                    Avatar = test;
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
    }
}