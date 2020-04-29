using System;
using System.Collections.Generic;
using JustR.Models.Dto;
using JustR.Models.Entity;

namespace JustR.DialogService.Service
{
    public interface IDialogService
    {
        DialogInfoDto GetDialog(Guid dialogId);
        IEnumerable<DialogPreviewDto> GetDialogsPreview(Guid userId, Int32? offset, Int32 count);
        DialogInfoDto CreateDialog(Guid firstUserId, Guid secondUserId);
    }
}