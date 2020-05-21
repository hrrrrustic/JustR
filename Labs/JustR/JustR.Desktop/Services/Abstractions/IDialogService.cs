using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JustR.Models.Dto;

namespace JustR.Desktop.Services.Abstractions
{
    public interface IDialogService
    {
        Task<List<DialogPreviewDto>> GetDialogsPreviewAsync(Guid userId);
        Task<DialogInfoDto> GetDialogInfoAsync(Guid dialogId);
        Task<Guid> GetDialogIdAsync(Guid userId);
        Task<Guid> CreateDialogAsync(DialogPreviewDto newDialog);
        Task UpdateDialogLastMessageInfo(Guid dialogId, String message, DateTime time);
    }
}
