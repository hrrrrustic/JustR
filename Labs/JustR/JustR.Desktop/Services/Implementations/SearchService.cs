using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JustR.Core.Dto;
using JustR.Desktop.Services.Abstractions;
using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;

namespace JustR.Desktop.Services.Implementations
{
    public class SearchService : ISearchService
    {
        private readonly RestClient _restClient = new RestClient(GatewayConfiguration.ApiGatewaySource);

        public SearchService()
        {
            _restClient.UseNewtonsoftJson();
        }
        public async Task<IReadOnlyList<UserPreviewDto>> FindUsersByTagAsync(String query)
        {
            var request = new RestRequest("Profile/search")
                .AddQueryParameter("query", query);

            var response = await _restClient.GetAsync<List<UserPreviewDto>>(request);

            return response;
        }
    }
}