using System;
using JustR.Core.Entity;

namespace JustR.ClientRelatedShare.Dto
{
    public class ChangeProfileDto
    {
        public Byte[] Avatar { get; set; }
        public Guid UserId { get; set; }

        public User ToUser()
        {
            return new User
            {
                UserId = UserId,
                Avatar = Avatar
            };
        }
    }
}