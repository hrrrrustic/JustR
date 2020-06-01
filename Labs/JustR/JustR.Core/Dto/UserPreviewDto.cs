using System;
using JustR.Core.Entity;

namespace JustR.Core.Dto
{
    public class UserPreviewDto
    {
        private UserPreviewDto(Guid userId, String firstName, String lastName, String uniqueTag, Byte[] avatar)
        {
            UserId = userId;
            FirstName = firstName;
            LastName = lastName;
            UniqueTag = uniqueTag;
            Avatar = avatar;
        }

        public Guid UserId { get; }
        public String FirstName { get; }

        public String LastName { get; }
        public String UniqueTag { get; }
        public Byte[] Avatar { get; }

        public static UserPreviewDto FromUser(User user)
        {
            return new UserPreviewDto(user.UserId, user.FirstName, user.LastName, user.UniqueTag, user.Avatar);
        }
    }
}