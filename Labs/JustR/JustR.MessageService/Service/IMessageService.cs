using System;
using System.Collections.Generic;
using JustR.Models.Dto;
using JustR.Models.Entity;

namespace JustR.MessageService.Service
{
    public interface IMessageService
    {
        Message SendMessage(Guid userId, Guid dialogId, String text);
        List<Message> GetMessages(Guid userId, Guid dialogId, Int32? offset, Int32 count);
    }
}