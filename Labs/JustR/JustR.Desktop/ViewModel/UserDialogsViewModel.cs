using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
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
        private readonly IDialogService _dialogService = new DummyDialogService();

        private readonly IProfileService _profileService = new DummyProfileService();
        public UserDialogsViewModel()
        {
            GetDialogsCommand = new ActionCommand<Guid>(async arg =>
            {
                await _dialogService
                    .GetDialogsPreviewAsync(arg)
                    .ContinueWith(task =>
                    {
                        foreach (DialogPreviewDto dialog in task.Result)
                        {
                            DialogsPreview.Add(dialog);
                        }
                    }, TaskScheduler.FromCurrentSynchronizationContext());
            });
        }

        public ObservableCollection<DialogPreviewDto> DialogsPreview { get; } = new ObservableCollection<DialogPreviewDto>();

        public ICommand OpenDialogByDialogId => new ActionCommand<Guid>(arg =>
        {
            Page page = new DialogPage();
            DialogViewModel viewModel = page.GetViewModel<DialogViewModel>();
            viewModel.CurrentDialog = new DialogInfoDto();
            viewModel.GetMessages.Execute(arg);
            viewModel.GetDialogInfoCommand.Execute(arg);
            CurrentDialog = page;
        });
        public ICommand OpenDialogByInterlocutorId => new ActionCommand<Guid>(async arg =>
        {
            Page page = new DialogPage();
            DialogViewModel viewModel = page.GetViewModel<DialogViewModel>();
            viewModel.CurrentDialog = new DialogInfoDto();
            Guid dialogId = await _dialogService.GetDialogIdAsync(arg);

            if (dialogId == Guid.Empty)
            {
                viewModel.Test(await _profileService.GetProfilePreviewAsync(arg));
            }
            else
            {
                viewModel.GetMessages.Execute(dialogId);
                viewModel.GetDialogInfoCommand.Execute(dialogId);
                viewModel.CurrentDialog.DialogId = dialogId;
            }

            viewModel.CurrentDialog.DialogId = dialogId;
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