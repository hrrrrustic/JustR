using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JustR.Models.Dto;
using JustR.ProfileService.Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JustR.ProfileService
{
    [Route("api/[controller]")]
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

        [HttpGet("search/{query}")]
        public ActionResult<IEnumerable<UserPreviewDto>> SearchUser(String query)
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
        public ActionResult<ChangeProfileDto> UpdateUserProfile(ChangeProfileDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
