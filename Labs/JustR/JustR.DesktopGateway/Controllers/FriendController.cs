using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JustR.Core.Dto;
using JustR.Core.Entity;
using JustR.Models.Entity;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using JustR.Core.Extensions;
using RestSharp.Serializers.NewtonsoftJson;

namespace JustR.DesktopGateway.Controllers
{
    [Consumes("application/json")]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class FriendController : Controller
    {
        private readonly IRestClient _friendClient =
            new RestClient(ServiceConfigurations.FriendServiceUri)
                .UseNewtonsoftJson();

        private readonly IRestClient _profileClient =
            new RestClient(ServiceConfigurations.ProfileServiceUri)
                .UseNewtonsoftJson();

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<UserPreviewDto>>> GetUserFriends([FromQuery] Guid userId)
        {
            IRestRequest request = new RestRequest()
                .AddQueryParameter("userId", userId);

            IReadOnlyList<Guid> friendsId = await _friendClient.GetAsync<List<Guid>>(request);

            if (friendsId is null)
                return Ok(Array.Empty<UserPreviewDto>());

            request = new RestRequest("previews");

            foreach (Guid guid in friendsId)
                request.AddQueryParameter("usersId", guid);

            IReadOnlyList<User> users = await _profileClient.GetAsync<List<User>>(request);

            IReadOnlyList<UserPreviewDto> previews = users
                .Select(UserPreviewDto.FromUser)
                .ToList();

            return Ok(previews);
        }

        [HttpPost]
        public async Task<ActionResult<FriendRequestDto>> CreateFriendRequest([FromBody] FriendRequestDto dto)
        {
            Relationship relationship = dto.ToRelationship();

            IRestRequest request = new RestRequest()
                .AddJsonBody(relationship);

            relationship = await _friendClient.PostAsync<Relationship>(request);

            FriendRequestDto result = FriendRequestDto.FromRelationship(relationship);

            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<FriendRequestDto>> CreateFriendResponse(FriendRequestDto dto)
        {
            Relationship relationship = dto.ToRelationship();

            IRestRequest request = new RestRequest()
                .AddJsonBody(relationship);

            relationship = await _friendClient.PutAsync<Relationship>(request);

            FriendRequestDto result = FriendRequestDto.FromRelationship(relationship);

            return Ok(result);
        }

        [HttpDelete]
        public ActionResult DeleteFriend(Guid userId, Guid secondUserId)
        {
            throw new NotImplementedException();
        }
    }
}
