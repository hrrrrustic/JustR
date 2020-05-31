using System;

namespace JustR.Core.Dto
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
