using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JustR.Desktop.Services.Abstractions;
using JustR.Core;
using JustR.Core.Dto;
using JustR.Core.Extensions;
using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;

namespace JustR.Desktop.Services.Implementations
{
    public class FriendService : IFriendService
    {
        private readonly RestClient _restClient = new RestClient(GatewayConfiguration.ApiGatewaySource);

        public FriendService()
        {
            _restClient.UseNewtonsoftJson();
        }
        public async Task<List<UserPreviewDto>> GetFriendsAsync(Guid userId)
        {
            var request = new RestRequest("Friend");
            request.AddQueryParameter("userId", userId);

            var friends = await _restClient.GetAsync<List<UserPreviewDto>>(request);

            return friends;
        }

        public async Task DeleteFriend(FriendRequestDto dto)
        {
           var request = new RestRequest("Friend");
           request.AddJsonBody(dto);
           request.RequestFormat = DataFormat.Json;

           await _restClient.DeleteAsync<Object>(request);
        }

        public async Task CreateFriendRequestAsync(FriendRequestDto dto)
        {
            var request = new RestRequest("Friend");
            request.AddJsonBody(dto);
            request.RequestFormat = DataFormat.Json;

            var result = await _restClient.PostAsync<FriendRequestDto>(request);
        }
    }
}