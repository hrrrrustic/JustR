using System;
using System.Collections.Generic;

namespace JustR.Core.Dto
{
    public class DialogMessagesDto
    {
        public Guid DialogId { get; }
        public List<MessageDto> Messages { get; }
    }
}