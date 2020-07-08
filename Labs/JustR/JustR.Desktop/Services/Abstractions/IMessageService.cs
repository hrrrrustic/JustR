using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JustR.ClientRelatedShare.Dto;

namespace JustR.Desktop.Services.Abstractions
{
    public interface IMessageService
    {
        Task<IReadOnlyList<MessageDto>> GetMessagesAsync(Guid dialogId, Guid userId);
        Task SendMessage(MessageDto message);
    }
}