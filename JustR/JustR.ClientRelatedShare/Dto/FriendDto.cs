﻿using System;

namespace JustR.ClientRelatedShare.Dto
{
    public class FriendDto
    {
        public Guid UserId { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }

        public Byte[] Avatar { get; set; }
    }
}