using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using JustR.ClientRelatedShare.Dto;
using JustR.Core.Entity;
using JustR.Desktop.Commands;
using JustR.Desktop.Notifications;
using JustR.Desktop.Services.Abstractions;
using JustR.Desktop.Services.Implementations;

namespace JustR.Desktop.ViewModel
{
    //TODO : Прикрутить наконец-то di
    public class DialogViewModel : BaseViewModel
    {
        private readonly IDialogService _dialogService = new DialogService();

        private readonly IMessageService _messageService = new MessageService();

        private readonly NotificationHandler _handler = NotificationHandler.Instance.Value;
        public DialogViewModel()
        {
            SendMessage = new ActionCommand<String>(async arg =>
            {

                if (CurrentDialog.DialogId == Guid.Empty)
                {
                    DialogInfoDto info = await _dialogService
                        .CreateDialogAsync(DialogPreviewDto.NewDialog(CurrentDialog.Interlocutor));

                    CurrentDialog.DialogId = info.DialogId;
                }

                MessageDto message = MessageDto.NewMessage(CurrentDialog.DialogId, arg, UserInfo.CurrentUser);

                await _messageService
                    .SendMessage(message);

                TypedMessage = String.Empty;
            });
            

            GetMessages = new ActionCommand<Guid>(async arg =>
            {
                var messages = await _messageService.GetMessagesAsync(arg, UserInfo.CurrentUser.UserId);
                //TODO : Кажется это не нужно
                CurrentDialog.DialogId = messages.First().DialogId;

                foreach (var message in messages)
                    Messages.Add(message);
            });

            GetDialogInfoCommand = new ActionCommand<Guid>(async arg => 
            {
                CurrentDialog = await _dialogService.GetDialogInfoAsync(arg, UserInfo.CurrentUser.UserId);
            });

            _handler.NewMessageReceive += NewMessageReceive;
         }

        public async Task NewMessageReceive(Message newMessage)
        {
            if(CurrentDialog.DialogId != newMessage.DialogId)
                return;

            MessageDto dto = new MessageDto();

            dto.Sender = newMessage.AuthorId == UserInfo.CurrentUser.UserId
                ? UserPreviewDto.FromUser(UserInfo.CurrentUser)
                : CurrentDialog.Interlocutor;

            dto.SendDate = newMessage.SendDate;
            dto.MessageText = newMessage.MessageText;

            await Application.Current.Dispatcher.InvokeAsync(() => Messages.Add(dto));
        }

        public void SetInterlocutor(UserPreviewDto dto)
        {
            _currentDialog.Interlocutor = dto;
            OnPropertyChanged(nameof(CurrentDialog));
        }
        public DialogInfoDto CurrentDialog
        {
            get => _currentDialog;
            set
            {
                _currentDialog = value;
                OnPropertyChanged();
            }
        }

        public ICommand GetMessages { get; }

        public ICommand GetDialogInfoCommand { get; }

        public ObservableCollection<MessageDto> Messages { get; } = new ObservableCollection<MessageDto>();

        private String _typedMessage;
        private DialogInfoDto _currentDialog;

        public String TypedMessage
        {
            get => _typedMessage;
            set
            {
                _typedMessage = value;
                OnPropertyChanged();
            }
        }

        public ICommand SendMessage { get; }
    }
}