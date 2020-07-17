using System;

namespace JustR.ClientRelatedShare.Dto
{
    public class DialogInfoDto
    {
        // TODO : Убрать бы сеттеры
        public Guid DialogId { get; set; }

        public UserPreviewDto Interlocutor { get; set; }

        public DialogInfoDto(Guid dialogId, UserPreviewDto interlocutor)
        {
            DialogId = dialogId;
            Interlocutor = interlocutor;
        }

        public DialogInfoDto()
        {
        }
    }
}