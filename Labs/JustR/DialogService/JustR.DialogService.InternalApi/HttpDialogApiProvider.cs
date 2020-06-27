using System;
using System.Collections.Generic;
using JustR.Core.Dto;
using JustR.Core.Entity;

namespace JustR.DialogService.InternalApi
{
    public class HttpDialogApiProvider : IDialogApiProvider
    {
        public Guid GetDialogId(Guid firstUserId, Guid secondUserId)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyList<DialogPreviewDto> GetDialogsPreview(Guid userId, Int32 count, Int32 offset)
        {
            throw new NotImplementedException();
        }

        public DialogInfoDto GetDialog(Guid dialogId)
        {
            throw new NotImplementedException();
        }

        public Dialog CreateDialog(Guid firstUserId, Guid secondUserId)
        {
            throw new NotImplementedException();
        }

        public void SendMessage(Guid dialogId, Guid authorId, String text)
        {
            throw new NotImplementedException();
        }
    }
}
