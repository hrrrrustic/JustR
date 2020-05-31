using System;

namespace JustR.Core.Dto
{
    public class MessageDto
    {
        public Guid DialogId { get; set; }
        public UserPreviewDto Sender { get; set; }
        public String MessageText { get; set; }
        public DateTime SendDate { get; set; }
    }   
}