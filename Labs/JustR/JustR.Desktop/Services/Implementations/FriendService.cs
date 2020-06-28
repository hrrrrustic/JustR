using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JustR.ClientRelatedShare.Dto;
using JustR.Desktop.Services.Abstractions;
using JustR.Core.Extensions;
using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;

namespace JustR.Desktop.Services.Implementations
{
    public class FriendService : IFriendService
    {
        private readonly IRestClient _restClient =
            new RestClient(GatewayConfiguration.ApiGatewaySource)
                .UseNewtonsoftJson();

        public async Task<IReadOnlyList<UserPreviewDto>> GetFriendsAsync(Guid userId)
        {
            IRestRequest request = new RestRequest("Friend")
                .AddQueryParameter("userId", userId);

            IReadOnlyList<UserPreviewDto> friends = await _restClient.GetAsync<List<UserPreviewDto>>(request);

            return friends;
        }

        public async Task DeleteFriend(FriendRequestDto dto)
        {
           IRestRequest request = new RestRequest("Friend")
               .AddJsonBody(dto);

            //TODO : Убрать Object, когда доделаю удаление друзей
           await _restClient.DeleteAsync<Object>(request);
        }

        public async Task CreateFriendRequestAsync(FriendRequestDto dto)
        {
            var request = new RestRequest("Friend")
                .AddJsonBody(dto);


            // TODO : Явно нужно что-то ловить и использовать
            await _restClient.PostAsync<FriendRequestDto>(request);
        }
    }
}