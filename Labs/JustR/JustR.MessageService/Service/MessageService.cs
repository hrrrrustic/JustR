using System;
using System.Collections.Generic;
using JustR.Models.Dto;

namespace JustR.MessageService.Service
{
    public class MessageService : IMessageService
    {
        public MessageDto SendMessage(Guid userId, Guid dialogId, String text)
        {
            throw new NotImplementedException();
        }

        public List<MessageDto> GetMessages(Guid userId, Guid dialogId, Int32? offset, Int32 count)
        {
            throw new NotImplementedException();
        }
    }
}