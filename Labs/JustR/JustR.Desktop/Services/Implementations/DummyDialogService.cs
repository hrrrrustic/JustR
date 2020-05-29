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
                DialogId = SampleData.SampleData.Maksim.DialogId,
                LastMessageText = "академия уже началась?",
                LastMessageTime = DateTime.Now.AddHours(-1),
                InterlocutorPreview = SampleData.SampleData.Maksim.ToUserPreviewDto()
            },
            new DialogPreviewDto
            {
                DialogId = SampleData.SampleData.Zeleniy.DialogId,
                LastMessageText = "Ага, держи в курсе",
                LastMessageTime = DateTime.Now.AddHours(-1),
                InterlocutorPreview = SampleData.SampleData.Zeleniy.ToUserPreviewDto()
            },
            new DialogPreviewDto
            {
                DialogId = SampleData.SampleData.Sergey.DialogId,
                LastMessageText = "s4xack",
                LastMessageTime = DateTime.Now.AddHours(-1),
                InterlocutorPreview = SampleData.SampleData.Sergey.ToUserPreviewDto()
            },
            new DialogPreviewDto
            {
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

        public async Task<DialogInfoDto> GetDialogInfoAsync(Guid dialogId, Guid userId)
        {
            var dialog = Dialogs.Single(k => k.DialogId == dialogId);
            
            return new DialogInfoDto
            {
                Interlocutor = dialog.InterlocutorPreview,
                DialogId = dialog.DialogId
            };
        }

        public async Task<Guid> GetDialogIdAsync(Guid firstUserId, Guid secondUserId)
        {
            return Dialogs.SingleOrDefault(k => k.InterlocutorPreview.UserId == firstUserId)?.DialogId ?? Guid.Empty;
        }

        public async Task<DialogInfoDto> CreateDialogAsync(DialogPreviewDto newDialog)
        {
            throw new NotImplementedException();

            newDialog.DialogId = Guid.NewGuid();
            Dialogs.Add(newDialog);
           // return newDialog.DialogId;
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