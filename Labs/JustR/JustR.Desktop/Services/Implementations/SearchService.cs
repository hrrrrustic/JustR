using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JustR.ClientRelatedShare.Dto;
using JustR.Desktop.Services.Abstractions;
using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;

namespace JustR.Desktop.Services.Implementations
{
    public class SearchService : ISearchService
    {
        private readonly IRestClient _restClient =
            new RestClient(GatewayConfiguration.ApiGatewaySource)
                .UseNewtonsoftJson();
        public async Task<IReadOnlyList<UserPreviewDto>> FindUsersByTagAsync(String query)
        {
            IRestRequest request = new RestRequest("Profile/search")
                .AddQueryParameter("query", query);

            IReadOnlyList<UserPreviewDto> response = await _restClient.GetAsync<List<UserPreviewDto>>(request);

            return response;
        }
    }
}