using System;
using System.Collections.Generic;
using System.Linq;
using JustR.MessageService.Repository;
using JustR.Models.Dto;
using JustR.Models.Entity;

namespace JustR.MessageService.Service
{
    public class DummyMessageService : IMessageService
    {
        private readonly IMessageRepository _messageRepository;

        public DummyMessageService(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public Message SendMessage(Guid userId, Guid dialogId, String text)
        {
            Message res = _messageRepository.CreateMessage(new Message
            {
                AuthorId = userId, DialogId = dialogId, MessageText = text, SendDate = DateTime.Now
            });

            return new Message
            {
                MessageText = res.MessageText, SendDate = res.SendDate
            };
        }

        public List<Message> GetMessages(Guid userId, Guid dialogId, Int32? offset, Int32 count)
        {
            List<Message> res = _messageRepository.ReadMessages(dialogId, count, offset ?? 0);

            return res.ToList();
        }
    }
}