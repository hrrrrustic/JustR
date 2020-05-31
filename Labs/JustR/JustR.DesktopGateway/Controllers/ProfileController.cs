using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using JustR.Core.Dto;
using JustR.Core.Entity;
using JustR.Models.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;

namespace JustR.DesktopGateway.Controllers
{
    [Consumes("application/json")]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ProfileController : Controller
    {
        private readonly RestClient _restClient;

        public ProfileController()
        {
            _restClient = new RestClient(ServiceConfigurations.ProfileServiceUri);
            _restClient.UseNewtonsoftJson();
        }
        [HttpGet]
        public async Task<ActionResult<UserProfileDto>> GetUserProfile([FromQuery] Guid userId)
        {
            var request = new RestRequest("userId", Method.GET, DataFormat.Json).AddQueryParameter("userId", userId, ParameterType.QueryString);

            ServicePointManager.ServerCertificateValidationCallback +=
                (sender, certificate, chain, sslPolicyErrors) => true;
            var res = await _restClient.GetAsync<User>(request);

            var preview = UserPreviewDto.FromUser(res);

            return Ok(preview);
        }

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<UserPreviewDto>>> SearchUser([FromQuery] String query)
        {
            var request = new RestRequest("search",DataFormat.Json).AddQueryParameter("query", query, ParameterType.QueryString);

            var response = await _restClient.GetAsync<List<User>>(request);

            var res = response.Select(UserPreviewDto.FromUser);


            return Ok(res.ToList());
        }

        [HttpGet("preview")]
        public async Task<ActionResult<UserPreviewDto>> GetUserPreview([FromQuery] Guid userId) // Что-то на уровне фотка + имя
        {
            var request = new RestRequest("preview").AddQueryParameter("userId", userId, ParameterType.QueryString);
            var response = await _restClient.GetAsync<UserPreviewDto>(request);

            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult<User>> UpdateUserProfile([FromBody] User dto)
        {
            var request = new RestRequest(Method.PUT).AddJsonBody(dto);
            var response = await _restClient.PutAsync<User>(request);

            if (response is null)
                return BadRequest();

            return Ok(response);
        }

        [HttpGet("login")]
        public async Task<ActionResult<UserPreviewDto>> SimpleAuth([FromQuery] String userTag)
        {
            var request = new RestRequest("login", Method.GET, DataFormat.Json)
                .AddQueryParameter("userTag", userTag, ParameterType.QueryString);

            var response = await _restClient.GetAsync<UserPreviewDto>(request);

            return Ok(response);


        }

    }
}
