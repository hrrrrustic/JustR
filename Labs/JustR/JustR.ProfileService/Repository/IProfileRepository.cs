using System;
using JustR.Models.Dto;
using JustR.Models.Entity;

namespace JustR.ProfileService.Repository
{
    public interface IProfileRepository
    {
        User ReadUserProfile(Guid userId);
        User UpdateUserProfile(User newProfile);
        ChangeProfileDto UpdateUserProfile(ChangeProfileDto dto);
    }
}