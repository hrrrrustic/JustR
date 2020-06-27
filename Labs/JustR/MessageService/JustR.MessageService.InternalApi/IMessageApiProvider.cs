using JustR.Core.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JustR.MessageService.InternalApi
{
    public interface IMessageApiProvider
    {
        Task<IReadOnlyList<Message>> GetMessages(Guid dialogId, Int32 offset, Int32 count);
        Task<Message> SendMessage(Guid userId, Guid dialogId, Guid receiverId, String text);
    }
}