using System;
using System.Collections.Generic;
using JustR.Core.Entity;

namespace JustR.MessageService.Service
{
    public interface IMessageService
    {
        Message SendMessage(Guid userId, Guid dialogId, String text);
        IReadOnlyList<Message> GetMessages(Guid userId, Guid dialogId, Int32? offset, Int32 count);
    }
}