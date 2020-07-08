using System;
using System.Collections.Generic;
using JustR.FriendService.InternalApi;
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

        [HttpGet(FriendSerivceHttpEndpoints.GetUserFriends)]
        public ActionResult<IReadOnlyList<Guid>> GetUserFriends([FromQuery] Guid userId)
        {
            IReadOnlyList<Guid> usersId = _friendService.GetFriends(userId);

            return Ok(usersId);
        }

        #endregion

        #region HTTP POST

        [HttpPost(FriendSerivceHttpEndpoints.CreateFriendRequest)]
        public ActionResult<Relationship> CreateFriendRequest([FromBody] Relationship relationship)
        {
            //TODO : Ну эээ.. Выпилить
            if (relationship is null)
                return BadRequest();

            return Ok(_friendService.CreateFriendRequest(relationship));
        }

        #endregion

        #region HTTP POST

        [HttpPut(FriendSerivceHttpEndpoints.CreateFriendResponse)]
        public ActionResult<Relationship> CreateFriendResponse([FromBody] Relationship relationship)
        {
            //TODO : Выпилить
            if (relationship is null)
                return BadRequest();

            return Ok(_friendService.UpdateFriendRequest(relationship));
        }

        #endregion

        #region HTTP DELETE

        [HttpDelete(FriendSerivceHttpEndpoints.DeleteFriend)]
        public ActionResult DeleteFriend([FromQuery] Guid firstUserId, Guid secondUserId)
        {
            _friendService.DeleteFriend(firstUserId, secondUserId);

            return Ok();
        }

        #endregion
    }
}