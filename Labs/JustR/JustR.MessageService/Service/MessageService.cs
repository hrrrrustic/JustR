using System;
using System.Collections.Generic;
using JustR.Core.Entity;
using JustR.MessageService.Repository;
using JustR.Models.Entity;

namespace JustR.MessageService.Service
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository _messageRepository;

        public MessageService(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public Message SendMessage(Guid userId, Guid dialogId, String text)
        {
            Message message = new Message
            {
                AuthorId = userId,
                DialogId = dialogId,
                MessageText = text,
                SendDate = DateTime.Now
            };

            return _messageRepository.CreateMessage(message);
        }

        public List<Message> GetMessages(Guid userId, Guid dialogId, Int32? offset, Int32 count)
        {
            return _messageRepository.ReadMessages(dialogId, count, offset ?? 0);
        }
    }
}