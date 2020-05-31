using System;

namespace JustR.Core.Dto
{
    public class DialogInfoDto
    {
        public Guid DialogId { get; set; }
        
        public UserPreviewDto Interlocutor { get; set; }
        
    }
}
