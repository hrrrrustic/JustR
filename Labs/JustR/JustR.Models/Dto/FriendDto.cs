﻿using System;

namespace JustR.Models.Dto
{
    public class FriendDto
    {
        public Guid UserId { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }

        public Byte[] Avatar { get; set; }
    }
}