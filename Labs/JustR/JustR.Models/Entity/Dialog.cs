using System;

namespace JustR.Models.Entity
{
    public class Dialog
    {
        public Guid DialogId { get; set; }
        public Guid FirstUserId { get; set; }
        public Guid SecondUserid { get; set; }
        public String DialogName { get; set; }
        public String LastMessageText { get; set; }
        public Guid LastMessageAuthor { get; set; }
        public DateTime LastMessageTime { get; set; }
    }
}