using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JustR.ClientRelatedShare.Dto;

namespace JustR.Desktop.Services.Abstractions
{
    public interface ISearchService
    {
        Task<IReadOnlyList<UserPreviewDto>> FindUsersByTagAsync(String query);
    }
}