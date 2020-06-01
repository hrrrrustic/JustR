using System;

namespace JustR.Core.Dto
{
    public class DialogInfoDto
    {
        public DialogInfoDto(Guid dialogId, UserPreviewDto interlocutor)
        {
            DialogId = dialogId;
            Interlocutor = interlocutor;
        }

        public DialogInfoDto()
        {
            
        }

        // TODO : Убрать бы сеттеры
        public Guid DialogId { get; set; }
        
        public UserPreviewDto Interlocutor { get; set; }
        
    }
}
