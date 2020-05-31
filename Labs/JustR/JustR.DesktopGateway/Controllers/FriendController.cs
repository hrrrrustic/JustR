using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JustR.Core.Dto;
using JustR.Core.Entity;
using JustR.Models.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;

namespace JustR.DesktopGateway.Controllers
{
    [Consumes("application/json")]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class FriendController : Controller
    {
        private readonly RestClient _friendClient = new RestClient(ServiceConfigurations.FriendServiceUri);
        private readonly RestClient _profileClient = new RestClient(ServiceConfigurations.ProfileServiceUri);


        public FriendController()
        {
            _friendClient.UseNewtonsoftJson();
            _profileClient.UseNewtonsoftJson();
        }
        [HttpGet]
        public async Task<ActionResult<List<UserPreviewDto>>> GetUserFriends([FromQuery] Guid userId)
        {
            var request = new RestRequest();
            request.AddQueryParameter("userId", userId, ParameterType.QueryString);

            List<Guid> friendsId = await _friendClient.GetAsync<List<Guid>>(request);
            if (friendsId is null)
                return Ok(Array.Empty<UserPreviewDto>());

            List<UserPreviewDto> previews = new List<UserPreviewDto>(friendsId.Count);
            foreach (Guid id in friendsId)
            {
                request = new RestRequest("preview");
                request.AddQueryParameter("userId", id, ParameterType.QueryString);

                var res = await _profileClient.GetAsync<User>(request);
                var result = UserPreviewDto.FromUser(res);

                previews.Add(result);
            }
            return Ok(previews);
        }

        [HttpPost]
        public async Task<ActionResult<FriendRequestDto>> CreateFriendRequest([FromBody] FriendRequestDto dto)
        {
            Relationship relationship = new Relationship
            {
                FirstUserId = dto.FirstUserId,
                SecondUserId = dto.SecondUserId,
                State = dto.State
            };

            var request = new RestRequest();
            request.AddJsonBody(relationship);
            request.RequestFormat = DataFormat.Json;

            relationship = await _friendClient.PostAsync<Relationship>(request);

            var result = new FriendRequestDto
            {
                FirstUserId = relationship.FirstUserId,
                SecondUserId = relationship.SecondUserId,
                State = relationship.State
            };
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<FriendRequestDto>> CreateFriendResponse(FriendRequestDto dto)
        {
            Relationship relationship = new Relationship
            {
                FirstUserId = dto.FirstUserId,
                SecondUserId = dto.SecondUserId,
                State = dto.State
            };

            var request = new RestRequest();
            request.AddJsonBody(relationship);
            request.RequestFormat = DataFormat.Json;

            relationship = await _friendClient.PutAsync<Relationship>(request);

            var result = new FriendRequestDto
            {
                FirstUserId = relationship.FirstUserId,
                SecondUserId = relationship.SecondUserId,
                State = relationship.State
            };

            return Ok(result);
        }

        [HttpDelete]
        public ActionResult DeleteFriend(Guid userId, Guid secondUserId)
        {
            throw new NotImplementedException();
        }
    }
}
