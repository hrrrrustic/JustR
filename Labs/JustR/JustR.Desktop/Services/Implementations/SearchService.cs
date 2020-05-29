using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JustR.Desktop.Services.Abstractions;
using JustR.Models.Dto;
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
        public async Task<List<UserPreviewDto>> FindUsersByTagAsync(String query)
        {
            var request = new RestRequest("Profile/search", Method.GET, DataFormat.Json).AddParameter("query", query, ParameterType.QueryString);
            var response = await _restClient.GetAsync<List<UserPreviewDto>>(request);
            return response;
        }
    }
}