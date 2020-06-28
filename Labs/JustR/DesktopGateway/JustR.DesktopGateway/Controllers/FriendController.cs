using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JustR.ClientRelatedShare.Dto;
using JustR.Core.Entity;
using JustR.Models.Entity;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using JustR.FriendService.InternalApi;
using JustR.ProfileService.InternalApi;

namespace JustR.DesktopGateway.Controllers
{
    [Consumes("application/json")]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class FriendController : Controller
    {
        private readonly IFriendApiProvider _friendApiProvider = new HttpFriendApiProvider(ServiceConfigurations.FriendServiceUrl);
        private readonly IProfileApiProvider _profileApiProvider = new HttpProfileApiProvider(ServiceConfigurations.ProfileServiceUrl);
        #region HTTP GET

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<UserPreviewDto>>> GetUserFriends([FromQuery] Guid userId)
        {
            IReadOnlyList<Guid> friendsId = await _friendApiProvider.GetUserFriends(userId);

            if (friendsId is null)
                return Ok(Array.Empty<UserPreviewDto>());

            IReadOnlyList<User> users = await _profileApiProvider.GetUsersPreview(friendsId);

            IReadOnlyList<UserPreviewDto> previews = users
                .Select(UserPreviewDto.FromUser)
                .ToList();

            return Ok(previews);
        }

        #endregion

        #region HTTP POST

        [HttpPost]
        public async Task<ActionResult<FriendRequestDto>> CreateFriendRequest([FromBody] FriendRequestDto dto)
        {
            Relationship relationship = await _friendApiProvider.CreateFriendRequest(dto.ToRelationship());

            FriendRequestDto result = FriendRequestDto.FromRelationship(relationship);

            return Ok(result);
        }

        #endregion

        #region HTTP PUT

        [HttpPut]
        public async Task<ActionResult<FriendRequestDto>> CreateFriendResponse(FriendRequestDto dto)
        {
            Relationship relationship = await _friendApiProvider.CreateFriendResponse(dto.ToRelationship());

            FriendRequestDto result = FriendRequestDto.FromRelationship(relationship);

            return Ok(result);
        }

        #endregion

        #region HTTP DELETE

        [HttpDelete]
        public ActionResult DeleteFriend(Guid userId, Guid secondUserId)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
