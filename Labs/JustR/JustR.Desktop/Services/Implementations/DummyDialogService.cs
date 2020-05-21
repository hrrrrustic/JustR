using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using JustR.Desktop.Services.Abstractions;
using JustR.Models.Dto;

namespace JustR.Desktop.Services.Implementations
{
    public class DummyDialogService : IDialogService
    {
        private readonly IMessageService _messageService = new DummyMessageService();
        private static readonly List<DialogPreviewDto> Dialogs = new List<DialogPreviewDto>
        {
            new DialogPreviewDto
            {
                DialogName = "Максим",
                DialogId = SampleData.SampleData.Maksim.DialogId,
                LastMessageText = "застрял в порталах",
                LastMessageTime = DateTime.Now.AddHours(-1),
                InterlocutorPreview = new UserPreviewDto
                {
                    Avatar = SampleData.SampleData.Maksim.Avatar,
                    UniqueTag = null,
                    UserName = null,
                    UserId = SampleData.SampleData.Maksim.UserId
                }
            },
            new DialogPreviewDto
            {
                DialogName = "Зеленый",
                DialogId = SampleData.SampleData.Zeleniy.DialogId,
                LastMessageText = "Осуждаю линки!",
                LastMessageTime = DateTime.Now.AddHours(-1),
                InterlocutorPreview = new UserPreviewDto
                {
                    Avatar = SampleData.SampleData.Zeleniy.Avatar,
                    UniqueTag = null,
                    UserName = null,
                    UserId = SampleData.SampleData.Zeleniy.UserId
                }
            },
            new DialogPreviewDto
            {
                DialogName = "Сергей",
                DialogId = SampleData.SampleData.Sergey.DialogId,
                LastMessageText = "эсчухак",
                LastMessageTime = DateTime.Now.AddHours(-1),
                InterlocutorPreview = new UserPreviewDto
                {
                    Avatar = SampleData.SampleData.Sergey.Avatar,
                    UniqueTag = null,
                    UserName = null,
                    UserId = SampleData.SampleData.Sergey.UserId
                }
            },
            new DialogPreviewDto
            {
                DialogName = "Катя",
                DialogId = SampleData.SampleData.Katya.DialogId,
                LastMessageText = "купи лицуху цивы",
                LastMessageTime = DateTime.Now.AddHours(-1),
                InterlocutorPreview = new UserPreviewDto
                {
                    Avatar = SampleData.SampleData.Katya.Avatar,
                    UniqueTag = null,
                    UserName = null,
                    UserId = SampleData.SampleData.Katya.UserId
                }
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
                Interlocutor = dialog.InterlocutorPreview
            };
        }
    }
}
