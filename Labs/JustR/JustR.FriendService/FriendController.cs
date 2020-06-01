using System;
using System.Collections.Generic;
using JustR.FriendService.Service;
using JustR.Models.Entity;
using Microsoft.AspNetCore.Mvc;

namespace JustR.FriendService
{
    [Consumes("application/json")]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class FriendController : Controller
    {
        private readonly IFriendService _friendService;
        public FriendController(IFriendService friendService)
        {
            _friendService = friendService;
        }

        #region HTTP GET

        [HttpGet]
        public ActionResult<IReadOnlyList<Guid>> GetUserFriends([FromQuery] Guid userId)
        {
            IReadOnlyList<Guid> usersId = _friendService.GetFriends(userId);

            return Ok(usersId);
        }

        #endregion

        #region HTTP POST

        [HttpPost]
        public ActionResult<Relationship> CreateFriendRequest([FromBody] Relationship relationship)
        {

            if (relationship is null)
                return BadRequest();

            return Ok(_friendService.CreateFriendRequest(relationship));
        }
        #endregion

        #region HTTP POST

        [HttpPut]
        public ActionResult<Relationship> CreateFriendResponse([FromBody] Relationship relationship)
        {
            if (relationship is null)
                return BadRequest();

            return Ok(_friendService.UpdateFriendRequest(relationship));
        }
        #endregion

        #region HTTP DELETE

        [HttpDelete]
        public ActionResult DeleteFriend([FromBody] Relationship relationship)
        {
            _friendService.DeleteFriend(relationship);

            return Ok();
        }
        #endregion
    }
}