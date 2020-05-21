using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Documents;
using JustR.Models.Dto;

namespace JustR.Desktop.Services.Abstractions
{
    public interface IMessageService
    {
        Task<DialogMessagesDto> GetMessagesAsync(Guid dialogId);
        Task SendMessage(MessageDto message);
    }
}
