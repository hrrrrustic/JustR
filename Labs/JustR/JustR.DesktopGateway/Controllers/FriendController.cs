using System;
using System.Collections.Generic;
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
        public async Task<ActionResult<List<UserPreviewDto>>> GetUserFriends([FromQuery] Guid userId)
        {
            var request = new RestRequest()
                .AddQueryParameter("userId", userId);

            List<Guid> friendsId = await _friendClient.GetAsync<List<Guid>>(request);

            if (friendsId is null)
                return Ok(Array.Empty<UserPreviewDto>());

            List<UserPreviewDto> previews = new List<UserPreviewDto>(friendsId.Count);

            foreach (Guid id in friendsId)
            {
                request = new RestRequest("preview")
                    .AddQueryParameter("userId", id);

                User res = await _profileClient.GetAsync<User>(request);
                UserPreviewDto result = UserPreviewDto.FromUser(res);

                previews.Add(result);
            }
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
