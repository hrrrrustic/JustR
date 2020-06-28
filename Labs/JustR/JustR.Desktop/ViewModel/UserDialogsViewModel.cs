using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;
using JustR.ClientRelatedShare.Dto;
using JustR.Core.Entity;
using JustR.Desktop.Commands;
using JustR.Desktop.Model;
using JustR.Desktop.Services.Abstractions;
using JustR.Desktop.Services.Implementations;
using JustR.Desktop.View;

namespace JustR.Desktop.ViewModel
{
    public class UserDialogsViewModel : BaseViewModel
    {
        private readonly IDialogService _dialogService = new DialogService();

        private readonly IProfileService _profileService = new ProfileService();

        private readonly NotificationHandler _handler = NotificationHandler.Instance.Value;

        public UserDialogsViewModel()
        {
            GetDialogsCommand = new ActionCommand<Guid>(async arg =>
            {
                IReadOnlyList<DialogPreviewDto> dialogs = await _dialogService
                    .GetDialogsPreviewAsync(arg);

                if (dialogs is null)
                    return;

                foreach (DialogPreviewDto dialog in dialogs)
                    DialogsPreview.Add(DialogModel.FromDto(dialog));
            });

            _handler.NewMessageReceive += ReceiveNewMessage;
        }

        public ObservableCollection<DialogModel> DialogsPreview { get; } = new ObservableCollection<DialogModel>();

        public async Task ReceiveNewMessage(Message newMessage)
        {
            var dialog = DialogsPreview.SingleOrDefault(k => k.DialogId == newMessage.DialogId);
            
            // TODO : Надо сделать добавление нового диалога
            if(dialog is null)
                return;

            await Application.Current.Dispatcher.InvokeAsync(() =>
            {
                dialog.UpdateLastMessage(newMessage.MessageText, newMessage.SendDate);
            });
        }
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