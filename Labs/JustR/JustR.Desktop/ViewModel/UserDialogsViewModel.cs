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
            GetDialogsCommand = new ActionCommand<Guid>(async arg =>
            {
                var dialogs = await _dialogService.GetDialogsPreviewAsync(arg);

                foreach (DialogPreviewDto dialog in dialogs)
                {
                    DialogsPreview.Add(dialog);
                }
            });
        }

        public ObservableCollection<DialogPreviewDto> DialogsPreview { get; } = new ObservableCollection<DialogPreviewDto>();

        public ICommand OpenDialog => new ActionCommand<Guid>(arg =>
        {
            Page page = new DialogPage();
            DialogViewModel viewModel = page.GetViewModel<DialogViewModel>();
            viewModel.CurrentDialogId = arg;
            viewModel.GetMessages.Execute(arg);
            viewModel.GetDialogInfoCommand.Execute(arg);
            CurrentDialog = page;
        });

        public ICommand GetDialogsCommand { get; }
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