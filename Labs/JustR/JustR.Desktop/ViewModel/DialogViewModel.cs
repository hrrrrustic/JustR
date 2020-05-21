using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
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

        private readonly IProfileService _profileService = new DummyProfileService();

        private readonly IDialogService _dialogService = new DummyDialogService();

        private readonly IMessageService _messageService = new DummyMessageService();
        public DialogViewModel()
        {
            SendMessage = new ActionCommand<String>(async arg =>
            {
                var message = new MessageDto
                {
                    DialogId = CurrentDialogId,
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
                CurrentDialogId = messages.DialogId;
                foreach (var message in messages.Messages)
                {
                    Messages.Add(message);
                }
            });

            GetDialogInfoCommand = new ActionCommand<Guid>(async arg =>
            {
                var dialogInfo = await _dialogService.GetDialogInfoAsync(arg);
                Interlocutor = dialogInfo.Interlocutor;
            });
        }

        public Guid CurrentDialogId { get; set; }
        public ICommand GetMessages { get; }
        public ICommand GetDialogInfoCommand { get; }
        public UserPreviewDto Interlocutor { get; set; }

        public ObservableCollection<MessageDto> Messages { get; set; } = new ObservableCollection<MessageDto>();

        private String _typedMessage;
        public String TypedMessage
        {
            get => _typedMessage;
            set
            {
                _typedMessage = value;
                OnPropertyChanged();
            }
        }

        public ICommand SendMessage { get; set; }
    }
}