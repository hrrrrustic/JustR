using System;
using JustR.Models.Entity;

namespace JustR.DialogService.Repository
{
    public interface IDialogRepository
    {
        Dialog ReadDialog(Guid userId, Guid dialogId);
        Dialog CreateDialog(Guid firstUserId, Guid secondUserId);
    }
}