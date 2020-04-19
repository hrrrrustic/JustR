using System;
using System.Collections.Generic;
using System.Text;
using JustR.Models.Enum;

namespace JustR.Models.Dto
{
    public class FriendRequestDto
    {
        public Guid UserId { get; set; }
        public FriendRequestState State { get; set; }
    }
}
