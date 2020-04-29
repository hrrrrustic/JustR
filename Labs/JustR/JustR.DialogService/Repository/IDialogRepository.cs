using System;
using System.Collections.Generic;
using JustR.Models.Entity;

namespace JustR.DialogService.Repository
{
    public interface IDialogRepository
    {
        Dialog ReadDialog(Guid dialogId);
        Dialog CreateDialog(Guid firstUserId, Guid secondUserId);
        IEnumerable<Dialog> ReadDialogs(Guid userId, Int32 count, Int32 offset = 0);
    }
}