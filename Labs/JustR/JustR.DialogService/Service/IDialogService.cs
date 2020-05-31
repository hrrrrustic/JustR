using System;
using System.Collections.Generic;
using JustR.Core.Entity;
using JustR.Models.Entity;

namespace JustR.DialogService.Service
{
    public interface IDialogService
    {
        Dialog GetDialog(Guid dialogId);
        List<Dialog> GetDialogsPreview(Guid userId, Int32? offset, Int32 count);
        Dialog CreateDialog(Guid firstUserId, Guid secondUserId);
        Guid GetUserId(Guid firstUserId, Guid secondUserId);
        void UpdateLastMessage(Guid authorId, Guid dialogId, String text);
    }
}