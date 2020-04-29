using System;
using System.Collections.Generic;
using System.Text;
using JustR.Models.Enum;

namespace JustR.Models.Dto
{
    public class FriendRequestDto
    {
        public Guid FirstUserId { get; set; }
        public Guid SecondUserId { get; set; }

        public FriendRequestState State { get; set; }
    }
}
