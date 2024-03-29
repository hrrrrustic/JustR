﻿using System;
using JustR.Core.Entity;

namespace JustR.ClientRelatedShare.Dto
{
    public class UserPreviewDto
    {
        public Guid UserId { get; set; }
        public String FirstName { get; set; }

        public String LastName { get; set; }
        public String UniqueTag { get; set; }
        public Byte[] Avatar { get; set; }

        private UserPreviewDto(Guid userId, String firstName, String lastName, String uniqueTag, Byte[] avatar)
        {
            UserId = userId;
            FirstName = firstName;
            LastName = lastName;
            UniqueTag = uniqueTag;
            Avatar = avatar;
        }

        public UserPreviewDto()
        {
        }

        public static UserPreviewDto FromUser(User user)
        {
            return new UserPreviewDto(user.UserId, user.FirstName, user.LastName, user.UniqueTag, user.Avatar);
        }
    }
}