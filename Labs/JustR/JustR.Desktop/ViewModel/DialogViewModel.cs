using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using JustR.Core.Dto;
using JustR.Desktop.Commands;
using JustR.Desktop.Services.Abstractions;
using JustR.Desktop.Services.Implementations;

namespace JustR.Desktop.ViewModel
{
    //TODO : Прикрутить наконец-то di
    public class DialogViewModel : BaseViewModel
    {
        private readonly IDialogService _dialogService = new DialogService();

        private readonly IMessageService _messageService = new MessageService();
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
                    .SendMessage(message)
                    .ContinueWith(task => Messages.Add(message), TaskScheduler.FromCurrentSynchronizationContext());

                TypedMessage = String.Empty;
            });
            

            GetMessages = new ActionCommand<Guid>(async arg =>
            {
                var messages = await _messageService.GetMessagesAsync(arg, UserInfo.CurrentUser.UserId);
                CurrentDialog.DialogId = messages.First().DialogId;
                foreach (var message in messages)
                {
                    Messages.Add(message);
                }
            });

            GetDialogInfoCommand = new ActionCommand<Guid>(async arg => 
            {
                CurrentDialog = await _dialogService.GetDialogInfoAsync(arg, UserInfo.CurrentUser.UserId);
            });
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