using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using JustR.Models.Dto;
using JustR.Models.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using RestSharp;

namespace JustR.DesktopGateway.Controllers
{
    [Consumes("application/json")]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ProfileController : Controller
    {
        private readonly HttpClient _client = new HttpClient();

        private readonly RestClient _restClient;

        public ProfileController()
        {
            _restClient = new RestClient(ServiceConfigurations.ProfileServiceUri);
            _client.BaseAddress = new Uri(ServiceConfigurations.ProfileServiceUri);
        }
        [HttpGet("{userId}")]
        public async Task<ActionResult<UserProfileDto>> GetUserProfile(Guid userId)
        {
            var request = new RestRequest("userId", Method.GET, DataFormat.Json).AddParameter("userId", userId, ParameterType.QueryString);

            ServicePointManager.ServerCertificateValidationCallback +=
                (sender, certificate, chain, sslPolicyErrors) => true;
            var res = await _restClient.GetAsync<User>(request);

            var preview = new UserPreviewDto
            {
                Avatar = res.Avatar,
                UserName = res.FirstName + res.LastName,
                UniqueTag = res.UniqueTag,
                UserId = res.UserId
            };

            return Ok(preview);
        }

        [HttpGet("search/{query}")]
        public async Task<ActionResult<IEnumerable<UserPreviewDto>>> SearchUser(String query)
        {
            var request = new RestRequest("search",DataFormat.Json).AddParameter("query", query, ParameterType.QueryString);

            var response = await _restClient.GetAsync<List<User>>(request);

            var res = response.Select(k => new UserPreviewDto
            {
                Avatar = k.Avatar,
                UserName = k.FirstName + k.LastName,
                UniqueTag = k.UniqueTag,
                UserId = k.UserId
            });


            return Ok(res.ToList());
        }

        [HttpGet("preview/{userId}")]
        public async Task<ActionResult<UserPreviewDto>> GetUserPreview(Guid userId) // Что-то на уровне фотка + имя
        {
            var request = new RestRequest("preview").AddParameter("userId", userId, ParameterType.QueryString);
            var response = await _restClient.GetAsync<UserPreviewDto>(request);

            return Ok(response);
        }

        [HttpPut]
        public ActionResult<ChangeProfileDto> UpdateUserProfile(ChangeProfileDto dto)
        {
            throw new NotImplementedException();
        }

        [HttpGet("login/{userTag}")]
        public async Task<ActionResult<UserPreviewDto>> SimpleAuth(String userTag)
        {
            var request = new RestRequest("login/{userTag}", Method.GET, DataFormat.Json)
                .AddParameter("userTag", userTag, ParameterType.QueryString);
            var response = await _restClient.GetAsync<UserPreviewDto>(request);
            
            return Ok(response);
        }

    }
}
