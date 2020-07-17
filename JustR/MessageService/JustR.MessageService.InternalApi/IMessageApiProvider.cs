using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JustR.Core.Entity;

namespace JustR.MessageService.InternalApi
{
    public interface IMessageApiProvider
    {
        Task<IReadOnlyList<Message>> GetMessages(Guid dialogId, Int32 offset, Int32 count);
        Task<Message> SendMessage(Guid userId, Guid dialogId, Guid receiverId, String text);
    }
}