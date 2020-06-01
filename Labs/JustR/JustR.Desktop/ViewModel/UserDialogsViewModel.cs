using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using JustR.Core.Dto;
using JustR.Desktop.Commands;
using JustR.Desktop.Services.Abstractions;
using JustR.Desktop.Services.Implementations;
using JustR.Desktop.View;

namespace JustR.Desktop.ViewModel
{
    public class UserDialogsViewModel : BaseViewModel
    {
        private readonly IDialogService _dialogService = new DialogService();

        private readonly IProfileService _profileService = new ProfileService();
        public UserDialogsViewModel()
        {
            GetDialogsCommand = new ActionCommand<Guid>(async arg =>
            {
                await _dialogService
                    .GetDialogsPreviewAsync(arg)
                    .ContinueWith(task =>
                    {
                        if(task.Result is null)
                            return;

                        foreach (DialogPreviewDto dialog in task.Result)
                            DialogsPreview.Add(dialog);
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

            Guid dialogId = await _dialogService.GetDialogIdAsync(arg, UserInfo.CurrentUser.UserId);

            if (dialogId == Guid.Empty)
            {
                viewModel.SetInterlocutor(await _profileService.GetProfilePreviewAsync(arg));
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