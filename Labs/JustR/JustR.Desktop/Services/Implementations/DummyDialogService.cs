using System;
using System.Collections.Generic;
using System.IO;
using JustR.Desktop.Services.Abstractions;
using JustR.Models.Dto;

namespace JustR.Desktop.Services.Implementations
{
    public class DummyDialogService : IDialogService
    {
        private readonly List<DialogPreviewDto> Dialogs = new List<DialogPreviewDto>
        {
            new DialogPreviewDto
            {
                DialogName = "Максим",
                LastMessageText = "застрял в порталах",
                LastMessageTime = DateTime.Now.AddHours(-1),
                InterlocutorPreview = new UserPreviewDto
                {
                    Avatar = File.ReadAllBytes("C:\\Users\\hrrrrustic\\OneDrive\\Desktop\\Maksim.jpg"),
                    UniqueTag = null,
                    UserName = null
                }
            },
            new DialogPreviewDto
            {
                DialogName = "Зеленый",
                LastMessageText = "Осуждаю линки!",
                LastMessageTime = DateTime.Now.AddHours(-1),
                InterlocutorPreview = new UserPreviewDto
                {
                    Avatar = File.ReadAllBytes("C:\\Users\\hrrrrustic\\OneDrive\\Desktop\\Кисик.jpg"),
                    UniqueTag = null,
                    UserName = null
                }
            },
            new DialogPreviewDto
            {
                DialogName = "Сергей",
                LastMessageText = "эсчухак",
                LastMessageTime = DateTime.Now.AddHours(-1),
                InterlocutorPreview = new UserPreviewDto
                {
                    Avatar = File.ReadAllBytes("C:\\Users\\hrrrrustic\\OneDrive\\Desktop\\Sergey.jpg"),
                    UniqueTag = null,
                    UserName = null
                }
            },
            new DialogPreviewDto
            {
                DialogName = "Катя",
                LastMessageText = "купи лицуху цивы",
                LastMessageTime = DateTime.Now.AddHours(-1),
                InterlocutorPreview = new UserPreviewDto
                {
                    Avatar = File.ReadAllBytes("C:\\Users\\hrrrrustic\\OneDrive\\Desktop\\Katya.jpg"),
                    UniqueTag = null,
                    UserName = null
                }
            },
        };
        public List<DialogPreviewDto> GetDialogsPreview(Guid userId)
        {
            return Dialogs;
        }
    }
}
