using System;

namespace JustR.Core.Entity
{
    public class Message
    {
        public Guid MessageId { get; set; }
        public String MessageText { get; set; }
        public DateTime SendDate { get; set; }
        public Guid AuthorId { get; set; }
        public Guid DialogId { get; set; }
    }
}