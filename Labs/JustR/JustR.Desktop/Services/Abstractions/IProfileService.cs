using System;
using System.Threading.Tasks;
using JustR.Desktop.Annotations;
using JustR.Models.Dto;

namespace JustR.Desktop.Services.Abstractions
{
    public interface IProfileService
    {
        Task<UserPreviewDto> GetProfilePreviewAsync(Guid userId);
        Task<UserProfileDto> GetProfileAsync(Guid userId);
        [ItemCanBeNull] Task<UserPreviewDto> SimpleLogin(String userTag);
    }
}