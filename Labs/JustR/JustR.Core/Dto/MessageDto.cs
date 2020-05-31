using System;
using JustR.Core.Entity;

namespace JustR.Core.Dto
{
    public class MessageDto
    {
        public Guid DialogId { get; set; }
        public UserPreviewDto Sender { get; set; }
        public String MessageText { get; set; }
        public DateTime SendDate { get; set; }

        public static MessageDto FromMessageAndUser(User user, Message message)
        {
            MessageDto dto = new MessageDto
            {
                DialogId = message.DialogId,
                MessageText = message.MessageText,
                SendDate = message.SendDate,
                Sender = UserPreviewDto.FromUser(user)
            };

            return dto;
        }
    }   
}