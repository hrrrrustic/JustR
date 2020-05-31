using System;
using JustR.Core.Entity;

namespace JustR.Core.Dto
{
    public class DialogPreviewDto
    {
        public Guid DialogId { get; set; }
        public DateTime LastMessageTime { get; set; }
        public String LastMessageText { get; set; }
        public UserPreviewDto InterlocutorPreview { get; set; }
        public static DialogPreviewDto FromDialogAndUser(Dialog dialog, User user)
        {
            DialogPreviewDto dto = new DialogPreviewDto
            {
                DialogId = dialog.DialogId,
                LastMessageText = dialog.LastMessageText,
                LastMessageTime = dialog.LastMessageTime,
                InterlocutorPreview = UserPreviewDto.FromUser(user)
            };

            return dto;
        }
    }
}
