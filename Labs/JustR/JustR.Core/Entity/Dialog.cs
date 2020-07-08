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
            if (currentUserId == FirstUserId)
                return SecondUserid;

            if (currentUserId == SecondUserid)
                return FirstUserId;

            //TODO : Хоть сообщение какое-нибудь написать
            throw new ArgumentException();
        }
    }
}