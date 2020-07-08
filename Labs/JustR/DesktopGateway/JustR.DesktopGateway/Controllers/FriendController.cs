using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JustR.ClientRelatedShare.Dto;
using JustR.Core.Entity;
using JustR.DesktopGateway.PublicApi;
using JustR.FriendService.InternalApi;
using JustR.Models.Entity;
using JustR.ProfileService.InternalApi;
using Microsoft.AspNetCore.Mvc;

namespace JustR.DesktopGateway.Controllers
{
    [Consumes("application/json")]
    [Produces("application/json")]
    [Route("api/" + DesktopGatewayHttpEndpoints.FriendEndpoints.ControllerEndpoint)]
    public class FriendController : Controller
    {
        private readonly IFriendApiProvider _friendApiProvider;
        private readonly IProfileApiProvider _profileApiProvider;

        public FriendController(IProfileApiProvider profileApiProvider, IFriendApiProvider friendApiProvider)
        {
            _profileApiProvider = profileApiProvider;
            _friendApiProvider = friendApiProvider;
        }

        #region HTTP GET

        [HttpGet(DesktopGatewayHttpEndpoints.FriendEndpoints.GetUserFriends)]
        public async Task<ActionResult<IReadOnlyList<UserPreviewDto>>> GetUserFriends([FromQuery] Guid userId)
        {
            IReadOnlyList<Guid> friendsId = await _friendApiProvider.GetUserFriends(userId);

            IReadOnlyList<User> users = await _profileApiProvider.GetUsersPreview(friendsId);

            IReadOnlyList<UserPreviewDto> previews = users
                .Select(UserPreviewDto.FromUser)
                .ToList();

            return Ok(previews);
        }

        #endregion

        #region HTTP POST

        [HttpPost(DesktopGatewayHttpEndpoints.FriendEndpoints.CreateFriendRequest)]
        public async Task<ActionResult<FriendRequestDto>> CreateFriendRequest([FromBody] FriendRequestDto dto)
        {
            Relationship relationship = await _friendApiProvider.CreateFriendRequest(dto.ToRelationship());

            FriendRequestDto result = FriendRequestDto.FromRelationship(relationship);

            return Ok(result);
        }

        #endregion

        #region HTTP PUT

        [HttpPut(DesktopGatewayHttpEndpoints.FriendEndpoints.CreateFriendResponse)]
        public async Task<ActionResult<FriendRequestDto>> CreateFriendResponse(FriendRequestDto dto)
        {
            Relationship relationship = await _friendApiProvider.CreateFriendResponse(dto.ToRelationship());

            FriendRequestDto result = FriendRequestDto.FromRelationship(relationship);

            return Ok(result);
        }

        #endregion

        #region HTTP DELETE

        [HttpDelete(DesktopGatewayHttpEndpoints.FriendEndpoints.DeleteFriend)]
        public async Task<ActionResult> DeleteFriend(Guid userId, Guid secondUserId)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}