using System;

namespace JustR.Core.Dto
{
    public class UserProfileDto
    {
        public String FirstName { get; }
        public String LastName { get; }
        public String UniqueTag { get; }
        public Byte[] Avatar { get; }
        public Guid UserId { get; }
        
    }
}
