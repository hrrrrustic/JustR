using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JustR.ClientRelatedShare.Dto;
using JustR.Core.Extensions;
using JustR.Core.Entity;
using JustR.DesktopGateway.PublicApi;
using JustR.ProfileService.InternalApi;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;

namespace JustR.DesktopGateway.Controllers
{
    [Consumes("application/json")]
    [Produces("application/json")]
    [Route("api/" + DesktopGatewayHttpEndpoints.ProfileEndpoints.ControllerEndpoint)]
    public class ProfileController : Controller
    {
        private readonly IProfileApiProvider _profileApiProvider;

        public ProfileController(IProfileApiProvider provider)
        {
            _profileApiProvider = provider;
        }

        #region HTTP GET

        [HttpGet(DesktopGatewayHttpEndpoints.ProfileEndpoints.GetUserProfile)]
        public async Task<ActionResult<UserProfileDto>> GetUserProfile([FromQuery] Guid userId)
        {
            User user = await _profileApiProvider.GetUserProfile(userId);

            UserPreviewDto preview = UserPreviewDto.FromUser(user);

            return Ok(preview);
        }

        [HttpGet(DesktopGatewayHttpEndpoints.ProfileEndpoints.SearchUser)]
        public async Task<ActionResult<IReadOnlyList<UserPreviewDto>>> SearchUser([FromQuery] String query)
        {
            IReadOnlyList<User> users = await _profileApiProvider.SearchUser(query);

            IReadOnlyList<UserPreviewDto> res = users.Select(UserPreviewDto.FromUser).ToList();

            return Ok(res);
        }

        [HttpGet(DesktopGatewayHttpEndpoints.ProfileEndpoints.GetUserPreview)]
        public async Task<ActionResult<UserPreviewDto>> GetUserPreview([FromQuery] Guid userId)
        {
            User user = await _profileApiProvider.GetUserPreview(userId);

            var preview = UserPreviewDto.FromUser(user);

            return Ok(preview);
        }

        [HttpGet(DesktopGatewayHttpEndpoints.ProfileEndpoints.SimpleAuth)]
        public async Task<ActionResult<User>> SimpleAuth([FromQuery] String userTag)
        {
            User user = await _profileApiProvider.SimpleLogIn(userTag);

            return Ok(user);
        }

        #endregion

        #region HTTP PUT

        [HttpPut(DesktopGatewayHttpEndpoints.ProfileEndpoints.UpdateUserProfile)]
        public async Task<ActionResult<User>> UpdateUserProfile([FromBody] User newUserProfile)
        {
            User updatedProfile = await _profileApiProvider.UpdateUserProfile(newUserProfile);

            if (updatedProfile is null)
                return BadRequest();

            return Ok(updatedProfile);
        }

        #endregion
    }
}
