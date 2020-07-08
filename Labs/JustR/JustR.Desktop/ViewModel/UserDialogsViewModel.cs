using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using JustR.ClientRelatedShare.Dto;
using JustR.Core.Entity;
using JustR.Desktop.Commands;
using JustR.Desktop.Model;
using JustR.Desktop.Notifications;
using JustR.Desktop.Services.Abstractions;
using JustR.Desktop.Services.Implementations;
using JustR.Desktop.View;

namespace JustR.Desktop.ViewModel
{
    public class UserDialogsViewModel : BaseViewModel
    {
        private readonly IDialogService _dialogService;

        private readonly NotificationHandler _handler = NotificationHandler.Instance.Value;

        private readonly IProfileService _profileService;
        private Page _currentDialog = new DialogEmptyPage();

        public ObservableCollection<DialogModel> DialogsPreview { get; } = new ObservableCollection<DialogModel>();

        public ICommand OpenDialogByDialogId => new ActionCommand<Guid>(arg =>
        {
            Page page = new DialogPage(new DialogViewModel(new DialogService(), new MessageService()));
            DialogViewModel viewModel = page.GetViewModel<DialogViewModel>();

            viewModel.CurrentDialog = new DialogInfoDto();
            viewModel.GetMessages.Execute(arg);
            viewModel.GetDialogInfoCommand.Execute(arg);

            CurrentDialog = page;
        });

        public ICommand OpenDialogByInterlocutorId => new ActionCommand<Guid>(async arg =>
        {
            Page page = new DialogPage(new DialogViewModel(new DialogService(), new MessageService()));

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

        public Page CurrentDialog
        {
            get => _currentDialog;
            set
            {
                _currentDialog = value;
                OnPropertyChanged();
            }
        }

        public UserDialogsViewModel(IDialogService dialogService, IProfileService profileService)
        {
            _profileService = profileService;
            _dialogService = dialogService;
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

        public async Task ReceiveNewMessage(Message newMessage)
        {
            DialogModel dialog = DialogsPreview.SingleOrDefault(k => k.DialogId == newMessage.DialogId);

            // TODO : Надо сделать добавление нового диалога
            if (dialog is null)
                return;

            await Application.Current.Dispatcher.InvokeAsync(() =>
            {
                dialog.UpdateLastMessage(newMessage.MessageText, newMessage.SendDate);
            });
        }
    }
}