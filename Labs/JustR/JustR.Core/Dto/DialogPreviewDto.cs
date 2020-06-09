using System;
using JustR.Core.Entity;

namespace JustR.Core.Dto
{
    public class DialogPreviewDto
    {
        public Guid DialogId { get; }
        public DateTime LastMessageTime { get; }
        public String LastMessageText { get; }
        public UserPreviewDto InterlocutorPreview { get; }

        private DialogPreviewDto(UserPreviewDto preview) : this(Guid.Empty, DateTime.MinValue, null, preview)
        {
        }
        public static DialogPreviewDto NewDialog(UserPreviewDto preview)
        {
            return new DialogPreviewDto(preview);
        }
        private DialogPreviewDto(Guid dialogId, DateTime lastMessageTime, String lastMessageText, UserPreviewDto interlocutorPreview)
        {
            DialogId = dialogId;
            LastMessageTime = lastMessageTime;
            LastMessageText = lastMessageText;
            InterlocutorPreview = interlocutorPreview;
        }
        public static DialogPreviewDto FromDialogAndUser(Dialog dialog, User user)
        {
            DialogPreviewDto dto = new DialogPreviewDto(dialog.DialogId, dialog.LastMessageTime, dialog.LastMessageText,
                UserPreviewDto.FromUser(user));

            return dto;
        }

       
    }
}
