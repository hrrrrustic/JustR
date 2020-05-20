using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using JustR.Desktop.Commands;
using JustR.Models.Dto;

namespace JustR.Desktop.ViewModel
{
    public class DialogViewModel : BaseViewModel
    {
        public DialogViewModel()
        {
            SendMessage = new ActionCommand<String>(arg =>
            {
                Messages.Add(new MessageDto
                {
                    SendDate = DateTime.Now,
                    MessageText = arg
                });
                TypedMessage = String.Empty;
            });
        }
        public ObservableCollection<MessageDto> Messages { get; set; } = new ObservableCollection<MessageDto>
        {
            new MessageDto
            {
                MessageText = "Message 1",
                SendDate = DateTime.MinValue
            },
            new MessageDto
            {
                MessageText = "Message 2",
                SendDate = DateTime.MaxValue
            }
        };

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