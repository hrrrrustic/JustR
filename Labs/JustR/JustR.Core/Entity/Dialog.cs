using System;

namespace JustR.Core.Entity
{
    public class Dialog
    {
        public Guid DialogId { get; set; }
        public Guid FirstUserId { get; set; }
        public Guid SecondUserid { get; set; }
        public String? LastMessageText { get; set; }
        public Guid LastMessageAuthor { get; set; }
        public DateTime LastMessageTime { get; set; }

        public Guid GetInterlocutorId(Guid currentUserId)
        {
            return currentUserId == FirstUserId ? SecondUserid : FirstUserId;
        }
    }
}