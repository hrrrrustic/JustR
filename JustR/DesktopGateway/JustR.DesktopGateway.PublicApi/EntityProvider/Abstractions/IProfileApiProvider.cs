using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JustR.ClientRelatedShare.Dto;
using JustR.Core.Entity;

namespace JustR.DesktopGateway.PublicApi.EntityProvider.Abstractions
{
    public interface IProfileApiProvider
    {
        Task<UserProfileDto> GetUserProfile(Guid userId);
        Task<IReadOnlyList<UserPreviewDto>> SearchUser(String query);
        Task<UserPreviewDto> GetUserPreview(Guid userId);
        Task<User> SimpleAuth(String userTag);
        Task<User> UpdateUserProfile(ChangeProfileDto newUserProfile);
    }
}