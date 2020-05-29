using System;
using System.Collections.Generic;
using System.Linq;
using JustR.Models.Entity;

namespace JustR.MessageService.Repository
{
    public class DummyMessageRepository : IMessageRepository
    {
        private static List<Message> _dummyDb = new List<Message>
        {
            new Message
            {
                AuthorId = Guid.NewGuid(),
                DialogId = Guid.Parse("70A8359E-12B3-4B07-90BC-3E9D0EA11715"),
                MessageId = Guid.NewGuid(),
                MessageText = "MESSAGE 1",
                SendDate = DateTime.MinValue
            },
            new Message
            {
                AuthorId = Guid.NewGuid(),
                DialogId = Guid.Parse("70A8359E-12B3-4B07-90BC-3E9D0EA11715"),
                MessageId = Guid.NewGuid(),
                MessageText = "MESSAGE 2",
                SendDate = DateTime.MaxValue
            },
            new Message
            {
                AuthorId = Guid.NewGuid(),
                DialogId = Guid.Parse("A8286A35-E894-472F-BFA0-81695010D8DB"),
                MessageId = Guid.NewGuid(),
                MessageText = "MESSAGE 1",
                SendDate = DateTime.MinValue
            },

        };
        public List<Message> ReadMessages(Guid dialogId, Int32 count, Int32 offset = 0)
        {
            return _dummyDb
                .Where(k => k.DialogId == dialogId)
                .OrderBy(k => k.SendDate)
                .Skip(offset)
                .Take(count)
                .ToList();
        }

        public Message CreateMessage(Message message)
        {
            Guid msgId = Guid.NewGuid();
            message.MessageId = msgId;
            _dummyDb.Add(message);
            return _dummyDb.Single(k => k.MessageId == msgId);
        }
    }
}