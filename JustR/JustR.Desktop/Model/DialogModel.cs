using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using JustR.ClientRelatedShare.Dto;
using JustR.Desktop.Annotations;

namespace JustR.Desktop.Model
{
    public class DialogModel : INotifyPropertyChanged
    {
        private String _lastMessageText;
        private DateTime _lastMessageTime;

        public Guid DialogId { get; }

        public DateTime LastMessageTime
        {
            get => _lastMessageTime;
            private set
            {
                _lastMessageTime = value;
                OnPropertyChanged();
            }
        }

        public String LastMessageText
        {
            get => _lastMessageText;
            private set
            {
                _lastMessageText = value;
                OnPropertyChanged();
            }
        }

        public UserPreviewDto InterlocutorPreview { get; }

        private DialogModel(Guid dialogId, DateTime lastMessageTime, String lastMessageText,
            UserPreviewDto interlocutorPreview)
        {
            DialogId = dialogId;
            LastMessageTime = lastMessageTime;
            LastMessageText = lastMessageText;
            InterlocutorPreview = interlocutorPreview;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void UpdateLastMessage(String text, DateTime time)
        {
            LastMessageText = text;
            LastMessageTime = time;
        }

        public static DialogModel FromDto(DialogPreviewDto dto)
        {
            return new DialogModel(dto.DialogId, dto.LastMessageTime, dto.LastMessageText, dto.InterlocutorPreview);
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] String propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}