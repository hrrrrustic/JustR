using System;
using System.Collections.Generic;
using JustR.Models.Dto;

namespace JustR.Desktop.Services.Abstractions
{
    public interface IDialogService
    {
        List<DialogPreviewDto> GetDialogsPreview(Guid userId);
    }
}
