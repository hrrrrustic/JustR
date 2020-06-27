using System;
using System.Collections.Generic;
using JustR.Core.Entity;

namespace JustR.MessageService.InternalApi
{
    public class HttpMessageApiProvider : IMessageApiProvider
    {
        public IReadOnlyList<Message> GetMessages(Guid dialogId, Int32 offset, Int32 count)
        {
            throw new NotImplementedException();
        }

        public Message SendMessage(Guid userId, Guid dialogId, Guid receiverId, String text)
        {
            throw new NotImplementedException();
        }
    }
}
