using System;
using System.Collections.Generic;
using System.Text;

namespace JustR.Models.Dto
{
    public class UserProfileDto
    {
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String UniqueTag { get; set; }
        public Byte[] Avatar { get; set; }
        public Guid UserId { get; set; }
        
    }
}
