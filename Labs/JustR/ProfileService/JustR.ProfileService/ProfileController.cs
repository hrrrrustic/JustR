using System;
using System.Collections.Generic;
using System.Linq;
using JustR.Core.Entity;
using JustR.ProfileService.InternalApi;
using JustR.ProfileService.Service;
using Microsoft.AspNetCore.Mvc;

namespace JustR.ProfileService
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class ProfileController : Controller
    {
        private readonly IProfileService _profileService;

        public ProfileController(IProfileService profileService)
        {
            _profileService = profileService;
        }

        #region HTTP GET

        [HttpGet(ProfileServiceHttpEndpoints.GetUserProfile)]
        public ActionResult<User> GetUserProfile([FromQuery] Guid userId)
        {
            User userProfile = _profileService.GetUserProfile(userId);

            if (userProfile is null)
                userProfile = new User {FirstName = "TEST"};

            return Ok(userProfile);
        }

        [HttpGet(ProfileServiceHttpEndpoints.GetUsersPreview)]
        
        public ActionResult<IReadOnlyList<User>> GetUsersPreview([FromQuery] List<Guid> usersId)
        {
            IReadOnlyList<User> usersProfile = usersId
                .Select(k => _profileService.GetUserProfile(k))
                .ToList();

            return Ok(usersProfile);
        }

        [HttpGet(ProfileServiceHttpEndpoints.SearchUser)]
        public ActionResult<IReadOnlyList<User>> SearchUser([FromQuery] String query)
        {
            if (query is null)
                return BadRequest();

            IReadOnlyList<User> foundUsers = _profileService.SearchUser(query);

            return Ok(foundUsers);
        }

        [HttpGet(ProfileServiceHttpEndpoints.GetUserPreview)]
        public ActionResult<User> GetUserPreview([FromQuery] Guid userId)
        {
            User userPreview = _profileService.GetUserPreview(userId);

            return Ok(userPreview);
        }

        [HttpGet(ProfileServiceHttpEndpoints.SimpleLogin)]
        public ActionResult<User> SimpleLogIn([FromQuery] String userTag)
        {
            User loggedUser = _profileService.FakeLogIn(userTag);

            return Ok(loggedUser);
        }

        #endregion

        #region HTTP PUT

        [HttpPut(ProfileServiceHttpEndpoints.UpdateUserProfile)]
        public ActionResult<User> UpdateUserProfile([FromBody] User user)
        {
            User updatedUserProfile = _profileService.UpdateUserProfile(user);

            return Ok(updatedUserProfile);
        }

        #endregion
    }
}
