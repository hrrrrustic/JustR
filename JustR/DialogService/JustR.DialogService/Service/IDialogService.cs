using System;
using System.Collections.Generic;
using JustR.Core.Entity;

namespace JustR.DialogService.Service
{
    public interface IDialogService
    {
        Dialog FindDialog(Guid dialogId);
        IReadOnlyList<Dialog> FindDialogsPreview(Guid userId, Int32? offset, Int32 count);
        Dialog CreateDialog(Guid firstUserId, Guid secondUserId);
        Guid FindDialogId(Guid firstUserId, Guid secondUserId);
        Dialog UpdateLastMessage(Guid authorId, Guid dialogId, String text);
    }
}