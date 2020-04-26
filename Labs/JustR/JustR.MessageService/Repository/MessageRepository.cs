using System;
using System.Collections.Generic;
using JustR.Models.Entity;
using SqlKata.Compilers;

namespace JustR.MessageService.Repository
{
    public class MessageRepository : IMessageRepository
    {
        private readonly Compiler _sqlCompiler;

        public MessageRepository(Compiler sqlCompiler)
        {
            _sqlCompiler = sqlCompiler;
        }

        public List<Message> ReadMessages(Guid dialogId, Int32 count, Int32 offset = 0)
        {
            throw new NotImplementedException();
        }

        public Message CreateMessage(Message message)
        {
            throw new NotImplementedException();
        }
    }
}