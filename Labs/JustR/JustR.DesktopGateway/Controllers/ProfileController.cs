using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JustR.Core.Dto;
using JustR.Core.Extensions;
using JustR.Core.Entity;
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
        private readonly IRestClient _restClient =
            new RestClient(ServiceConfigurations.ProfileServiceUrl)
                .UseNewtonsoftJson();

        #region HTTP GET

        [HttpGet]
        public async Task<ActionResult<UserProfileDto>> GetUserProfile([FromQuery] Guid userId)
        {
            IRestRequest request = new RestRequest("userId")
                .AddQueryParameter("userId", userId);

            User user = await _restClient.GetAsync<User>(request);
            UserPreviewDto preview = UserPreviewDto.FromUser(user);

            return Ok(preview);
        }

        [HttpGet("search")]
        public async Task<ActionResult<IReadOnlyList<UserPreviewDto>>> SearchUser([FromQuery] String query)
        {
            IRestRequest request = new RestRequest("search")
                .AddQueryParameter("query", query);

            List<User> response = await _restClient.GetAsync<List<User>>(request);

            IReadOnlyList<UserPreviewDto> res = response.Select(UserPreviewDto.FromUser).ToList();

            return Ok(res);
        }

        [HttpGet("preview")]
        public async Task<ActionResult<UserPreviewDto>> GetUserPreview([FromQuery] Guid userId)
        {
            IRestRequest request = new RestRequest("preview")
                .AddQueryParameter("userId", userId);

            UserPreviewDto userPreview = await _restClient.GetAsync<UserPreviewDto>(request);

            return Ok(userPreview);
        }

        [HttpGet("login")]
        public async Task<ActionResult<UserPreviewDto>> SimpleAuth([FromQuery] String userTag)
        {
            IRestRequest request = new RestRequest("login")
                .AddQueryParameter("userTag", userTag);

            UserPreviewDto response = await _restClient.GetAsync<UserPreviewDto>(request);

            return Ok(response);
        }

        #endregion

        #region HTTP PUT

        [HttpPut]
        public async Task<ActionResult<User>> UpdateUserProfile([FromBody] User newUserProfile)
        {
            IRestRequest request = new RestRequest()
                .AddJsonBody(newUserProfile);

            User updatedProfile = await _restClient.PutAsync<User>(request);

            if (updatedProfile is null)
                return BadRequest();

            return Ok(updatedProfile);
        }

        #endregion
    }
}
