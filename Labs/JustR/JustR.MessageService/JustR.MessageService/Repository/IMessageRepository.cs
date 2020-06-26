using System;
using System.Collections.Generic;
using JustR.Core.Entity;

namespace JustR.MessageService.Repository
{
    public interface IMessageRepository
    {
        IReadOnlyList<Message> ReadMessages(Guid dialogId, Int32 count, Int32 offset = 0);
        Message CreateMessage(Message message);
    }
}