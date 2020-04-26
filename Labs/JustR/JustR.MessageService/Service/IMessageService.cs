using System;
using System.Collections.Generic;
using JustR.Models.Dto;

namespace JustR.MessageService.Service
{
    public interface IMessageService
    {
        MessageDto SendMessage(Guid userId, Guid dialogId, String text);
        List<MessageDto> GetMessages(Guid userId, Guid dialogId, Int32? offset, Int32 count);
    }
}