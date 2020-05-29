using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using JustR.Desktop.Services.Abstractions;
using JustR.Models.Dto;

namespace JustR.Desktop.Services.Implementations
{
    public class DummySearchService : ISearchService
    {
        private static readonly List<UserPreviewDto> Users = new List<UserPreviewDto>
        {
            SampleData.SampleData.Vova.ToUserPreviewDto(),
            SampleData.SampleData.Ilya.ToUserPreviewDto()
        };
        public async Task<List<UserPreviewDto>> FindUsersByTagAsync(String query)
        {
            return Users
                .Where(k => k
                    .UniqueTag
                    .Contains(query, StringComparison.InvariantCultureIgnoreCase))
                .ToList();

        }
    }
}