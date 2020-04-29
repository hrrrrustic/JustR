using System;
using JustR.Models.Enum;

namespace JustR.Models.Entity
{
    public class FriendRequest
    {
        public Guid FirstUserId { get; set; }
        public Guid SecondUserId { get; set; }
        public FriendRequestState State { get; set; }
    }
}