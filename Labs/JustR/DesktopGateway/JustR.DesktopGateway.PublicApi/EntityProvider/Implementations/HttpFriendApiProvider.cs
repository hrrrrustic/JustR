using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using JustR.ClientRelatedShare.Dto;
using JustR.Core.Extensions;
using JustR.DesktopGateway.PublicApi.EntityProvider.Abstractions;
using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;

namespace JustR.DesktopGateway.PublicApi.EntityProvider.Implementations
{
    public class HttpFriendApiProvider : IFriendApiProvider
    {
        private readonly IRestClient _restClient;

        internal HttpFriendApiProvider(String baseUrl)
        {
            _restClient = new RestClient(baseUrl).UseNewtonsoftJson();
        }

        public async Task<IReadOnlyList<UserPreviewDto>> GetUserFriends(Guid userId)
        {
            IRestRequest request = new RestRequest(DesktopGatewayHttpEndpoints.FriendEndpoints.GetUserFriends)
                .AddQueryParameter("userId", userId);
            IReadOnlyList<UserPreviewDto> friends = await _restClient.GetAsync<List<UserPreviewDto>>(request);

            return friends;
        }

        public async Task<FriendRequestDto> CreateFriendRequest(FriendRequestDto dto)
        {
            var request = new RestRequest(DesktopGatewayHttpEndpoints.FriendEndpoints.CreateFriendRequest)
                .AddJsonBody(dto);

            // TODO : Явно нужно что-то ловить и использовать
            await _restClient.PostAsync<FriendRequestDto>(request);

            return dto;
        }

        public Task<FriendRequestDto> CreateFriendResponse(FriendRequestDto dto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteFriend(Guid userId, Guid secondUserId)
        {
            throw new NotImplementedException();
        }
    }
}