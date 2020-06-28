using System;

namespace JustR.ClientRelatedShare.Dto
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
