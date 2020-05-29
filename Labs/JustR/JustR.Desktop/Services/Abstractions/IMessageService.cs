using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Documents;
using JustR.Models.Dto;

namespace JustR.Desktop.Services.Abstractions
{
    public interface IMessageService
    {
        Task<List<MessageDto>> GetMessagesAsync(Guid dialogId, Guid userId);
        Task SendMessage(MessageDto message);
    }
}
