using JustR.Core.Entity;
using System;
using System.Collections.Generic;

namespace JustR.MessageService.InternalApi
{
    public interface IMessageApiProvider
    {
        IReadOnlyList<Message> GetMessages(Guid dialogId, Int32 offset, Int32 count);
        Message SendMessage(Guid userId, Guid dialogId, Guid receiverId, String text);
    }
}