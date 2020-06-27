using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JustR.Core.Dto;

namespace JustR.DesktopGateway.PublicApi.EntityProvider
{
    public interface IProfileApiProvider
    {
        Task<UserProfileDto> GetUserProfile(Guid userId);
        Task<IReadOnlyList<UserPreviewDto>> SearchUser(String query);
        Task<UserPreviewDto> GetUserPreview(Guid userId);
        Task<UserPreviewDto> SimpleAuth(String userTag);
    }
}