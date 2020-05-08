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
            PageNavigator.Register(this);
        }

        private Page _currentDialog = new DialogEmptyPage();

        public Page CurrentDialog
        {
            get => _currentDialog;
            set
            {
                _currentDialog = value;
                OnPropertyChanged();
            }
        }
    }
}