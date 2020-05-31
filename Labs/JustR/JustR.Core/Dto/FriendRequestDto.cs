using System;
using JustR.Core.Enum;

namespace JustR.Core.Dto
{
    public class FriendRequestDto
    {
        public Guid FirstUserId { get; set; }
        public Guid SecondUserId { get; set; }
        public RelationshipState State { get; set; }
    }
}
