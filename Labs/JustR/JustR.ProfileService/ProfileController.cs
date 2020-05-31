using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using JustR.Core.Entity;
using JustR.Models.Entity;
using JustR.ProfileService.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebSockets;

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

        [HttpGet]
        public ActionResult<User> GetUserProfile([FromQuery] Guid userId)
        {
            return Ok(_profileService.GetUserProfile(userId));
        }


        [HttpGet]
        public ActionResult<List<User>> GetUserProfile([FromQuery] List<Guid> usersId)
        {
            var res = usersId.Select(k => _profileService.GetUserProfile(k)).ToList();
            return Ok(res);
        }

        [HttpGet("search")]
        public ActionResult<List<User>> SearchUser([FromQuery] String query)
        {
            if (query is null)
                return BadRequest();

            return Ok(_profileService.SearchUser(query));
        }

        [HttpGet("preview")]
        public ActionResult<User> GetUserPreview([FromQuery] Guid userId) // Что-то на уровне фотка + имя
        {
            return Ok(_profileService.GetUserPreview(userId));
        }

        [HttpPut]
        public ActionResult<User> UpdateUserProfile([FromBody] User user)
        {
            var res = _profileService.UpdateUserProfile(user);

            return Ok(res);
        }

        [HttpGet("login")]
        public ActionResult<User> SimpleLogIn([FromQuery] String userTag)
        {
            var user = _profileService.FakeLogIn(userTag);

            return Ok(user);
        }
    }
}
