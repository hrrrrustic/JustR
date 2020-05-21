using System;
using System.Threading.Tasks;
using JustR.Models.Dto;

namespace JustR.Desktop.Services.Abstractions
{
    public interface IProfileService
    {
        Task<UserPreviewDto> GetProfilePreviewAsync(Guid userId);
        Task<UserProfileDto> GetProfileAsync(Guid userId);
    }
}