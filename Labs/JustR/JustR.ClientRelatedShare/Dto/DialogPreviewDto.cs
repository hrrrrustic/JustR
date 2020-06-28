using JustR.Core.Entity;
using System;

namespace JustR.ClientRelatedShare.Dto
{
    public class DialogPreviewDto
    {
        public Guid DialogId { get; set; }
        public DateTime LastMessageTime { get; set; }
        public String LastMessageText { get; set; }
        public UserPreviewDto InterlocutorPreview { get; set; }

        private DialogPreviewDto(UserPreviewDto preview) : this(Guid.Empty, DateTime.MinValue, null, preview)
        {
        }

        public DialogPreviewDto()
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
