using JustR.Core.Dto;
using System;
using System.Collections.Generic;
using JustR.Core.Entity;

namespace JustR.DialogService.InternalApi
{
    public interface IDialogApiProvider
    {
        Guid GetDialogId(Guid firstUserId, Guid secondUserId);
        IReadOnlyList<DialogPreviewDto> GetDialogsPreview(Guid userId, Int32 count, Int32 offset);
        DialogInfoDto GetDialog(Guid dialogId);
        Dialog CreateDialog(Guid firstUserId, Guid secondUserId);
        void SendMessage(Guid dialogId, Guid authorId, String text);
    }
}