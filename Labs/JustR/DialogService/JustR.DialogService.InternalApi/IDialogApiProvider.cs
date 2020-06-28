using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JustR.Core.Entity;

namespace JustR.DialogService.InternalApi
{
    public interface IDialogApiProvider
    {
        Task<Guid> GetDialogId(Guid firstUserId, Guid secondUserId);
        Task<IReadOnlyList<Dialog>> GetDialogsPreview(Guid userId, Int32 count, Int32 offset);
        Task<Dialog> GetDialog(Guid dialogId);
        Task<Dialog> CreateDialog(Guid firstUserId, Guid secondUserId);
        Task SendMessage(Guid dialogId, Guid authorId, String text);
    }
}