using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Accessibility;
using JustR.Desktop.Services.Abstractions;
using JustR.Models.Dto;

namespace JustR.Desktop.Services.Implementations
{
    public class DummyDialogService : IDialogService
    {
        private static readonly List<DialogPreviewDto> Dialogs = new List<DialogPreviewDto>
        {
            new DialogPreviewDto
            {
                DialogName = "Максим",
                DialogId = SampleData.SampleData.Maksim.DialogId,
                LastMessageText = "академия уже началась?",
                LastMessageTime = DateTime.Now.AddHours(-1),
                InterlocutorPreview = SampleData.SampleData.Maksim.ToUserPreviewDto()
            },
            new DialogPreviewDto
            {
                DialogName = "Зеленый",
                DialogId = SampleData.SampleData.Zeleniy.DialogId,
                LastMessageText = "Ага, держи в курсе",
                LastMessageTime = DateTime.Now.AddHours(-1),
                InterlocutorPreview = SampleData.SampleData.Zeleniy.ToUserPreviewDto()
            },
            new DialogPreviewDto
            {
                DialogName = "Сергей",
                DialogId = SampleData.SampleData.Sergey.DialogId,
                LastMessageText = "s4xack",
                LastMessageTime = DateTime.Now.AddHours(-1),
                InterlocutorPreview = SampleData.SampleData.Sergey.ToUserPreviewDto()
            },
            new DialogPreviewDto
            {
                DialogName = "Катя",
                DialogId = SampleData.SampleData.Katya.DialogId,
                LastMessageText = "я пират",
                LastMessageTime = DateTime.Now.AddHours(-1),
                InterlocutorPreview = SampleData.SampleData.Katya.ToUserPreviewDto()
            },
        };
        public async Task<List<DialogPreviewDto>> GetDialogsPreviewAsync(Guid userId)
        {
            return Dialogs;
        }

        public async Task<DialogInfoDto> GetDialogInfoAsync(Guid dialogId)
        {
            var dialog = Dialogs.Single(k => k.DialogId == dialogId);
            
            return new DialogInfoDto
            {
                DialogName = dialog.DialogName,
                Interlocutor = dialog.InterlocutorPreview,
                DialogId = dialog.DialogId
            };
        }

        public async Task<Guid> GetDialogIdAsync(Guid userId)
        {
            return Dialogs.SingleOrDefault(k => k.InterlocutorPreview.UserId == userId)?.DialogId ?? Guid.Empty;
        }

        public async Task<Guid> CreateDialogAsync(DialogPreviewDto newDialog)
        {
            newDialog.DialogId = Guid.NewGuid();
            Dialogs.Add(newDialog);
            return newDialog.DialogId;
        }

        public async Task UpdateDialogLastMessageInfo(Guid dialogId, String message, DateTime time)
        {
            var dialog = Dialogs.SingleOrDefault(k => k.DialogId == dialogId);

            if (dialog is null)
                return;

            dialog.LastMessageText = message;
            dialog.LastMessageTime = time;
        }
    }
}