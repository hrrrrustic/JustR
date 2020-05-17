using System;

namespace JustR.Models.Dto
{
    public class FriendDto
    {
        public Guid UserId { get; set; }
        public String Name { get; set; }
        public Byte[] Avatar { get; set; }
    }
}