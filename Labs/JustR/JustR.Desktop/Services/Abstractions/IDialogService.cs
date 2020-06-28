using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JustR.ClientRelatedShare.Dto;

namespace JustR.Desktop.Services.Abstractions
{
    public interface IDialogService
    {
        Task<IReadOnlyList<DialogPreviewDto>> GetDialogsPreviewAsync(Guid userId);
        Task<DialogInfoDto> GetDialogInfoAsync(Guid dialogId, Guid userId);
        Task<Guid> GetDialogIdAsync(Guid userId, Guid secondUserId);
        Task<DialogInfoDto> CreateDialogAsync(DialogPreviewDto newDialog);
    }
}
