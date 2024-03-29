﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JustR.ClientRelatedShare.Dto;

namespace JustR.DesktopGateway.PublicApi.EntityProvider.Abstractions
{
    public interface IDialogApiProvider
    {
        Task<Guid> GetDialogId(Guid firstUserId, Guid secondUserid);
        Task<IReadOnlyList<DialogPreviewDto>> GetDialogs(Guid userId, Int32? offset, Int32 count);
        Task<DialogInfoDto> GetDialog(Guid dialogId, Guid userId);
        Task<DialogInfoDto> CreateDialog(Guid firstUserId, Guid secondUserId);
    }
}