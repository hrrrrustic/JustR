using System;
using System.Collections.Generic;
using System.Linq;
using JustR.Core.Entity;
using SqlKata.Compilers;

namespace JustR.MessageService.Repository
{
    public class MessageRepository : IMessageRepository
    {
        private readonly Compiler _sqlCompiler;

        private readonly MessageDbContext _context;

        public MessageRepository(Compiler sqlCompiler, MessageDbContext context)
        {
            _sqlCompiler = sqlCompiler;
            _context = context;
        }

        public IReadOnlyList<Message> ReadMessages(Guid dialogId, Int32 count, Int32 offset = 0)
        {
            return _context
                .Messages
                .Where(k => k.DialogId == dialogId)
                .Skip(offset)
                .Take(count)
                .ToList();
        }

        public Message CreateMessage(Message message)
        {
            message.MessageId = Guid.NewGuid();

            Message entity = _context.Messages.Add(message).Entity;
            _context.SaveChanges();

            return entity;
        }
    }
}