using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JustR.Core.Dto;
using JustR.Core.Extensions;
using JustR.Core.Entity;
using JustR.ProfileService.InternalApi;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;

namespace JustR.DesktopGateway.Controllers
{
    [Consumes("application/json")]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ProfileController : Controller
    {
        private readonly IProfileApiProvider _profileApiProvider = new HttpProfileApiProvider(ServiceConfigurations.ProfileServiceUrl);
        #region HTTP GET

        [HttpGet]
        public async Task<ActionResult<UserProfileDto>> GetUserProfile([FromQuery] Guid userId)
        {
            User user = await _profileApiProvider.GetUserPreview(userId);

            UserPreviewDto preview = UserPreviewDto.FromUser(user);

            return Ok(preview);
        }

        [HttpGet("search")]
        public async Task<ActionResult<IReadOnlyList<UserPreviewDto>>> SearchUser([FromQuery] String query)
        {
            IReadOnlyList<User> users = await _profileApiProvider.SearchUser(query);

            IReadOnlyList<UserPreviewDto> res = users.Select(UserPreviewDto.FromUser).ToList();

            return Ok(res);
        }

        [HttpGet("preview")]
        public async Task<ActionResult<UserPreviewDto>> GetUserPreview([FromQuery] Guid userId)
        {
            User user = await _profileApiProvider.GetUserPreview(userId);

            var preview = UserPreviewDto.FromUser(user);

            return Ok(preview); 
        }

        [HttpGet("login")]
        public async Task<ActionResult<UserPreviewDto>> SimpleAuth([FromQuery] String userTag)
        {
            User user = await _profileApiProvider.SimpleLogIn(userTag);

            var result = UserPreviewDto.FromUser(user);

            return Ok(result);
        }

        #endregion

        #region HTTP PUT

        [HttpPut]
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
