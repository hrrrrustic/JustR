using System;
using System.Collections.Generic;
using JustR.Core.Entity;

namespace JustR.DialogService.Repository
{
    public interface IDialogRepository
    {
        Dialog FindDialog(Guid dialogId);
        Dialog CreateDialog(Dialog dialog);
        IReadOnlyList<Dialog> FindDialogs(Guid userId, Int32 count, Int32 offset = 0);
        Guid FindDialogId(Guid firstUserId, Guid secondUserId);
        Dialog UpdateLastMessage(Guid dialogId, Guid authorId, String text, DateTime sendDate);
    }
}