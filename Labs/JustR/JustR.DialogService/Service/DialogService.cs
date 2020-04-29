using System;
using System.Collections.Generic;
using JustR.Models.Dto;

namespace JustR.DialogService.Service
{
    public class DialogService : IDialogService
    {
        public DialogInfoDto GetDialog(Guid dialogId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DialogPreviewDto> GetDialogsPreview(Guid userId, Int32? offset, Int32 count)
        {
            throw new NotImplementedException();
        }

        public DialogInfoDto CreateDialog(Guid firstUserId, Guid secondUserId)
        {
            throw new NotImplementedException();
        }
    }
}