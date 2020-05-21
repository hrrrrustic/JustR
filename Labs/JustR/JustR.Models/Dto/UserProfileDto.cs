﻿using System;
using System.Collections.Generic;
using System.Text;

namespace JustR.Models.Dto
{
    public class UserProfileDto
    {
        public String UserName { get; set; }
        public String UniqueTag { get; set; }
        public Byte[] Avatar { get; set; }
        public Guid UserId { get; set; }
        
    }
}
