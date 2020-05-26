using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using JustR.Models.Dto;
using JustR.Models.Entity;
using JustR.ProfileService.Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JustR.ProfileService
{
    [Route("api/[controller]")]
    [Consumes("application/json")]
    [Produces("application/json")]
    public class ProfileController : Controller
    {
        private readonly IProfileService _profileService;

        public ProfileController(IProfileService profileService)
        {
            _profileService = profileService;
        }

        [HttpGet("{userId}")]
        public ActionResult<UserProfileDto> GetUserProfile(Guid userId)
        {
            return Ok(_profileService.GetUserProfile(userId));
        }

        [HttpGet("search")]
        public ActionResult<IEnumerable<UserPreviewDto>> SearchUser([FromQuery] String query)
        {
            if (query is null)
                return BadRequest();

            return Ok(_profileService.SearchUser(query));
        }

        [HttpGet("preview/{userId}")]
        public ActionResult<UserPreviewDto> GetUserPreview(Guid userId) // Что-то на уровне фотка + имя
        {
            return Ok(_profileService.GetUserPreview(userId));
        }

        [HttpPut]
        public ActionResult<ChangeProfileDto> UpdateUserProfile([FromBody] User user)
        {
            var res = _profileService.UpdateUserProfile(user);

            return Ok(res);
        }

        [HttpGet("login")]
        public ActionResult<UserPreviewDto> SimpleLogIn([FromQuery] String userTag)
        {
            var user = _profileService.FakeLogIn(userTag);
            UserPreviewDto preview = new UserPreviewDto
            {
                Avatar = user.Avatar,
                UserName = user.FirstName + user.LastName,
                UniqueTag = user.UniqueTag,
                UserId = user.UserId
            };

            return Ok(preview);
        }
    }
}
