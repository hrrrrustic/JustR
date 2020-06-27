using System;
using System.Collections.Generic;
using JustR.Core.Entity;

namespace JustR.DialogService.Repository
{
    public interface IDialogRepository
    {
        Dialog ReadDialog(Guid dialogId);
        Dialog CreateDialog(Dialog dialog);
        IReadOnlyList<Dialog> ReadDialogs(Guid userId, Int32 count, Int32 offset = 0);
        Guid ReadDialogId(Guid firstUserId, Guid secondUserId);
        Dialog UpdateLastMessage(Guid dialogId, Guid authorId, String text, DateTime sendDate);
    }
}