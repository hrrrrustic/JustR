using System;
using System.Collections.Generic;
using JustR.Models.Dto;
using JustR.Models.Entity;

namespace JustR.DialogService.Service
{
    public interface IDialogService
    {
        Dialog GetDialog(Guid dialogId);
        IEnumerable<Dialog> GetDialogsPreview(Guid userId, Int32? offset, Int32 count);
        Dialog CreateDialog(Guid firstUserId, Guid secondUserId);
    }
}