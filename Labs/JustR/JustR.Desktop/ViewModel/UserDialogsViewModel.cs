using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using JustR.Desktop.Commands;
using JustR.Desktop.Services.Abstractions;
using JustR.Desktop.Services.Implementations;
using JustR.Desktop.View;
using JustR.Models.Dto;
using JustR.Models.Entity;

namespace JustR.Desktop.ViewModel
{
    public class UserDialogsViewModel : BaseViewModel
    {
        private readonly IDialogService _dialogService;
        public UserDialogsViewModel()
        {
            _dialogService = new DummyDialogService();
            DialogsPreview = new ObservableCollection<DialogPreviewDto>(_dialogService.GetDialogsPreview(Guid.Empty));
        }

        public ObservableCollection<DialogPreviewDto> DialogsPreview { get; private set; }

        public ICommand OpenDialog => new ActionCommand(arg => CurrentDialog = new DialogPage());

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