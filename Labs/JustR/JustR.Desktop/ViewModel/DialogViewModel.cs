using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Input;
using Accessibility;
using JustR.Desktop.Commands;
using JustR.Desktop.Services.Abstractions;
using JustR.Desktop.Services.Implementations;
using JustR.Models.Dto;

namespace JustR.Desktop.ViewModel
{
    public class DialogViewModel : BaseViewModel
    {


        private readonly IDialogService _dialogService = new DummyDialogService();

        private readonly IMessageService _messageService = new DummyMessageService();
        public DialogViewModel()
        {
            SendMessage = new ActionCommand<String>(async arg =>
            {

                if (CurrentDialog.DialogId == Guid.Empty)
                {
                    CurrentDialog.DialogId = await _dialogService.CreateDialogAsync(new DialogPreviewDto
                    {
                        DialogName = CurrentDialog.Interlocutor.UserName,
                        InterlocutorPreview = CurrentDialog.Interlocutor,
                        LastMessageTime = DateTime.MinValue
                    });
                }

                MessageDto message = new MessageDto
                {
                    DialogId = CurrentDialog.DialogId,
                    SendDate = DateTime.Now,
                    MessageText = arg,
                    Sender = UserInfo.CurrentUser.ToUserPreviewDto()
                };

                await _messageService
                    .SendMessage(message)
                    .ContinueWith(task => Messages.Add(message), TaskScheduler.FromCurrentSynchronizationContext());

                TypedMessage = String.Empty;
            });
            

            GetMessages = new ActionCommand<Guid>(async arg =>
            {
                var messages = await _messageService.GetMessagesAsync(arg);
                CurrentDialog.DialogId = messages.DialogId;
                foreach (var message in messages.Messages)
                {
                    Messages.Add(message);
                }
            });

            GetDialogInfoCommand = new ActionCommand<Guid>(async arg => 
            {
                CurrentDialog = await _dialogService.GetDialogInfoAsync(arg);
            });
        }

        public void Test(UserPreviewDto dto)
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