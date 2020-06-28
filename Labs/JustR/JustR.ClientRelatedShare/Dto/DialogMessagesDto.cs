using System;
using System.Collections.Generic;

namespace JustR.ClientRelatedShare.Dto
{
    public class DialogMessagesDto
    {
        public Guid DialogId { get; set; }
        public List<MessageDto> Messages { get; set; }
    }
}