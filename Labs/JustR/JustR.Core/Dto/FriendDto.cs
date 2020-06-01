using System;

namespace JustR.Core.Dto
{
    public class FriendDto
    {
        public Guid UserId { get; }
        public String FirstName { get; }
        public String LastName { get; }

        public Byte[] Avatar { get; }
    }
}