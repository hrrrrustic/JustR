using System;
using JustR.Core.Entity;

namespace JustR.Core.Dto
{
    public class MessageDto
    {
        public Guid DialogId { get; }
        public UserPreviewDto Sender { get; }
        public String MessageText { get; }
        public DateTime SendDate { get; }

        private MessageDto(Guid dialogId, String messageText, DateTime sendDate, UserPreviewDto preview)
        {
            DialogId = dialogId;
            Sender = preview;
            MessageText = messageText;
            SendDate = sendDate;
        }
        public static MessageDto FromMessageAndUser(User user, Message message)
        {
            MessageDto dto = new MessageDto(message.DialogId, message.MessageText, message.SendDate,
                UserPreviewDto.FromUser(user));
            
            return dto;
        }

        public static MessageDto NewMessage(Guid dialogId, String messageText, User sender)
        {
            return new MessageDto(dialogId, messageText, DateTime.MinValue, UserPreviewDto.FromUser(sender));
        }
    }   
}