using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JustR.ClientRelatedShare.Dto;
using JustR.Desktop.Services.Abstractions;
using JustR.DesktopGateway.PublicApi;

namespace JustR.Desktop.Services.Implementations
{
    public class SearchService : ISearchService
    {
        private readonly IDesktopGatewayApiProvider _desktopGatewayApiProvider =
            new HttpDesktopGatewayApiProvider(GatewayConfiguration.ApiGatewaySource);

        public async Task<IReadOnlyList<UserPreviewDto>> FindUsersByTagAsync(String query)
        {
            return await _desktopGatewayApiProvider.ProfileEntityApiProvider.SearchUser(query);
        }
    }
}